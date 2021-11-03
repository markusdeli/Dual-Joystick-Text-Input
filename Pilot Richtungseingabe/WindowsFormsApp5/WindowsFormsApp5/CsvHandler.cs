using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp5
{
    class CsvHandler
    {
        private string name;
        private string age;
        private string gender;
        private int controllerExp;
        private List<string> csvContent = new List<string>();

        public CsvHandler(string name, string age, string gender, int controllerExp)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.controllerExp = controllerExp;
            csvContent.Add("Name:" + name);
            csvContent.Add("Age:" + age);
            csvContent.Add("Gender:" + gender);
            csvContent.Add("Experience Level:" + controllerExp.ToString());
        }

        public void SaveActualDirections(int trueDir, int inputDir)
        {
            csvContent.Add(trueDir.ToString());
            csvContent.Add(inputDir.ToString());
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
