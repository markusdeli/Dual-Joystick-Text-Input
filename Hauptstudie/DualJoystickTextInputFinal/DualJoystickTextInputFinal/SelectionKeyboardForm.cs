using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace DualJoystickTextInputFinal
{
    public partial class SelectionKeyboardForm : Form
    {
        private Button[,] buttons = new Button[4, 10];

        private int stateButtonX = 0;
        private int stateButtonY = 0;

        private WordGenerator wordGen = new WordGenerator();

        private CSVhandler csv;

        private int WordCount = 14;

        private int TestWordCount = 2;

        private int deleteCount = 0;

        private string inputs = "";

        private string word;

        private int actionCount = 0;

        private string time;

        private bool isPaused = true;

        private CSVhandler cs;

        private Stopwatch watch = new Stopwatch();

        public SelectionKeyboardForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            SetButtonArray();
            SetButtonText();
            SetButtonPictures();
            word = wordGen.getPhrase();
            label1.Text = "Bitte gib die folgenden Sätze ein!";
            label2.Text = word;
            label3.Text = "Drücke Y um zu starten";
            string name = GetName();
            csv = new CSVhandler(name, "results/resultsSelection.txt", @"C:\Users\" + GetPath1() +@"\Desktop\results\resultsSelection.txt");
            cs = new CSVhandler(name, "results/actionCountSelection.txt", @"C:\Users\" + GetPath1() + @"\Desktop\results\actionCountSelection.txt");
            KillControllerTask();
            StartController();
        }

        private void StartWatch()
        {
            watch.Start();
            isPaused = false;
            label3.Text = "Pausiert";
            label3.Visible = false;
        }

        private void PauseWatch()
        {
            watch.Stop();
            isPaused = true;
            label3.Text = "Pausiert";
            label3.Visible = true;
        }

        private string GetName()
        {
            string name = "XYZ";
            if (File.Exists("name.txt"))
            {
                using (StreamReader sw = new StreamReader("name.txt"))
                {
                    name = sw.ReadLine();
                    sw.Close();
                }
            }
            return name;
        }
        

        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 0);
                return true;
            }
            if (keyData == Keys.Down && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 1);
                return true;
            }
            if (keyData == Keys.Left && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 2);
                return true;
            }
            if (keyData == Keys.Up && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 3);
                return true;
            }
            if (keyData == Keys.F1 && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 4);
                return true;
            }
            if (keyData == Keys.F2 && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 5);
                return true;
            }
            if (keyData == Keys.F3 && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 6);
                return true;
            }
            if (keyData == Keys.F4 && isPaused == false)
            {
                ManageButtonFocus(stateButtonX, stateButtonY, 7);
                return true;
            }
            if (keyData == Keys.F18 && isPaused == false)
            {
                buttons[stateButtonY, stateButtonX].PerformClick();
                actionCount++;
                return true;
            }
            if(keyData == Keys.F7)
            {
                if (isPaused)
                {
                    StartWatch();
                }
                else
                {
                    PauseWatch();
                }
                return true;
            }
            if (keyData == Keys.F6 && isPaused == false)//Confirm (START)
            {
                if (TestWordCount != 0)
                {
                    TestWordCount--;
                    word = wordGen.getPhrase();
                    inputs = "";
                    watch.Restart();
                    label2.Text = word;
                    textBox1.Text = "";
                }
                else
                {
                    if (WordCount > 0)
                    {
                        csv.addCSVContent(word);
                        word = wordGen.getPhrase();
                        csv.addCSVContent(deleteCount.ToString());
                        deleteCount = 0;
                        csv.addCSVContent(inputs);
                        inputs = "";
                        csv.addCSVContent(textBox1.Text);
                        cs.addCSVContent(actionCount.ToString());
                        actionCount = 0;
                        textBox1.Text = "";
                        label2.Text = word;
                        watch.Stop();
                        time = watch.Elapsed.ToString();
                        csv.addCSVContent(time);
                        watch.Restart();
                        WordCount--;
                    }
                    else
                    {
                        watch.Stop();
                        time = watch.Elapsed.ToString();
                        csv.addCSVContent(word);
                        csv.addCSVContent(deleteCount.ToString());
                        csv.addCSVContent(inputs);
                        csv.addCSVContent(textBox1.Text);
                        csv.addCSVContent(time);
                        csv.SaveCsv();
                        cs.addCSVContent(actionCount.ToString());
                        cs.SaveCsv();
                        KillControllerTask();
                        textBox1.Visible = false;
                        label1.Text = "Danke für die Teilnahme!";
                        SetButtonInvisible();
                        label2.Visible = false;
                        Timer t1 = new Timer();
                        t1.Interval = 3000; 
                        t1.Tick += new EventHandler(t1_Tick); 
                        t1.Start();
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void t1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmInput()
        {
            label2.Text = wordGen.getPhrase();
            textBox1.Text = "";
        }

        private void ManageButtonFocus(int stateX, int stateY, int dir)
        {
            int[] tmp = GetCurrentButtonPosition(stateX, stateY, dir);
            stateButtonX = tmp[0];
            stateButtonY = tmp[1];
            actionCount++;
            buttons[stateButtonY, stateButtonX].Focus();
        }

        private int[] GetCurrentButtonPosition(int posX, int posY, int dir)
        {
            int x = posX;
            int y = posY;
            if (dir == 0)//Right
            {
                if (x == 9)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
            }
            else if (dir == 1)//Down
            {
                if (y == 3)
                {
                    y = 0;
                }
                else
                {
                    y++;
                }
            }
            else if (dir == 2)//Left
            {
                if (x == 0)
                {
                    x = 9;
                }
                else
                {
                    x--;
                }

            }
            else if (dir == 3)//Up
            {
                if (y == 0)
                {
                    y = 3;
                }
                else
                {
                    y--;
                }
            }
            else if (dir == 4)//right down
            {
                if (x == 9)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                if (y == 3)
                {
                    y = 0;
                }
                else
                {
                    y++;
                }
            }
            else if (dir == 5)//left down
            {
                if (x == 0)
                {
                    x = 9;
                }
                else
                {
                    x--;
                }
                if (y == 3)
                {
                    y = 0;
                }
                else
                {
                    y++;
                }
            }
            else if (dir == 6)//left up
            {
                if (x == 0)
                {
                    x = 9;
                }
                else
                {
                    x--;
                }
                if (y == 0)
                {
                    y = 3;
                }
                else
                {
                    y--;
                }
            }
            else if (dir == 7)//right up
            {
                if (x == 9)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                if (y == 0)
                {
                    y = 3;
                }
                else
                {
                    y--;
                }
            }
            int[] res = { x, y };
            return res;
        }

        private void SetButtonArray()
        {
            buttons[0, 0] = button1;
            buttons[0, 1] = button2;
            buttons[0, 2] = button3;
            buttons[0, 3] = button4;
            buttons[0, 4] = button5;
            buttons[0, 5] = button6;
            buttons[0, 6] = button7;
            buttons[0, 7] = button8;
            buttons[0, 8] = button9;
            buttons[0, 9] = button10;
            buttons[1, 0] = button20;
            buttons[1, 1] = button19;
            buttons[1, 2] = button18;
            buttons[1, 3] = button17;
            buttons[1, 4] = button16;
            buttons[1, 5] = button15;
            buttons[1, 6] = button14;
            buttons[1, 7] = button13;
            buttons[1, 8] = button12;
            buttons[1, 9] = button11;
            buttons[2, 0] = button30;
            buttons[2, 1] = button29;
            buttons[2, 2] = button28;
            buttons[2, 3] = button27;
            buttons[2, 4] = button26;
            buttons[2, 5] = button25;
            buttons[2, 6] = button24;
            buttons[2, 7] = button23;
            buttons[2, 8] = button22;
            buttons[2, 9] = button21;
            buttons[3, 0] = button31;
            buttons[3, 1] = button31;
            buttons[3, 2] = button31;
            buttons[3, 3] = button31;
            buttons[3, 4] = button31;
            buttons[3, 5] = button31;
            buttons[3, 6] = button31;
            buttons[3, 7] = button31;
            buttons[3, 8] = button31;
            buttons[3, 9] = button31;
        }

        private void SetButtonText()
        {
            button1.Text = "Q";
            button2.Text = "W";
            button3.Text = "E";
            button4.Text = "R";
            button5.Text = "T";
            button6.Text = "Y";
            button7.Text = "U";
            button8.Text = "I";
            button9.Text = "O";
            button10.Text = "P";
            button20.Text = "A";
            button19.Text = "S";
            button18.Text = "D";
            button17.Text = "F";
            button16.Text = "G";
            button15.Text = "H";
            button14.Text = "J";
            button13.Text = "K";
            button12.Text = "L";
            button11.Text = "🠔";
            button30.Text = "Z";
            button29.Text = "X";
            button28.Text = "C";
            button27.Text = "V";
            button26.Text = "B";
            button25.Text = "N";
            button24.Text = "M";
            button23.Text = "_";
            button22.Text = "_";
            button21.Text = "_";

            button31.Text = "_";
            button31.Image = Image.FromFile("pictures/button.png");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void SetButtonPictures()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    buttons[i, y].Image = Image.FromFile("pictures/button.png");
                    button1.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

        }

        private void SetButtonInvisible()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int y = 0; y < buttons.GetLength(1); y++)
                {
                    buttons[i, y].Visible = false;
                }
            }

        }

        private void StartController()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\" + GetPath1() + @"\AppData\Local\Programs\Python\" + GetPath2() + @"\python.exe";// Python37 Python38-32
            var script = @"python\selection\pythonProject\main.py";
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            Process.Start(psi);
        }

        private void KillControllerTask()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "python")
                {
                    process.Kill();
                }
            }
        }

        private void SelectionKeyboardForm_Load(object sender, EventArgs e)
        {

        }

        private string GetPath1()
        {
            string tmp1 = "mark4u";
            if (File.Exists("path1.txt"))
            {
                using (StreamReader sr = new StreamReader("path1.txt"))
                {
                    tmp1 = sr.ReadLine();
                }
            }
            return tmp1;
        }

        private string GetPath2()
        {
            string tmp1 = "python347";
            if (File.Exists("path2.txt"))
            {
                using (StreamReader sr = new StreamReader("path2.txt"))
                {
                    tmp1 = sr.ReadLine();
                }
            }
            return tmp1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "Q";
            inputs += "Q";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "W";
            inputs += "W";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "I";
            inputs += "I";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "E";
            inputs += "E";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "R";
            inputs += "R";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "T";
            inputs += "T";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "Y";
            inputs += "Y";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "U";
            inputs += "U";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "O";
            inputs += "O";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "P";
            inputs += "P";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "A";
            inputs += "A";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "S";
            inputs += "S";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "D";
            inputs += "D";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "F";
            inputs += "F";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "G";
            inputs += "G";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "H";
            inputs += "H";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "J";
            inputs += "J";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "K";
            inputs += "K";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "L";
            inputs += "L";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, (textBox1.TextLength - 1));
                inputs += "!";
                deleteCount++;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "Z";
            inputs += "Z";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "X";
            inputs += "X";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "C";
            inputs += "C";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "V";
            inputs += "V";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "B";
            inputs += "B";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "N";
            inputs += "N";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "M";
            inputs += "M";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " ";
            inputs += " ";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " ";
            inputs += " ";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " ";
            inputs += " ";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " ";
            inputs += " ";
        }
    }
}
