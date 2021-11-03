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

     
namespace PilotQWERTY
{
    public partial class Form1 : Form
    {
        private int mode = 0;

        private WordGenerator wordGen = new WordGenerator(5);

        private CSVhandler csv;

        private int WordCount = 9;

        private int TestWordCount = 2;

        private int deleteCount = 0;

        private string inputs = "";

        private string word;

        private string time;

        private bool checkbox = false;

        private string name;

        private Stopwatch watch = new Stopwatch();

        private int state1 = 0;
        private int state2 = 0;

        private string[,] paths = { { "pictures/U.png", "pictures/X.png" }, { "pictures/Q.png", "pictures/G.png" }, { "pictures/W.png", "pictures/H.png" }, { "pictures/_1.png", "pictures/_2.png" }, { "pictures/E.png", "pictures/J.png" }, { "pictures/R.png", "pictures/K.png" }, { "pictures/T.png", "pictures/L.png" }, { "pictures/Y.png", "pictures/Z.png" }, { "pictures/F.png", "pictures/2.png" }, { "pictures/I.png", "pictures/C.png" }, { "pictures/O.png", "pictures/V.png" }, { "pictures/P.png", "pictures/B.png" }, { "pictures/A.png", "pictures/N.png" }, { "pictures/S.png", "pictures/M.png" }, { "pictures/D.png", "pictures/2.png" }, { "pictures/-1.png", "pictures/-2.png" }, { "pictures/1.png", "pictures/2.png" } };


        public Form1()
    {
            InitializeComponent();
            label1.Text = "Gib die folgenden Zeichenfolgen ein!";
            pictureBox1.Image = Image.FromFile("pictures/1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            word = wordGen.getPhrase();
            label2.Text = word;
            button1.Text = "Bestätigen";
            checkBox1.Text = "Letztes System?";

            KillControllerTask();
            StartController();
        }

    private void Form1_Load(object sender, EventArgs e)
    {

    }


    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
            if (keyData == Keys.F1)//LLU
            {
                state1 = 1;
                pictureBox1.Image = Image.FromFile(paths[0, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(1));
                //inputs += getString(1);
                return true;
            }
            else if (keyData == Keys.F2)//LU
            {
                state1 = 2;
                pictureBox1.Image = Image.FromFile(paths[1, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(2));
                //inputs += getString(2);
                return true;
            }
            else if (keyData == Keys.F3)//LRU
            {
                state1 = 3;
                pictureBox1.Image = Image.FromFile(paths[2, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(3));
                //inputs += getString(3);
                return true;
            }
            else if (keyData == Keys.F4)//LR
            {
                state1 = 4;
                pictureBox1.Image = Image.FromFile(paths[3, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(4));
                //inputs += getString(4);
                return true;
            }
            else if (keyData == Keys.F5)//LRD
            {
                state1 = 5;
                pictureBox1.Image = Image.FromFile(paths[4, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(5));
                //inputs += getString(5);
                return true;
            }
            else if (keyData == Keys.F6)//LD
            {
                state1 = 6;
                pictureBox1.Image = Image.FromFile(paths[5, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(6));
                //inputs += getString(6);
                return true;
            }
            else if (keyData == Keys.F7)//LLD
            {
                state1 = 7;
                pictureBox1.Image = Image.FromFile(paths[6, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(7));
                //inputs += getString(7);
                return true;
            }
            else if (keyData == Keys.F8)//LL
            {
                state1 = 8;
                pictureBox1.Image = Image.FromFile(paths[7, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(8));
                //inputs += getString(8);
                return true;
            }
            else if (keyData == Keys.F9)//RLU
            {
                state2 = 9;
                pictureBox1.Image = Image.FromFile(paths[8, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(9));
                //inputs += getString(9);
                return true;
            }
            else if (keyData == Keys.F10)//RU
            {
                state2 = 10;
                pictureBox1.Image = Image.FromFile(paths[9, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(10));
                //inputs += getString(10);
                return true;
            }
            else if (keyData == Keys.F11)//RRU
            {
                state2 = 11;
                pictureBox1.Image = Image.FromFile(paths[10, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(11));
                //inputs += getString(11);
                return true;
            }
            else if (keyData == Keys.F12)//RR
            {
                state2 = 12;
                pictureBox1.Image = Image.FromFile(paths[11, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(12));
                //inputs += getString(12);
                return true;
            }
            else if (keyData == Keys.F13)//RRD
            {
                state2 = 13;
                pictureBox1.Image = Image.FromFile(paths[12, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(13));
                //inputs += getString(13);
                return true;
            }
            else if (keyData == Keys.F14)//RD
            {
                state2 = 14;
                pictureBox1.Image = Image.FromFile(paths[13, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(14));
                //inputs += getString(14);
                return true;
            }
            else if (keyData == Keys.F15)//RLD
            {
                state2 = 15;
                pictureBox1.Image = Image.FromFile(paths[14, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(15));
                //inputs += getString(15);
                return true;
            }
            else if (keyData == Keys.F16)//RL
            {
                state2 = 16;
                pictureBox1.Image = Image.FromFile(paths[15, mode]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.AppendText(getString(16));
                //inputs += getString(16);
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
                        KillControllerTask();
                        textBox1.Visible = false;
                        label1.Text = "Danke für die Teilnahme!";
                        label2.Visible = false;
                        pictureBox1.Visible = false;
                        FormPostTask postTaskForm = new FormPostTask(checkbox, name);
                        postTaskForm.Show();
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
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    private string getString(int key)
    {
        string[,] results = { { "U", "X" }, { "Q", "G" }, { "W", "H" }, { "0", "0" }, { "E", "J" }, { "R", "K" }, { "T", "L" }, { "Y", "Z" }, { "F", "" }, { "I", "C" }, { "O", "V" }, { "P", "B" }, { "A", "N" }, { "S", "M" }, { "D", "" }, { "1", "1" } };
        return results[key - 1, mode];
    }

    private void button1_Click(object sender, EventArgs e)
    {
            if (textBox2.Text != "")
            {
                name = textBox2.Text;
                csv = new CSVhandler(name);
                textBox2.Visible = false;
                button1.Visible = false;
                watch.Start();

                if (checkBox1.Checked)
                {
                    checkbox = true;
                }
                checkBox1.Visible = false;
            }
        }

    private void StartController()
    {
        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\Users\marku\AppData\Local\Programs\Python\Python38-32\python.exe";// Python37
        var script = @"pythonProject\main.py";
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


    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                name = textBox2.Text;
                csv = new CSVhandler(name);
                textBox2.Visible = false;
                button1.Visible = false;
                watch.Start();

                if (checkBox1.Checked)
                {
                    checkbox = true;
                }
                checkBox1.Visible = false;
            }
        }
    }
}