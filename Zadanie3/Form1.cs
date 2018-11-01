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

namespace Zadanie3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                int n = int.Parse(textBox1.Text);
                long l1 = 1;
                long l2 = 0;
                long l3 = 0;
                double progress = 0;

                if (n == 0)
                {
                    l2 = 0;
                    progress = 100;
                    backgroundWorker1.ReportProgress((int)progress);
                }
                else if (n == 1)
                {
                    l2 = 1;
                    progress = 100;
                    backgroundWorker1.ReportProgress((int)progress);
                }
                else if (n > 1)
                {
                    for (int i = 1; i < n + 1; i++)
                    {
                        l3 = l1 + l2;
                        l1 = l2;
                        l2 = l3;
                        progress = (i / (double)n) * 100;
                        backgroundWorker1.ReportProgress((int)progress);
                    }

                }
                e.Result = l2;
            }
            catch (Exception ex) {
                MessageBox.Show("Wprowadź liczbę");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox2.Clear();
            textBox2.Text += e.Result;
        }
    }
}
