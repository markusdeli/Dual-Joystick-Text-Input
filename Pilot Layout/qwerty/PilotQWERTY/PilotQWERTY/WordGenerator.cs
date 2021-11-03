using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PilotQWERTY
{
    class WordGenerator
    {
        private int wordLen;

        private string[] tokens = { "A", "D", "E", "F", "P", "Q", "T", "U", "I", "J", "M", "N", "V", "X", "Y", "Z" };

        private StreamReader file = new StreamReader("phrases2.txt");

        private string[] lines;

        public WordGenerator(int wordLen)
        {
            this.wordLen = wordLen;
            lines = getLines();
        }

        public string getWord()
        {
            int index;
            string res = "";
            for (int i = 0; i < wordLen; i++)
            {
                index = RandomInt(0, 15);
                res += tokens[index];
            }
            return res;
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
