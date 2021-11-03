using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class ToolBox
    {
        public string ActualPath(int id)
        {
            string res = "";
            switch (id)
            {
                case 1:
                    res = "LL.png";
                    break;
                case 2:
                    res = "LLU.png";
                    break;
                case 3:
                    res = "LU.png";
                    break;
                case 4:
                    res = "LRU.png";
                    break;
                case 5:
                    res = "LR.png";
                    break;
                case 6:
                    res = "LRD.png";
                    break;
                case 7:
                    res = "LD.png";
                    break;
                case 8:
                    res = "LLD.png";
                    break;
                case 9:
                    res = "RL.png";
                    break;
                case 10:
                    res = "RLU.png";
                    break;
                case 11:
                    res = "RU.png";
                    break;
                case 12:
                    res = "RRU.png";
                    break;
                case 13:
                    res = "RR.png";
                    break;
                case 14:
                    res = "RRD.png";
                    break;
                case 15:
                    res = "RD.png";
                    break;
                case 16:
                    res = "RLD.png";
                    break;
            }
            return res;
        }

        public int KeyToId(string key)
        {
            int res = 0;
            switch (key)
            {
                case "A":
                    res = 2;
                    break;
                case "B":
                    res = 3;
                    break;
                case "C":
                    res = 4;
                    break;
                case "D":
                    res = 5;
                    break;
                case "E":
                    res = 6;
                    break;
                case "F":
                    res = 7;
                    break;
                case "G":
                    res = 8;
                    break;
                case "H":
                    res = 1;
                    break;
                case "I":
                    res = 10;
                    break;
                case "J":
                    res = 11;
                    break;
                case "K":
                    res = 12;
                    break;
                case "L":
                    res = 13;
                    break;
                case "M":
                    res = 14;
                    break;
                case "N":
                    res = 15;
                    break;
                case "O":
                    res = 16;
                    break;
                case "P":
                    res = 9;
                    break;
            }
            return res;
        }
    }
}
