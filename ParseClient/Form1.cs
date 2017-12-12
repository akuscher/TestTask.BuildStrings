using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        StringServiceClient myClient = new StringServiceClient();

        /// <summary>
        /// путь ко входному файлу
        /// </summary>
        string SourceFilePath { get; set; }

        /// <summary>
        /// кол-во строк
        /// </summary>
        int treatmentLineCount = 0;


        /// <summary>
        /// кол-во строк
        /// </summary>
        int sourceFileLineCount = 0;

        /// <summary>
        /// обновить строку счетчиков строк
        /// </summary>
        void updateLabelRecords()
        {
            label_Records.Invoke((MethodInvoker)delegate
            {

                label_Records.Text = sourceFileLineCount.ToString() + " \\ " + treatmentLineCount.ToString();
                label_Records.Refresh();
            });
        }

        void addResult(string a, string b)
        {
            richTextBox_results.Invoke((MethodInvoker)delegate
            {

                richTextBox_results.AppendText(">>> " + a);
                richTextBox_results.AppendText(Environment.NewLine);

                richTextBox_results.AppendText("<<< " + b);
                richTextBox_results.AppendText(Environment.NewLine);
                richTextBox_results.AppendText(Environment.NewLine);

            });
        }


        private void button_setSourceFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                SourceFilePath = of.FileName;
                getLineCount();
            }
            else
            {
                SourceFilePath = "";
            }
            textBox_SourceFilePath.Text = SourceFilePath;
        }

        void getLineCount()
        {

            Task task = new Task(() =>
            {
                sourceFileLineCount = 0;
                using (var reader = File.OpenText(SourceFilePath))
                {
                    while (reader.ReadLine() != null)
                    {
                        sourceFileLineCount++;
                    }
                }
                updateLabelRecords();
            });
            task.Start();

        }

        private void button_goParse_Click(object sender, EventArgs e)
        {
            treatmentLineCount = 0;
            progressBar1.Maximum = sourceFileLineCount;
            richTextBox_results.Clear();

            if (string.IsNullOrEmpty(SourceFilePath))
            {
                richTextBox_results.AppendText("Выберите файл");
                richTextBox_results.AppendText(Environment.NewLine);
                return;
            }


            Task task = new Task(() =>
            {
                try
                {

                    using (var reader = File.OpenText(SourceFilePath))
                    {
                        string s = null;
                        while ((s = reader.ReadLine()) != null)
                        {
                            addResult(s, myClient.getString(s));
                            treatmentLineCount++;
                            updateLabelRecords();

                            progressBar1.Invoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = treatmentLineCount;

                            });
                        }
                    }
                }

                catch (System.ServiceModel.EndpointNotFoundException ex)
                {
                    richTextBox_results.Invoke((MethodInvoker)delegate
                    {
                        richTextBox_results.AppendText(ex.Message);
                        richTextBox_results.AppendText(Environment.NewLine);
                    });
                }

                catch (Exception ex)
                {
                    richTextBox_results.Invoke((MethodInvoker)delegate
                    {
                        richTextBox_results.AppendText(ex.Message);
                        richTextBox_results.AppendText(Environment.NewLine);
                    });
                }

            });
            task.Start();
        }
    }
}
