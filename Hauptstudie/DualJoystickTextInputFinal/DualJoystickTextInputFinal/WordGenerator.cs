using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DualJoystickTextInputFinal
{
    class WordGenerator
    {
        private StreamReader file = new StreamReader("phrases2.txt");

        private string[] lines;

        public WordGenerator()
        {
            lines = getLines();
        }

        public string getPhrase()
        {
            return lines[RandomInt(0, lines.Length - 1)];
        }

        private string[] getLines()
        {
            string line;
            List<string> lines = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line.ToUpper());
            }
            return lines.ToArray();
        }

        private readonly Random random = new Random();

        private int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

    }
}
