using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    class WordGenerator
    {
        private int wordLen;

        private string[] tokens = { "A", "D", "E", "F", "P", "Q", "T", "U", "I", "J", "M", "N", "V", "X", "Y", "Z" };

        public WordGenerator(int wordLen)
        {
            this.wordLen = wordLen;
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

        private readonly Random random = new Random();

        private int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
