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
    public partial class CircleKeyboard : Form
    {
        private int mode = 0;

        private WordGenerator wordGen = new WordGenerator();

        private CSVhandler csv;

        private int WordCount = 14;

        private int TestWordCount = 2;

        private int deleteCount = 0;

        private int actionCount = 0;

        private string inputs = "";

        private string word;

        private string time;

        private bool isPaused = true;

        private string name;

        private CSVhandler cs;

        private Stopwatch watch = new Stopwatch();

        private int state1 = 0;
        private int state2 = 0;

        private string[,] paths = { { "pictures/G.png", "pictures/U.png" }, { "pictures/A.png", "pictures/O.png" }, { "pictures/B.png", "pictures/P.png" }, { "pictures/_1.png", "pictures/_2.png" }, { "pictures/C.png", "pictures/Q.png" }, { "pictures/D.png", "pictures/R.png" }, { "pictures/E.png", "pictures/S.png" }, { "pictures/F.png", "pictures/T.png" }, { "pictures/N.png", "pictures/2.png" }, { "pictures/H.png", "pictures/V.png" }, { "pictures/I.png", "pictures/W.png" }, { "pictures/J.png", "pictures/X.png" }, { "pictures/K.png", "pictures/Y.png" }, { "pictures/L.png", "pictures/Z.png" }, { "pictures/M.png", "pictures/2.png" }, { "pictures/-1.png", "pictures/-2.png" }, { "pictures/1.png", "pictures/2.png" } };


        public CircleKeyboard()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            label1.Text = "Gib die folgenden Zeichenfolgen ein!";
            pictureBox1.Image = Image.FromFile("pictures/1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            word = wordGen.getPhrase();
            label2.Text = word;
            label3.Text = "Drücke Y um zu starten";
            csv = new CSVhandler(GetName(), "results/resultsCircle.txt", @"C:\Users\" + GetPath1() + @"\Desktop\results\resultsCircle.txt");
            cs = new CSVhandler(name, "results/actionCountCircle.txt", @"C:\Users\" + GetPath1() + @"\Desktop\results\actionCountCircle.txt");
            KillControllerTask();
            StartController();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1 && isPaused == false)//LLU
            {
                state1 = 1;
                pictureBox1.Image = Image.FromFile(paths[0, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(1));
                //inputs += getString(1);
                return true;
            }
            else if (keyData == Keys.F2 && isPaused == false)//LU
            {
                state1 = 2;
                pictureBox1.Image = Image.FromFile(paths[1, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(2));
                //inputs += getString(2);
                return true;
            }
            else if (keyData == Keys.F3 && isPaused == false)//LRU
            {
                state1 = 3;
                pictureBox1.Image = Image.FromFile(paths[2, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(3));
                //inputs += getString(3);
                return true;
            }
            else if (keyData == Keys.F4 && isPaused == false)//LR
            {
                state1 = 4;
                pictureBox1.Image = Image.FromFile(paths[3, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(4));
                //inputs += getString(4);
                return true;
            }
            else if (keyData == Keys.F5 && isPaused == false)//LRD
            {
                state1 = 5;
                pictureBox1.Image = Image.FromFile(paths[4, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(5));
                //inputs += getString(5);
                return true;
            }
            else if (keyData == Keys.F6 && isPaused == false)//LD
            {
                state1 = 6;
                pictureBox1.Image = Image.FromFile(paths[5, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(6));
                //inputs += getString(6);
                return true;
            }
            else if (keyData == Keys.F7 && isPaused == false)//LLD
            {
                state1 = 7;
                pictureBox1.Image = Image.FromFile(paths[6, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(7));
                //inputs += getString(7);
                return true;
            }
            else if (keyData == Keys.F8 && isPaused == false)//LL
            {
                state1 = 8;
                pictureBox1.Image = Image.FromFile(paths[7, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(8));
                //inputs += getString(8);
                return true;
            }
            else if (keyData == Keys.F9 && isPaused == false)//RLU
            {
                state2 = 9;
                pictureBox1.Image = Image.FromFile(paths[8, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(9));
                //inputs += getString(9);
                return true;
            }
            else if (keyData == Keys.F10 && isPaused == false)//RU
            {
                state2 = 10;
                pictureBox1.Image = Image.FromFile(paths[9, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(10));
                //inputs += getString(10);
                return true;
            }
            else if (keyData == Keys.F11 && isPaused == false)//RRU
            {
                state2 = 11;
                pictureBox1.Image = Image.FromFile(paths[10, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(11));
                //inputs += getString(11);
                return true;
            }
            else if (keyData == Keys.F12 && isPaused == false)//RR
            {
                state2 = 12;
                pictureBox1.Image = Image.FromFile(paths[11, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(12));
                //inputs += getString(12);
                return true;
            }
            else if (keyData == Keys.F13 && isPaused == false)//RRD
            {
                state2 = 13;
                pictureBox1.Image = Image.FromFile(paths[12, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(13));
                //inputs += getString(13);
                return true;
            }
            else if (keyData == Keys.F14 && isPaused == false)//RD
            {
                state2 = 14;
                pictureBox1.Image = Image.FromFile(paths[13, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(14));
                //inputs += getString(14);
                return true;
            }
            else if (keyData == Keys.F15 && isPaused == false)//RLD
            {
                state2 = 15;
                pictureBox1.Image = Image.FromFile(paths[14, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(15));
                //inputs += getString(15);
                return true;
            }
            else if (keyData == Keys.F16 && isPaused == false)//RL
            {
                state2 = 16;
                pictureBox1.Image = Image.FromFile(paths[15, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                //textBox1.AppendText(getString(16));
                //inputs += getString(16);
                return true;
            }
            if (keyData == Keys.Left)
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
            if (keyData == Keys.Right)
            {
                if (state1 != 0)
                {
                    pictureBox1.Image = Image.FromFile(paths[16, mode]);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (state1 == 4)
                    {
                        textBox1.AppendText(" ");
                        inputs += " ";
                    }
                    else
                    {
                        textBox1.AppendText(getString(state1));
                        inputs += getString(state1);
                    }
                    state1 = 0;
                }
                return true;
            }
            if (keyData == Keys.Up)
            {
                if (state2 != 0)
                {
                    pictureBox1.Image = Image.FromFile(paths[16, mode]);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (state2 == 16)
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            textBox1.Text = textBox1.Text.Substring(0, (textBox1.TextLength - 1));
                            textBox1.SelectionStart = textBox1.Text.Length;
                            textBox1.SelectionLength = 0;
                            inputs += "!";
                            deleteCount++;
                        }
                    }
                    else
                    {
                        textBox1.AppendText(getString(state2));
                        inputs += getString(state2);
                    }
                    state2 = 0;
                }
                return true;
            }
            if (keyData == Keys.F17)//Delete
            {
                if (textBox1.TextLength > 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, (textBox1.TextLength - 1));
                    inputs += "!";
                    deleteCount++;
                }
                return true;
            }
            if (keyData == Keys.F18)//Confirm
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
                        label2.Visible = false;
                        pictureBox1.Visible = false;
                        Timer t1 = new Timer();
                        t1.Interval = 3000;
                        t1.Tick += new EventHandler(t1_Tick);
                        t1.Start();
                    }
                }
                return true;
            }
            if (keyData == Keys.F19)//LS Release
            {
                mode = 0;
                pictureBox1.Image = Image.FromFile(paths[16, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return true;
            }
            if (keyData == Keys.F20)//LS Presses
            {
                mode = 1;
                pictureBox1.Image = Image.FromFile(paths[16, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                actionCount++;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private string getString(int key)
        {
            string[,] results = { { "G", "U" }, { "A", "O" }, { "B", "P" }, { "0", "0" }, { "C", "Q" }, { "D", "R" }, { "E", "S" }, { "F", "T" }, { "N", "" }, { "H", "V" }, { "I", "W" }, { "J", "X" }, { "K", "Y" }, { "L", "Z" }, { "M", "" }, { "1", "1" } };
            return results[key - 1, mode];
        }



        private void StartController()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\"+ GetPath1() + @"\AppData\Local\Programs\Python\" + GetPath2() + @"\python.exe";//@"C:\Users\Stefan\AppData\Local\Programs\Python\Python39\python.exe";// Python37 Python38-32
            var script = @"python\circle\pythonProject\main.py";
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
        
        private string GetName()
        {
            string name = "XYZ";
            if (File.Exists("name.txt"))
            {
                using (StreamReader sw = new StreamReader("name.txt"))
                {
                    name = sw.ReadLine();
                }
            }
            return name;
        }

        private string GetPath1()
        {
            string tmp1 = "marku";
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
            string tmp1 = "python37";
            if (File.Exists("path2.txt"))
            {
                using (StreamReader sr = new StreamReader("path2.txt"))
                {
                    tmp1 = sr.ReadLine();
                }
            }
            return tmp1;
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

        void t1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CircleKeyboard_Load(object sender, EventArgs e)
        {

        }
    }
}
