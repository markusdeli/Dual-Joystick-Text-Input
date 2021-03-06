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

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private int mode = 0;

        private WordGenerator wordGen = new WordGenerator(5);

        private CSVhandler csv;

        private int WordCount = 19;

        private int TestWordCount = 10;

        private int deleteCount = 0;

        private string inputs = "";

        private string word;

        private string time;

        private Stopwatch watch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Gib die folgenden Zeichenfolgen ein!";
            pictureBox1.Image = Image.FromFile("Kreis1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            word = wordGen.getWord();
            label2.Text = word;
            button1.Text = "Bestätigen";
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
                textBox1.AppendText(getString(1));
                inputs += getString(1);
                return true;
            }
            else if (keyData == Keys.F2)//LU
            {
                textBox1.AppendText(getString(2));
                inputs += getString(2);
                return true;
            }
            else if (keyData == Keys.F3)//LRU
            {
                textBox1.AppendText(getString(3));
                inputs += getString(3);
                return true;
            }
            else if (keyData == Keys.F4)//LR
            {
                textBox1.AppendText(getString(4));
                inputs += getString(4);
                return true;
            }
            else if (keyData == Keys.F5)//LRD
            {
                textBox1.AppendText(getString(5));
                inputs += getString(5);
                return true;
            }
            else if (keyData == Keys.F6)//LD
            {
                textBox1.AppendText(getString(6));
                inputs += getString(6);
                return true;
            }
            else if (keyData == Keys.F7)//LLD
            {
                textBox1.AppendText(getString(7));
                inputs += getString(7);
                return true;
            }
            else if (keyData == Keys.F8)//LL
            {
                textBox1.AppendText(getString(8));
                inputs += getString(8);
                return true;
            }
            else if (keyData == Keys.F9)//RLU
            {
               
                return true;
            }
            else if (keyData == Keys.F10)//RU
            {
                mode = 1;
                pictureBox1.Image = Image.FromFile("Kreis2.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return true;
            }
            else if (keyData == Keys.F11)//RRU
            {
             
                return true;
            }
            else if (keyData == Keys.F12)//RR
            {
                mode = 2;
                pictureBox1.Image = Image.FromFile("Kreis3.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return true;
            }
            else if (keyData == Keys.F13)//RRD
            {
               
                return true;
            }
            else if (keyData == Keys.F14)//RD
            {
                mode = 3;
                pictureBox1.Image = Image.FromFile("Kreis4.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return true;
            }
            else if (keyData == Keys.F15)//RLD
            {
                
                return true;
            }
            else if (keyData == Keys.F16)//RL
            {

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
                if (textBox1.Text.Length == 5)
                {
                    if(TestWordCount != 0)
                    {
                        TestWordCount--;
                        word = wordGen.getWord();
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
                            word = wordGen.getWord();
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
                        }
                    }
                    

                }

                return true;
            }
            if (keyData == Keys.F19)//LS Release
            {
                return true;
            }
            if (keyData == Keys.F20)//LS Presses
            {
                return true;
            }
            if (keyData == Keys.Down)
            {
                mode = 0;
                pictureBox1.Image = Image.FromFile("Kreis1.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private string getString(int key)
        {
            string[,] results = { { "A", "" , "I", ""}, { "", "P", "", "V" }, { "", "Q", "J", "" }, { "D", "", "", "X" }, { "E", "", "M", "" }, { "F", "", "", "Y" }, { "", "T", "N", "" }, { "", "U", "", "Z" } };
            return results[key - 1, mode];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                csv = new CSVhandler(textBox2.Text);
                textBox2.Visible = false;
                button1.Visible = false;
                watch.Start();
            }
        }

        private void StartController()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\marku\AppData\Local\Programs\Python\Python37\python.exe";
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
    }
}
