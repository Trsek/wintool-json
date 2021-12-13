using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinTool_json.Models;

namespace WinTool_json
{
    public partial class MainForm : Form
    {
        const string xmlFilename = "wintool.xml";

        Exchange xmle = new Exchange();
        Proces vybranyProces = new Proces();
        Thread thr = null;

        public MainForm()
        {
            InitializeComponent();
            Deserialize();

            if (procesBindingSource.List.Count > 0)
                vybranyProces = (Proces)procesBindingSource.List[0];

            viewPodmienky();
            NacitajExample("example.json");

            dataGridViewPodmienky.AllowUserToAddRows = false;
            dataGridViewPriklady.AllowUserToAddRows = false;
            dataGridViewProcesy.AllowUserToAddRows = false;

            // spustim thread
            buttonSpustit_Click(null, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thr != null)
                buttonSpustit_Click(sender, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelCopyright.Text += ", ver." + this.ProductVersion;
        }

        private void labelCopyright_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://trsek.com/curriculum");
        }

        private void buttonUmiestnitPDF_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxUmiesteniePDF.Text;
            folderBrowserDialog.ShowDialog();
            textBoxUmiesteniePDF.Text = folderBrowserDialog.SelectedPath;
            UpdatePDFPodmienky();
        }

        private void buttonZdrojovyPriecinok_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxZdrojovyPriecinok.Text;
            folderBrowserDialog.ShowDialog();
            textBoxZdrojovyPriecinok.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonSpracovanyPriecinok_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxSpracovanyPriecinok.Text;
            folderBrowserDialog.ShowDialog();
            textBoxSpracovanyPriecinok.Text = folderBrowserDialog.SelectedPath;
        }

        private void UpdatePDFPodmienky()
        {
            foreach (Podmienky onePodmienka in podmienkyBindingSource.List)
            {
                if (onePodmienka.funkcia == Podmienky.CESTA_PDF)
                {
                    onePodmienka.hodnota = textBoxUmiesteniePDF.Text;
                    podmienkyBindingSource.ResetBindings(true);
                    return;
                }
            }

            podmienkyBindingSource.List.Add(new Podmienky()
            {
                id_proces = GetIdPodmienok(),
                hodnota = textBoxUmiesteniePDF.Text,
                funkcia = Podmienky.CESTA_PDF,
            });
        }

        private void FillPrikladyValuePair(KeyValuePair<string, JsonValue> json, string parent)
        {
            try
            {
                if (json.Value?.JsonType == JsonType.Object)
                {
                    foreach (KeyValuePair<string, JsonValue> json_part in json.Value)
                        FillPrikladyValuePair(json_part, parent + "{" + json_part.Key + "} ");

                    return;
                }

                if (json.Value?.JsonType == JsonType.Array)
                {
                    for (int i = 0; i < json.Value.Count; i++)
                    {
                        if (json.Value[i] is JsonObject)
                        {
                            foreach (var json_part in json.Value[i])
                            {
                                KeyValuePair<string, JsonValue> json_part2 = (KeyValuePair<string, JsonValue>)json_part;
                                FillPrikladyValuePair(json_part2, parent + "[" + i + "] {" + json_part2.Key + "} ");
                            }
                        }

                        if (json.Value[i] is JsonPrimitive)
                        {
                            prikladyBindingSource.List.Add(new Priklady()
                            {
                                parameter = parent,
                                hodnota = json.Value[i]?.ToString(),
                            });
                        }
                    }
                    return;
                }

                prikladyBindingSource.List.Add(new Priklady()
                {
                    parameter = parent,
                    hodnota = json.Value?.ToString(),
                });
            }
            catch { }
        }

        private void NacitajExample(string FileName)
        {
            prikladyBindingSource.List.Clear();

            if (File.Exists(FileName))
            {
                foreach (KeyValuePair<string, JsonValue> json in JsonValue.Parse(File.ReadAllText(FileName)))
                    FillPrikladyValuePair(json, "{" + json.Key + "} ");
            }
        }

        private void buttonVyberPriklad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            NacitajExample(openFileDialog.FileName);
        }

        private void textBoxUmiesteniePDF_TextChanged(object sender, EventArgs e)
        {
            UpdatePDFPodmienky();
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {
            viewPodmienky();
            Serialize();
        }

        private void Serialize()
        {
            xmle.perioda = textBoxPerioda.Text;
            xmle.ZdrojovyPriecinok = textBoxZdrojovyPriecinok.Text;
            xmle.SpracovanyPriecinok = textBoxSpracovanyPriecinok.Text;

            xmle.proces.Clear();
            foreach (Proces oneProces in procesBindingSource.List)
                xmle.proces.Add(oneProces);

            xmle.proces.Sort((x, y) => x.id.CompareTo(y.id));
            xmle.podmienky.Sort((x, y) => x.id_proces.CompareTo(y.id_proces));

            using (var fileStream = new FileStream(xmlFilename, FileMode.Create))
            {
                var ser = new XmlSerializer(typeof(Exchange));
                ser.Serialize(fileStream, xmle);
            }
        }

        public void Deserialize()
        {
            try
            {
                using (var fileStream = new FileStream(xmlFilename, FileMode.Open))
                {
                    var ser = new XmlSerializer(typeof(Exchange));
                    xmle = (Exchange)ser.Deserialize(fileStream);
                }
            }
            catch
            {
                MessageBox.Show("Nemožem otvoriť súbor " + xmlFilename);
            }

            textBoxPerioda.Text = xmle.perioda;
            textBoxZdrojovyPriecinok.Text = xmle.ZdrojovyPriecinok;
            textBoxSpracovanyPriecinok.Text = xmle.SpracovanyPriecinok;

            procesBindingSource.List.Clear();
            foreach (Proces oneProces in xmle.proces ?? new List<Proces>())
                procesBindingSource.List.Add(oneProces);
        }

        private void dataGridViewProcesy_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int maxId = 0;

            foreach (DataGridViewRow dtr in dataGridViewProcesy.Rows)
            {
                try
                {
                    if (dtr.Cells[0].Value != null && !dtr.IsNewRow)
                    {
                        if ((int)dtr.Cells[0].Value > maxId)
                            maxId = (int)dtr.Cells[0].Value;

                        if ((int)dtr.Cells[0].Value == 0)
                        {
                            dtr.Cells[0].Value = maxId + 1;
                            vybranyProces = dataGridViewProcesy.SelectedRows[0].DataBoundItem as Proces;
                            viewPodmienky();
                        }
                    }
                }
                catch (Exception ex)
                {
                    labelSpracovavam.Text = "Chyba: " + ex.Message;
                }
            }
        }

        private void dataGridViewPodmienky_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            foreach (DataGridViewRow dtr in dataGridViewPodmienky.Rows)
            {
                try
                {
                    if (dtr.Cells[0].Value != null && !dtr.IsNewRow)
                    {
                        if ((int)dtr.Cells[0].Value == 0)
                            dtr.Cells[0].Value = vybranyProces?.id;
                    }
                }
                catch (Exception ex)
                {
                    labelSpracovavam.Text = "Chyba: " + ex.Message;
                }
            }
        }

        private void dataGridViewProcesy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vybranyProces = dataGridViewProcesy.SelectedRows[0].DataBoundItem as Proces;
            viewPodmienky();
        }

        private void dataGridViewPriklad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Priklady vybranyPriklad = dataGridViewPriklady.SelectedRows[0].DataBoundItem as Priklady;

            if (dataGridViewPodmienky.SelectedCells.Count == 1)
                dataGridViewPodmienky.SelectedCells[0].Value = vybranyPriklad.parameter;

            if (dataGridViewPodmienky.SelectedCells.Count > 1)
                dataGridViewPodmienky.SelectedCells[1].Value = vybranyPriklad.parameter;
        }

        private int GetIdPodmienok()
        {
            if (podmienkyBindingSource.List.Count > 0)
                return ((Podmienky)podmienkyBindingSource.List[0]).id_proces;

            return 0;
        }

        private void viewPodmienky()
        {
            // zmazem stare
            xmle.podmienky.RemoveAll(p => p.id_proces == GetIdPodmienok());
            foreach (Podmienky onePodmienka in podmienkyBindingSource.List)
                xmle.podmienky.Add(onePodmienka);

            // nastavim nove podla vybranyProces.id
            podmienkyBindingSource.List.Clear();

            if (vybranyProces == null)
            {
                textBoxUmiesteniePDF.Text = string.Empty;
                return;
            }

            foreach (Podmienky onePodmienka in xmle.podmienky.FindAll(t => t.id_proces == vybranyProces.id))
            {
                podmienkyBindingSource.List.Add(onePodmienka);

                // aka je cesta?
                if (onePodmienka.funkcia == Podmienky.CESTA_PDF)
                    textBoxUmiesteniePDF.Text = onePodmienka.hodnota;
            }

            if (xmle.podmienky.FindAll(t => t.id_proces == vybranyProces.id && t.funkcia == Podmienky.CESTA_PDF).Count == 0)
            {
                Podmienky onePodmienka = new Podmienky()
                {
                    funkcia = Podmienky.CESTA_PDF
                };
                podmienkyBindingSource.List.Add(onePodmienka);
            }
        }

        private void buttonSpustit_Click(object sender, EventArgs e)
        {
            if (thr == null)
            {
                Spracovanie spracovanie = new Spracovanie();
                spracovanie.labelSpracovavam = labelSpracovavam;
                spracovanie.progressBar = progressBar;
                spracovanie.xmlFilename = xmlFilename;

                thr = new Thread(new ThreadStart(spracovanie.Start));
                thr.Start();
                buttonSpustit.Text = "&Beží";
                buttonSpustit.BackColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                thr?.Abort();
                thr = null;
                buttonSpustit.Text = "&Zastavené";
                buttonSpustit.BackColor = Control.DefaultBackColor;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            vybranyProces = null;
            viewPodmienky();
        }
    }
}
