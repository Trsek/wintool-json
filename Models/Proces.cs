using System;

namespace WinTool_json.Models
{
    [Serializable]
    public class Proces
    {
        public int id { get; set; }
        public string nazov { get; set; }

        public override string ToString()
        {
            return "id=" + id.ToString()
               + ", nazov=" + nazov;
        }
    }
}
