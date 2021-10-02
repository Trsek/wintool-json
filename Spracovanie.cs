using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinTool_json.Models;

namespace WinTool_json
{
    public class Spracovanie
    {
        public string xmlFilename;
        public string xmlTimeStamp = "TimeStamp.xml";
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

        private DateTime TimeStampExchange(DateTime dtZapis, bool zapis)
        {
            try
            {
                if (zapis)
                {
                    using (var fileStream = new FileStream(xmlTimeStamp, FileMode.Create))
                    {
                        var ser = new XmlSerializer(typeof(DateTime));
                        ser.Serialize(fileStream, dtZapis);
                    }
                }
                else
                {
                    using (var fileStream = new FileStream(xmlTimeStamp, FileMode.Open))
                    {
                        var ser = new XmlSerializer(typeof(DateTime));
                        dtZapis = (DateTime)ser.Deserialize(fileStream);
                    }
                }
            }
            catch { }

            return dtZapis;
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

        public List<string> ZoznamSubory(string cesta, DateTime dtZaciatok)
        {
            List<string> subory = new List<string>();

            foreach (FileSystemInfo file in new DirectoryInfo(cesta).GetFiles("*.json", SearchOption.AllDirectories))
            {
                if (File.GetLastWriteTime(file.FullName) > dtZaciatok)
                    subory.Add(file.FullName);
            }

            return subory;
        }

        public void OdsunSpracovanySubor(string subor)
        {
            string ciel = xmle.SpracovanyPriecinok + "\\" + Path.GetFileName(subor);

            if (File.Exists(ciel))
                File.Delete(ciel);

            File.Move(subor, xmle.SpracovanyPriecinok + "\\" + Path.GetFileName(subor));
        }

        public void Start()
        {
            while (true)
            {
                BarValue(0);
                Info("Analyzujem nastavenia v " + xmlFilename);
                while (!Deserialize())
                {
                    Info("Chyba, snazim sa znova prečitať " + xmlFilename);
                    Thread.Sleep(CakajNaOpakuj * 1000);
                }

                Step();
                List<string> subory = new List<string>();
                DateTime dtZaciatok = TimeStampExchange(DateTime.MinValue, false);

                foreach (DirectoryInfo adresar in new DirectoryInfo(xmle.ZdrojovyPriecinok).GetDirectories())
                {
                    Info("Zisťujem počet súborov v " + adresar.FullName);
                    Step();
                    subory.AddRange(ZoznamSubory(adresar.FullName, dtZaciatok));
                    Thread.Sleep(500);
                }

                TimeStampExchange(DateTime.Now, true);
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

                // nakoniec pockame pred dalsim spustenim
                Thread.Sleep(xmle.periodaInt * 1000);
            }
        }

        public void Spracuj(string subor)
        {
            Thread.Sleep(500);
            //string jsonString = File.ReadAllText(@"Test\2112829x18x18972x1x24\2112829x18x18972x1x24xinfo.json");
            //JsonValue json = JsonValue.Parse(jsonString);

            OdsunSpracovanySubor(subor);
        }
    }
}
