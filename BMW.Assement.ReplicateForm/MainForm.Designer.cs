namespace BMW.Assessment.ReplicateForm
{
    partial class FormReplicate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseSrc = new System.Windows.Forms.Button();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.btnReplicate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.includeSubdirectoriesCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Progress Bar";
            // 
            // btnBrowseSrc
            // 
            this.btnBrowseSrc.Location = new System.Drawing.Point(682, 46);
            this.btnBrowseSrc.Name = "btnBrowseSrc";
            this.btnBrowseSrc.Size = new System.Drawing.Size(94, 29);
            this.btnBrowseSrc.TabIndex = 3;
            this.btnBrowseSrc.Text = "Browse";
            this.btnBrowseSrc.UseVisualStyleBackColor = true;
            this.btnBrowseSrc.Click += new System.EventHandler(this.btnBrowseSrc_Click);
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(682, 81);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(94, 29);
            this.btnBrowseDest.TabIndex = 4;
            this.btnBrowseDest.Text = "Browse";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // btnReplicate
            // 
            this.btnReplicate.Location = new System.Drawing.Point(154, 178);
            this.btnReplicate.Name = "btnReplicate";
            this.btnReplicate.Size = new System.Drawing.Size(94, 29);
            this.btnReplicate.TabIndex = 5;
            this.btnReplicate.Text = "&Replicate";
            this.btnReplicate.UseVisualStyleBackColor = true;
            this.btnReplicate.Click += new System.EventHandler(this.btnReplicate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(682, 286);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(154, 286);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(94, 29);
            this.btnViewLog.TabIndex = 7;
            this.btnViewLog.Text = "View &Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // includeSubdirectoriesCheckBox
            // 
            this.includeSubdirectoriesCheckBox.AutoSize = true;
            this.includeSubdirectoriesCheckBox.Location = new System.Drawing.Point(154, 136);
            this.includeSubdirectoriesCheckBox.Name = "includeSubdirectoriesCheckBox";
            this.includeSubdirectoriesCheckBox.Size = new System.Drawing.Size(184, 24);
            this.includeSubdirectoriesCheckBox.TabIndex = 8;
            this.includeSubdirectoriesCheckBox.Text = "Include Sub Directories";
            this.includeSubdirectoriesCheckBox.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(154, 230);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(622, 29);
            this.progressBar1.TabIndex = 9;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Enabled = false;
            this.sourceTextBox.Location = new System.Drawing.Point(154, 46);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(522, 27);
            this.sourceTextBox.TabIndex = 10;
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Enabled = false;
            this.destinationTextBox.Location = new System.Drawing.Point(154, 82);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(522, 27);
            this.destinationTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.destinationTextBox);
            this.panel1.Controls.Add(this.sourceTextBox);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.includeSubdirectoriesCheckBox);
            this.panel1.Controls.Add(this.btnViewLog);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnReplicate);
            this.panel1.Controls.Add(this.btnBrowseDest);
            this.panel1.Controls.Add(this.btnBrowseSrc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 335);
            this.panel1.TabIndex = 0;
            // 
            // FormReplicate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 341);
            this.Controls.Add(this.panel1);
            this.Name = "FormReplicate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replicate";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnBrowseSrc;
        private Button btnBrowseDest;
        private Button btnReplicate;
        private Button btnExit;
        private Button btnViewLog;
        private CheckBox includeSubdirectoriesCheckBox;
        private ProgressBar progressBar1;
        private TextBox sourceTextBox;
        private TextBox destinationTextBox;
        private Panel panel1;
    }
}