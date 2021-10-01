using System;
using System.IO;
using System.Json;
using System.Reflection;
using System.Windows.Forms;

namespace WinTool_json
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string GetRunningVersion()
        {
            try
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            catch { }
            return "";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelCopyright.Text += ", ver." + GetRunningVersion();
        }

        private void labelCopyright_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://trsek.com/curriculum");
        }
    }
}
