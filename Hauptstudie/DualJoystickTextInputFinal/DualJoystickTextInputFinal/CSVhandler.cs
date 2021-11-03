using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualJoystickTextInputFinal
{
    class CSVhandler
    {
        private List<string> csvContent = new List<string>();
        private string name;
        private string path1;
        private string path2;

        public CSVhandler(string name)
        {
            this.name = name;
            this.path1 = "results.txt";
            csvContent.Add(this.name);
        }

        public CSVhandler(string name, string path1, string path2)
        {
            this.name = name;
            this.path1 = path1;
            this.path2 = path2;
            csvContent.Add(this.name);
        }

        public void addCSVContent(string content)
        {
            csvContent.Add(content);
        }


        public void SaveCsv()
        {
            string csv = String.Join(";", csvContent.ToArray());
            if (File.Exists(path1))
            {
                using (StreamWriter sw = File.AppendText(path1))
                {
                    sw.WriteLine(csv);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path1))
                {
                    sw.WriteLine(csv);
                    sw.Close();
                }
            }
            SaveCsv2();
        }

        public void SaveCsv2()
        {
            string csv = String.Join(";", csvContent.ToArray());
            if (File.Exists(path2))
            {
                using (StreamWriter sw = File.AppendText(path2))
                {
                    sw.WriteLine(csv);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path2))
                {
                    sw.WriteLine(csv);
                    sw.Close();
                }
            }
        }
    }
}
