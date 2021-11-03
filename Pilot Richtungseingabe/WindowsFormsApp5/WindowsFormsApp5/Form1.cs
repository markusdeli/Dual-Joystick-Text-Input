using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private DirectionGenerator directions = new DirectionGenerator(20);
        private ToolBox tools = new ToolBox();
        private List<int> res = new List<int>();
        private int lastElement = 0;
        private int trueValue = 0;
        private int inputValue = 0;
        private CsvHandler csv;

        public Form1()
        {
            InitializeComponent();
            res = directions.GetDirections();
            pictureBox1.Image = Image.FromFile(tools.ActualPath(res.ElementAt(lastElement)));
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = "Gib die folgenden Richtungen am Controller ein!";
            label1.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            SetInputFields();
            KillControllerTask();
            StartController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                label8.Visible = false;
                inputValue = tools.KeyToId(textBox1.Text);
                trueValue = res.ElementAt(lastElement);
                textBox1.Text = "";
                if (GetJoy(inputValue) == GetJoy(trueValue))
                {
                    lastElement++;
                    if (lastElement < res.Count)
                    {
                        pictureBox1.Image = Image.FromFile(tools.ActualPath(res.ElementAt(lastElement)));
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        csv.SaveActualDirections(trueValue, inputValue);
                    }
                    else
                    {
                        pictureBox1.Image = Image.FromFile("white.png");
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        label1.Text = "Danke für deine Teilnahme!";
                        csv.SaveCsv();
                        KillControllerTask();
                    }
                }
                else
                {
                    label8.Visible = true;
                    label8.Text = "Falscher Joystick!";
                }
            }
        }

        private int GetJoy(int input)
        {
            if (input < 9)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private void SetInputFields()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            listBox1.Items.Add("männlich");
            listBox1.Items.Add("weiblich");
            listBox1.Items.Add("divers");
            listBox2.Items.Add("Ich habe sehr viel Erfahrung (bspw. regelmäßiges Spielen)");
            listBox2.Items.Add("Ich habe Erfahrung (bspw. gelegentliches Spielen)");
            listBox2.Items.Add("Ich habe kaum Erfahrung (bspw. selten gespielt)");
            listBox2.Items.Add("Ich habe keine Erfahrung (noch nie einen Controller verwendet)");
            label6.Text = "Bitte fülle die folgenden Felder aus!";
            label2.Text = "Name:";
            label3.Text = "Alter:";
            label4.Text = "Geschlecht:";
            label5.Text = "Wie viel Erfahrung liegt in der Verwendung von Controllern vor?";
            button1.Text = "Bestätigen";
            label7.Visible = false;
            label8.Visible = false;
        }

        private void SwitchToExercise()
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button1.Visible = false;
            label1.Visible = true;
            pictureBox1.Visible = true;
            textBox1.Visible = true;
            label7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            if(textBox2.Text != "" && textBox3.Text != "" && int.TryParse(textBox3.Text, out number) && listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
            {
                csv = new CsvHandler(textBox2.Text, textBox3.Text, listBox1.Text, ExpToValue(listBox2.Text));
                SwitchToExercise();
                textBox1.Select();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Überprüfe die Eingabefelder!";
            }
        }

        private int ExpToValue(string exp)
        {
            int res = -1;
            switch (exp)
            {
                case "Ich habe sehr viel Erfahrung (bspw. regelmäßiges Spielen)":
                    res = 3;
                    break;
                case "Ich habe Erfahrung (bspw. gelegentliches Spielen)":
                    res = 2;
                    break;
                case "Ich habe kaum Erfahrung (bspw. selten gespielt)":
                    res = 1;
                    break;
                case "Ich habe keine Erfahrung (noch nie einen Controller verwendet)":
                    res = 0;
                    break;
            }
            return res;
        }

        private void StartController()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\marku\AppData\Local\Programs\Python\Python38-32\python.exe";
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
                if(process.ProcessName == "python")
                {
                    process.Kill();
                }
            }
        }
    }
}

