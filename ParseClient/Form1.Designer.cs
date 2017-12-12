namespace ParseClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_Records = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_goParse = new System.Windows.Forms.Button();
            this.textBox_SourceFilePath = new System.Windows.Forms.TextBox();
            this.button_setSourceFilePath = new System.Windows.Forms.Button();
            this.richTextBox_results = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button_goParse);
            this.panel1.Controls.Add(this.textBox_SourceFilePath);
            this.panel1.Controls.Add(this.button_setSourceFilePath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(1033, 79);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(727, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 51);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label_Records);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 21);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(4);
            this.panel5.Size = new System.Drawing.Size(302, 30);
            this.panel5.TabIndex = 4;
            // 
            // label_Records
            // 
            this.label_Records.AutoSize = true;
            this.label_Records.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Records.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Records.Location = new System.Drawing.Point(66, 4);
            this.label_Records.Name = "label_Records";
            this.label_Records.Size = new System.Drawing.Size(25, 17);
            this.label_Records.TabIndex = 5;
            this.label_Records.Text = "-/-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Записи:";
            // 
            // button_goParse
            // 
            this.button_goParse.Location = new System.Drawing.Point(90, 7);
            this.button_goParse.Name = "button_goParse";
            this.button_goParse.Size = new System.Drawing.Size(80, 43);
            this.button_goParse.TabIndex = 2;
            this.button_goParse.Text = "Обработать!";
            this.button_goParse.UseVisualStyleBackColor = true;
            this.button_goParse.Click += new System.EventHandler(this.button_goParse_Click);
            // 
            // textBox_SourceFilePath
            // 
            this.textBox_SourceFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_SourceFilePath.Location = new System.Drawing.Point(4, 55);
            this.textBox_SourceFilePath.Name = "textBox_SourceFilePath";
            this.textBox_SourceFilePath.Size = new System.Drawing.Size(1025, 20);
            this.textBox_SourceFilePath.TabIndex = 1;
            // 
            // button_setSourceFilePath
            // 
            this.button_setSourceFilePath.Location = new System.Drawing.Point(4, 7);
            this.button_setSourceFilePath.Name = "button_setSourceFilePath";
            this.button_setSourceFilePath.Size = new System.Drawing.Size(80, 43);
            this.button_setSourceFilePath.TabIndex = 0;
            this.button_setSourceFilePath.Text = "Выбрать файл";
            this.button_setSourceFilePath.UseVisualStyleBackColor = true;
            this.button_setSourceFilePath.Click += new System.EventHandler(this.button_setSourceFilePath_Click);
            // 
            // richTextBox_results
            // 
            this.richTextBox_results.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBox_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_results.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_results.Location = new System.Drawing.Point(4, 4);
            this.richTextBox_results.Name = "richTextBox_results";
            this.richTextBox_results.Size = new System.Drawing.Size(1025, 427);
            this.richTextBox_results.TabIndex = 2;
            this.richTextBox_results.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.richTextBox_results);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 109);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4);
            this.panel4.Size = new System.Drawing.Size(1033, 435);
            this.panel4.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1033, 30);
            this.panel2.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1025, 22);
            this.progressBar1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1033, 544);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "ParseClient";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_SourceFilePath;
        private System.Windows.Forms.Button button_setSourceFilePath;
        private System.Windows.Forms.Button button_goParse;
        private System.Windows.Forms.RichTextBox richTextBox_results;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_Records;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

