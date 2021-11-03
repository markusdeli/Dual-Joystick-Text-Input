using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class DirectionGenerator
    {
        private int samples = 1;


        private List<int> result = new List<int>();
        private int[] directions = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        public DirectionGenerator(int Samples)
        {
            this.samples = Samples;
            fillList();
        }

        private void fillList()
        {
            List<int> tmp = new List<int>();
            for (int i = 0; i < directions.Length; i++)
            {
                for (int y = 0; y < samples; y++)
                {
                    tmp.Add(directions[i]);
                }
            }
            result = Shuffle(tmp);
        }

        private List<int> Shuffle(List <int> liste)
        {
            List<int> tmp = new List<int>();
            Random random = new Random();
            int count = liste.Count;
            for (int i = 0; i < count; i++)
            {
                int rdm = random.Next(liste.Count);
                tmp.Add(liste.ElementAt(rdm));
                liste.RemoveAt(rdm);
            }
            return tmp;
        }

        public List<int> GetDirections()
        {
            return result;
        }

    }
}
