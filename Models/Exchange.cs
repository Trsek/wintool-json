using System;
using System.Collections.Generic;

namespace WinTool_json.Models
{
    [Serializable()]
    public class Exchange
    {
        public List<Proces> proces { get; set; }
        public List<Podmienky> podmienky { get; set; }
        public string perioda { get; set; }
        public string ZdrojovyPriecinok { get; set; }
        public string SpracovanyPriecinok { get; set; }
    }
}
