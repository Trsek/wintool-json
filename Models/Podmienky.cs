using System;

namespace WinTool_json.Models
{
    [Serializable]
    public class Podmienky
    {
        public const string CESTA_PDF = "Cesta PDF";
        public const string DUPLIKOVAT = "Duplikovať";
        public const string NAZOV_PDF = "Názov PDF";

        public int id_proces { get; set; }
        public string parameter { get; set; }
        public string hodnota { get; set; }
        public string funkcia { get; set; }

        public override string ToString()
        {
            return "id_proces=" + id_proces.ToString()
               + ", parameter=" + parameter
               + ", hodnota=" + hodnota
               + ", funkcia=" + funkcia;
        }
    }
}
