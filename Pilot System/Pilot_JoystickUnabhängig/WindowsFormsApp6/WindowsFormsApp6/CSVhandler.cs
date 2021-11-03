using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    class CSVhandler
    {
        private List<string> csvContent = new List<string>();
        private string name;

        public CSVhandler(string name)
        {
            this.name = name;
            csvContent.Add(this.name);
        }

        public void addCSVContent(string content)
        {
            csvContent.Add(content);
        }
        

        public void SaveCsv()
        {
            string csv = String.Join(";", csvContent.ToArray());
            if (File.Exists("results.txt"))
            {
                using (StreamWriter sw = File.AppendText("results.txt"))
                {
                    sw.WriteLine(csv);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText("results.txt"))
                {
                    sw.WriteLine(csv);
                }
            }
        }
    }
}

