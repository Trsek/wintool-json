using System;

namespace WinTool_json.Models
{
    [Serializable]
    public class Priklady
    {
        public string parameter { get; set; }
        public string hodnota { get; set; }

        public override string ToString()
        {
            return "parameter=" + parameter
               + ", hodnota=" + hodnota;
        }
    }
}
