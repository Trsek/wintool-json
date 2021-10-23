using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinTool_json.Models;

namespace WinTool_json
{
    public class Spracovanie
    {
        public string xmlFilename;
        public NLogLite nlog = new NLogLite();
        public Label labelSpracovavam = new Label();
        public ProgressBar progressBar = new ProgressBar();

        private Exchange xmle = new Exchange();
        private const int CakajNaOpakuj = 5;

        private void Info(string message)
        {
            try
            {
                labelSpracovavam.Invoke((MethodInvoker)delegate
                {
                    labelSpracovavam.Text = message;
                });
            }
            catch { }
        }

        private void BarValue(int value)
        {
            try
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = value;
                });
            }
            catch { }
        }

        private void BarMaximum(int value)
        {
            try
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = value;
                });
            }
            catch { }
        }

        private void Step()
        {
            try
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Increment(1);
                });

                if (progressBar.Value >= progressBar.Maximum)
                    BarValue(0);
            }
            catch { }
        }

        private bool Deserialize()
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
                return false;
            }

            return true;
        }

        public List<string> ZoznamSubory(string cesta)
        {
            List<string> subory = new List<string>();

            foreach (FileSystemInfo file in new DirectoryInfo(cesta).GetFiles("*.json", SearchOption.AllDirectories))
            {
                subory.Add(file.FullName);
            }

            return subory;
        }

        public void OdsunSpracovanyAdresar(string adresar)
        {
            DirectoryInfo dir = new DirectoryInfo(adresar);
            DirectoryInfo[] dirs = dir.GetDirectories();
            string[] files = Directory.GetFiles(adresar);
            string[] sdir = adresar.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });

            Directory.CreateDirectory(xmle.SpracovanyPriecinok + "\\" + sdir[sdir.Length - 1]);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string destFile = Path.Combine(xmle.SpracovanyPriecinok + "\\" + sdir[sdir.Length-1], name);

                if (name != "file")
                    File.Move(file, destFile);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(xmle.SpracovanyPriecinok, subdir.Name);

                if (!Directory.Exists(temppath))
                    Directory.Move(subdir.FullName, temppath);
            }

            Directory.Delete(adresar, true);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    BarValue(0);
                    Info("Analyzujem nastavenia v " + xmlFilename);
                    while (!Deserialize())
                    {
                        Info("Chyba, snazim sa znova prečitať " + xmlFilename);
                        Thread.Sleep(CakajNaOpakuj * 1000);
                    }

                    Directory.CreateDirectory(xmle.ZdrojovyPriecinok);
                    Directory.CreateDirectory(xmle.SpracovanyPriecinok);

                    Step();
                    List<string> subory = new List<string>();

                    foreach (DirectoryInfo adresar in new DirectoryInfo(xmle.ZdrojovyPriecinok).GetDirectories())
                    {
                        Info("Zisťujem počet súborov v " + adresar.FullName);
                        Step();
                        subory.AddRange(ZoznamSubory(adresar.FullName));
                        Thread.Sleep(500);
                    }

                    BarValue(0);
                    BarMaximum(subory.Count);
                    foreach (string subor in subory)
                    {
                        Info("Spracúvavám " + subor);
                        Step();
                        Spracuj(subor);
                    }

                    Info("Koniec");
                    BarMaximum(100);
                    BarValue(100);
                }
                catch (Exception ex)
                {
                    Info("Chyba: " + ex.Message);
                }

                // nakoniec pockame pred dalsim spustenim
                Thread.Sleep(xmle.periodaInt * 1000);
            }
        }

        public void Spracuj(string subor)
        {
            Thread.Sleep(50);
            JsonValue json = JsonValue.Parse(File.ReadAllText(subor));
            string PDFPrecinok = xmle.podmienky.Find(t => t.funkcia == Podmienky.CESTA_PDF).hodnota;

            if (string.IsNullOrEmpty(PDFPrecinok) || json == null)
                return;

            foreach (FileSystemInfo file in new DirectoryInfo(Path.GetDirectoryName(subor)).GetFiles("*.pdf", SearchOption.AllDirectories))
            {
                nlog.Save("------------------------------");
                nlog.Save(file.FullName);
                nlog.Save(subor);

                foreach (Proces proces in xmle.proces)
                {
                    nlog.Save("proces = " + proces.nazov);
                    if (SplnujePodmienky(file.Name, proces.id, json))
                    {
                        // urobim X kopii
                        for (int i = 0; i < PocetKopii(proces.id, json); i++)
                        {
                            string fileCiel = PDFPrecinok + "\\"
                                + Path.GetFileNameWithoutExtension(file.FullName)
                                + ((i > 0) ? ("_" + i.ToString("D3")) : "")
                                + Path.GetExtension(file.FullName);

                            if (!File.Exists(fileCiel))
                                File.Copy(file.FullName, fileCiel);
                        }
                    }
                }
            }

            OdsunSpracovanyAdresar(Path.GetDirectoryName(subor));
        }

        public double GetSafeDouble(string str_value, int default_value = 0)
        {
            double value = default_value;

            if (Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator != ".")
                str_value = str_value.Replace('.', ',');
            else
                str_value = str_value.Replace(',', '.');

            if (double.TryParse(str_value, out value))
                return value;

            return default_value;
        }

        public string GetJsonValue(string parameter, JsonValue json)
        {
            try
            {
                if (string.IsNullOrEmpty(parameter))
                    return "";

                foreach (string key in parameter.Replace(" ", "").Split(new string[] { "{", "}", "[", "]" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Regex.IsMatch(key, @"\d"))
                        json = json[int.Parse(key)];
                    else
                    {
                        if (json?.JsonType == JsonType.Array)
                        {
                            foreach (JsonValue json_one in json)
                            {
                                if (json_one.ContainsKey(key))
                                {
                                    json = json_one;
                                    break;
                                }
                            }
                        }

                        json = json[key];
                    }
                }

                if ((json == null)
                 || (json?.JsonType == JsonType.Array)
                 || (json?.JsonType == JsonType.Object))
                    return "";

                return json.ToString().Replace("\"", "");
            }
            catch
            {
                nlog.Save(" Chyba GetJsonValue(" + parameter + ", json)");
                return "";
            }
        }

        public bool SplnujePodmienky(string fileName, int id_proces, JsonValue json)
        {
            foreach(Podmienky podmienka in xmle.podmienky.FindAll(t => t.id_proces == id_proces))
            {
                string value = GetJsonValue(podmienka.parameter, json).Trim();
                podmienka.hodnota = string.IsNullOrEmpty(podmienka.hodnota)? "": podmienka.hodnota.Trim();

                if ((podmienka.funkcia == Podmienky.DUPLIKOVAT)
                 || (podmienka.funkcia == Podmienky.CESTA_PDF))
                    continue;

                // v nazve PDF musi byt tento text (napr. cover)
                if (podmienka.funkcia == Podmienky.NAZOV_PDF)
                {
                    nlog.Save(" " + podmienka.funkcia + " -> (ocakavam)" + podmienka.hodnota + " = " + fileName);
                    if (!fileName.Contains(podmienka.hodnota))
                    {
                        nlog.Save("  nesplnena");
                        return false;
                    }

                    continue;
                }

                nlog.Save(" " + podmienka.parameter + " -> (ocakavam)" + podmienka.hodnota + " = (json)" + value);

                // bude kontrola na hodnotu alebo rozsah
                if (podmienka.hodnota.Contains("-"))
                {
                    string[] values = podmienka.hodnota.Split(new string[] { "-" }, StringSplitOptions.None);

                    if ((GetSafeDouble(values[0]) > GetSafeDouble(value))
                     || (GetSafeDouble(value) > GetSafeDouble(values[1])))
                    {
                        nlog.Save("  nesplnena");
                        return false;
                    }

                    continue;
                }

                // kontrola na konkretnu hodnotu
                if (value != podmienka.hodnota)
                {
                    nlog.Save("  nesplnena");
                    return false;
                }
            }

            return true;
        }

        public int PocetKopii(int id_proces, JsonValue json)
        {
            int quantity = (int)json["order"]["quantity"];
            string parameter = xmle.podmienky.Find(t => (t.id_proces == id_proces) && (t.funkcia == Podmienky.DUPLIKOVAT))?.parameter;

            // hladaj v JSON
            if (!string.IsNullOrEmpty(parameter))
            {
                string value = GetJsonValue(parameter, json);
                quantity = (int)GetSafeDouble(value, quantity);
            }

            nlog.Save("Pocet kopii=" + quantity);
            return quantity;
        }
    }
}
