using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DualJoystickTextInputFinal
{
    public partial class Form1 : Form
    {
        private int state = 0;

        private bool task1 = false;
        private bool task2 = false;

        public Form1()
        {
            InitializeComponent();
            KillControllerTask();
            WindowState = FormWindowState.Maximized;
            button1.Text = "Drücke A um die Subsession zu starten";
            state = GetLastState();
            KillControllerTask();
            StartController();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F18)
            {
                button1.PerformClick();
                return true;
            }
           return base.ProcessCmdKey(ref msg, keyData);
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

        private void Shutdown()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\" + GetPath1() + @"\AppData\Local\Programs\Python\" + GetPath2() + @"\python.exe";// Python37 Python38-32
            var script = @"python\pythonProject1\main.py";
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            Process.Start(psi);
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

        private int GetLastState()
        {
            string state = "XYZ";
            if (File.Exists("lastState.txt"))
            {
                using (StreamReader sw = new StreamReader("lastState.txt"))
                {
                    state = sw.ReadLine();
                    sw.Close();
                }
            }
            if (state == "1")
            {
                SetLastState("2");
                return 1;
            }
            else
            {
                SetLastState("1");
            }
            return 2;
        }

        private void SetLastState(string state)
        {
            if (File.Exists("lastState.txt"))
            {
                File.WriteAllText("lastState.txt", state);
                File.WriteAllText(@"C:\Users\" + GetPath1() + @"\Desktop\results\lastState.txt", state);
            }
        }
        

        private void StartSelectionKeyboard()
        {
            CSVhandler dateSelection = new CSVhandler(GetName(), "TimeSelectionKeyboard.txt", @"C:\Users\" + GetPath1() + @"\Desktop\results\TimeSelectionKeyboard.txt");
            DateTime dt = DateTime.Now;
            dateSelection.addCSVContent(dt.ToString());
            dateSelection.SaveCsv();
            KillControllerTask();
            SelectionKeyboardForm skForm = new SelectionKeyboardForm();
            skForm.ShowDialog();
            StartController();
        }

        private void StartCircleKeyboard()
        {
            CSVhandler dateSelection = new CSVhandler(GetName(), "TimeCircleKeyboard.txt", @"C:\Users\" + GetPath1() + @"\Desktop\results\TimeCircleKeyboard.txt");
            DateTime dt = DateTime.Now;
            dateSelection.addCSVContent(dt.ToString());
            dateSelection.SaveCsv();
            KillControllerTask();
            CircleKeyboard ckForm = new CircleKeyboard();
            ckForm.ShowDialog();
            StartController();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(task1 != true | task2 != true)
            {
                if (state == 1)
                {
                    KillControllerTask();
                    state = 2;
                    task1 = true;
                    StartSelectionKeyboard();
                }
                else if (state == 2)
                {
                    KillControllerTask();
                    state = 1;
                    task2 = true;
                    StartCircleKeyboard();
                    button1.Text = "Drücke A um fortzufahren";
                    
                }
                if (task1 & task2)
                {
                }
            }
            else if(task1 & task2)
            {
                KillControllerTask();
                Shutdown();
                this.Close();
            }
        }
    }
}
