using System;
using System.IO;

namespace WinTool_json
{
    public class NLogLite
    {
        private string logFilename = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\wintool.log";
        private int MaxFileLen = 1000000;

        public void Clear()
        {
            File.Delete(logFilename);
        }

        public string TimeStamp()
        {
            return DateTime.Now.ToString("HH:mm:ss") + " -> ";
        }

        public void Save(string text)
        {
            if (Directory.Exists(Path.GetDirectoryName(logFilename)))
            {
                if (File.Exists(logFilename))
                {
                    if (new FileInfo(logFilename).Length > MaxFileLen)
                        File.Delete(logFilename);
                }

                File.AppendAllText(logFilename, TimeStamp() + text + Environment.NewLine);
            }
        }
    }
}
