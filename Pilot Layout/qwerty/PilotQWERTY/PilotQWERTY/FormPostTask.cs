using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotQWERTY
{
    public partial class FormPostTask : Form
    {
        private bool lastLayout;

        private string listRes;

        private int bestSystem = 0;

        private string name;

        private string feedback = "";

        public FormPostTask(bool lastLayout, string name)
        {
            InitializeComponent();
            this.lastLayout = lastLayout;
            this.name = name;
            label1.Text = "Wie schnell empfanden Sie das System?";
            button1.Text = "Bestätigen";
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            textBox1.Visible = false;
            for (int i = 1; i <= 10; i++)
            {
                string s = "";
                if (i == 1)
                {
                    s = " (Sehr langsam)";
                }
                else if (i == 10)
                {
                    s = " (Sehr schnell)";
                }
                listBox1.Items.Add(i + s);
            }
        }

        private void FormPostTask_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listRes = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
            label1.Text = "Danke für die Teilnahme!";
            button1.Visible = false;
            if (lastLayout)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox1.Image = Image.FromFile("pictures/a-z.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = Image.FromFile("pictures/qwerty.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = Image.FromFile("pictures/prob.png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                label1.Text = "Welches der drei Systeme hat Ihnen am besten Gefallen?";
            }
            else
            {
                saveToCSV();
            }
            if (lastLayout && bestSystem != 0)
            {
                feedback = textBox1.Text;
                textBox1.Visible = false;
                button1.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                label1.Text = "Danke für die Teilnahme!";
                saveToCSV();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bestSystem = 1;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label1.Text = "Hier können Sie Anmerkungen abgeben:";
            button1.Visible = true;
            textBox1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bestSystem = 3;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label1.Text = "Hier können Sie Anmerkungen abgeben:";
            button1.Visible = true;
            textBox1.Visible = true;
        }

        private void saveToCSV()
        {
            CSVhandler csv = new CSVhandler(name, "results_postTask.txt");
            csv.addCSVContent(listRes);
            if (lastLayout)
            {
                csv.addCSVContent("" + bestSystem);
                if (feedback != "")
                {
                    csv.addCSVContent(feedback);
                }
            }
            csv.SaveCsv();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bestSystem = 2;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label1.Text = "Hier können Sie Anmerkungen abgeben:";
            button1.Visible = true;
            textBox1.Visible = true;
        }
    }
}
