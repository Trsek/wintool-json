﻿using System;
using System.Collections.Generic;
using System.IO;
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

            // spustim thread
            checkBoxSpustene.Checked = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkBoxSpustene.Checked = false;
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
                if (onePodmienka.parameter == Podmienky.CESTA_PDF)
                {
                    onePodmienka.hodnota = textBoxUmiesteniePDF.Text;
                    podmienkyBindingSource.ResetBindings(true);
                    return;
                }
            }

            podmienkyBindingSource.List.Add(new Podmienky()
            {
                id_proces = GetIdPodmienok(),
                parameter = Podmienky.CESTA_PDF,
                hodnota = textBoxUmiesteniePDF.Text
            });
        }

        private void textBoxUmiesteniePDF_TextChanged(object sender, EventArgs e)
        {
            UpdatePDFPodmienky();
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {
            viewPodmienky();
            Serialize();

            // reinicializovat Spracovanie
            checkBoxSpustene.Checked = false;
            Thread.Sleep(500);
            checkBoxSpustene.Checked = true;
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
                if (dtr.Cells[0].Value != null)
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
        }

        private void dataGridViewPodmienky_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            foreach (DataGridViewRow dtr in dataGridViewPodmienky.Rows)
            {
                if (dtr.Cells[0].Value != null)
                {
                    if ((int)dtr.Cells[0].Value == 0)
                        dtr.Cells[0].Value = vybranyProces?.id;
                }
            }
        }

        private void dataGridViewProcesy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vybranyProces = dataGridViewProcesy.SelectedRows[0].DataBoundItem as Proces;
            viewPodmienky();
        }

        private int GetIdPodmienok()
        {
            if (podmienkyBindingSource.List.Count > 0)
                return ((Podmienky)podmienkyBindingSource.List[0]).id_proces;

            return 0;
        }

        private void viewPodmienky()
        {
            if (vybranyProces == null)
                return;

            // zmazem stare
            xmle.podmienky.RemoveAll(p => p.id_proces == GetIdPodmienok());
            foreach (Podmienky onePodmienka in podmienkyBindingSource.List)
                xmle.podmienky.Add(onePodmienka);

            // nastavim nove podla vybranyProces.id
            podmienkyBindingSource.List.Clear();

            foreach (Podmienky onePodmienka in xmle.podmienky.FindAll(t => t.id_proces == vybranyProces.id))
                podmienkyBindingSource.List.Add(onePodmienka);

            // aka je cesta?
            textBoxUmiesteniePDF.Text = xmle.podmienky.Find(t => t.parameter == Podmienky.CESTA_PDF)?.hodnota;
        }

        private void checkBoxSpustene_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpustene.Checked)
            {
                Spracovanie spracovanie = new Spracovanie();
                spracovanie.labelSpracovavam = labelSpracovavam;
                spracovanie.progressBar = progressBar;
                spracovanie.xmlFilename = xmlFilename;

                thr = new Thread(new ThreadStart(spracovanie.Start));
                thr.Start();
            }
            else
            {
                thr?.Abort();
                thr = null;
            }
        }
    }
}
