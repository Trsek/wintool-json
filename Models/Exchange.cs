using System;
using System.Collections.Generic;

namespace WinTool_json.Models
{
    [Serializable]
    public class Exchange
    {
        public List<Proces> proces { get; set; } = new List<Proces>();
        public List<Podmienky> podmienky { get; set; } = new List<Podmienky>();
        public string perioda { get; set; }
        public string ZdrojovyPriecinok { get; set; }
        public string SpracovanyPriecinok { get; set; }

        public int periodaInt
        {
            get
            {
                int periodaInt = 0;
                Int32.TryParse(perioda, out periodaInt);

                return periodaInt;
            }
        }
    }
}
