using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinTool_json.Models;

namespace WinTool_json
{
    public class Spracovanie
    {
        public Label labelSpracovavam = new Label();
        public ProgressBar progressBar = new ProgressBar();

        public string xmlFilename = "wintool.xml";

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

        private void RestartBar()
        {
            try
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = 0;
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
                    RestartBar();
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

        public void Start()
        {
            while (true)
            {
                RestartBar();
                Info("Analyzujem nastavenia" + xmlFilename);
                while (!Deserialize())
                {
                    Info("Chyba, snazim sa znova prečitať " + xmlFilename);
                    Thread.Sleep(CakajNaOpakuj * 1000);
                }

                Step();
                Info("Zisťujem počet súborov v " + xmle.ZdrojovyPriecinok);
                Thread.Sleep(500);

                Info("Koniec");

                // nakoniec pockame pred dalsim spustenim
                Thread.Sleep(xmle.periodaInt * 1000);
            }
        }

        //string jsonString = File.ReadAllText(@"Test\2112829x18x18972x1x24\2112829x18x18972x1x24xinfo.json");
        //JsonValue json = JsonValue.Parse(jsonString);
    }
}
