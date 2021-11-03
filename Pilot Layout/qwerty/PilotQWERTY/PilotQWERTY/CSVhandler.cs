using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotQWERTY
{
    class CSVhandler
    {
        private List<string> csvContent = new List<string>();
        private string name;
        private string path;

        public CSVhandler(string name)
        {
            this.name = name;
            this.path = "results.txt";
            csvContent.Add(this.name);
        }

        public CSVhandler(string name, string path)
        {
            this.name = name;
            this.path = path;
            csvContent.Add(this.name);
        }

        public void addCSVContent(string content)
        {
            csvContent.Add(content);
        }


        public void SaveCsv()
        {
            string csv = String.Join(";", csvContent.ToArray());
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(csv);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(csv);
                }
            }
        }
    }
}
