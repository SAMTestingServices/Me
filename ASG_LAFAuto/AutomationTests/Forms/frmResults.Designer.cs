namespace AutomationTests
{
    partial class frmResults
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumberTestsRan = new System.Windows.Forms.TextBox();
            this.txtNumberTestsPassed = new System.Windows.Forms.TextBox();
            this.txtNumberTestsFailed = new System.Windows.Forms.TextBox();
            this.txtTotalExecutionTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBrowser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenScreenshotsFolder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOpenLogFile = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOpenInputFile = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "LAF Automation Test Suite";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Number of tests ran:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Number of tests failed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Total Execution time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Number of tests passed:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 24);
            this.label7.TabIndex = 24;
            this.label7.Text = "Test Result Summary";
            // 
            // txtNumberTestsRan
            // 
            this.txtNumberTestsRan.Location = new System.Drawing.Point(219, 104);
            this.txtNumberTestsRan.Name = "txtNumberTestsRan";
            this.txtNumberTestsRan.ReadOnly = true;
            this.txtNumberTestsRan.Size = new System.Drawing.Size(92, 20);
            this.txtNumberTestsRan.TabIndex = 27;
            // 
            // txtNumberTestsPassed
            // 
            this.txtNumberTestsPassed.Location = new System.Drawing.Point(219, 153);
            this.txtNumberTestsPassed.Name = "txtNumberTestsPassed";
            this.txtNumberTestsPassed.ReadOnly = true;
            this.txtNumberTestsPassed.Size = new System.Drawing.Size(92, 20);
            this.txtNumberTestsPassed.TabIndex = 28;
            // 
            // txtNumberTestsFailed
            // 
            this.txtNumberTestsFailed.Location = new System.Drawing.Point(219, 197);
            this.txtNumberTestsFailed.Name = "txtNumberTestsFailed";
            this.txtNumberTestsFailed.ReadOnly = true;
            this.txtNumberTestsFailed.Size = new System.Drawing.Size(92, 20);
            this.txtNumberTestsFailed.TabIndex = 29;
            // 
            // txtTotalExecutionTime
            // 
            this.txtTotalExecutionTime.Location = new System.Drawing.Point(219, 248);
            this.txtTotalExecutionTime.Name = "txtTotalExecutionTime";
            this.txtTotalExecutionTime.ReadOnly = true;
            this.txtTotalExecutionTime.Size = new System.Drawing.Size(92, 20);
            this.txtTotalExecutionTime.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Browser:";
            // 
            // txtBrowser
            // 
            this.txtBrowser.Location = new System.Drawing.Point(219, 302);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.ReadOnly = true;
            this.txtBrowser.Size = new System.Drawing.Size(92, 20);
            this.txtBrowser.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "To view Screenshots of failure points:";
            // 
            // btnOpenScreenshotsFolder
            // 
            this.btnOpenScreenshotsFolder.Location = new System.Drawing.Point(219, 464);
            this.btnOpenScreenshotsFolder.Name = "btnOpenScreenshotsFolder";
            this.btnOpenScreenshotsFolder.Size = new System.Drawing.Size(92, 40);
            this.btnOpenScreenshotsFolder.TabIndex = 36;
            this.btnOpenScreenshotsFolder.Text = "View Screenshots";
            this.btnOpenScreenshotsFolder.UseVisualStyleBackColor = true;
            this.btnOpenScreenshotsFolder.Click += new System.EventHandler(this.btnOpenScreenshotsFolder_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 548);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "To view Application Log file:";
            // 
            // btnOpenLogFile
            // 
            this.btnOpenLogFile.Location = new System.Drawing.Point(219, 534);
            this.btnOpenLogFile.Name = "btnOpenLogFile";
            this.btnOpenLogFile.Size = new System.Drawing.Size(92, 40);
            this.btnOpenLogFile.TabIndex = 38;
            this.btnOpenLogFile.Text = "View Log File";
            this.btnOpenLogFile.UseVisualStyleBackColor = true;
            this.btnOpenLogFile.Click += new System.EventHandler(this.btnOpenLogFile_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(294, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "For individual test results, refer to \'Results\' column in Input file";
            // 
            // btnOpenInputFile
            // 
            this.btnOpenInputFile.Location = new System.Drawing.Point(108, 391);
            this.btnOpenInputFile.Name = "btnOpenInputFile";
            this.btnOpenInputFile.Size = new System.Drawing.Size(92, 40);
            this.btnOpenInputFile.TabIndex = 41;
            this.btnOpenInputFile.Text = "Open Input File";
            this.btnOpenInputFile.UseVisualStyleBackColor = true;
            this.btnOpenInputFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 629);
            this.Controls.Add(this.btnOpenInputFile);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnOpenLogFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOpenScreenshotsFolder);
            this.Controls.Add(this.txtBrowser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotalExecutionTime);
            this.Controls.Add(this.txtNumberTestsFailed);
            this.Controls.Add(this.txtNumberTestsPassed);
            this.Controls.Add(this.txtNumberTestsRan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "frmResults";
            this.Text = "frmResults";
            this.Load += new System.EventHandler(this.frmResults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumberTestsRan;
        private System.Windows.Forms.TextBox txtNumberTestsPassed;
        private System.Windows.Forms.TextBox txtNumberTestsFailed;
        private System.Windows.Forms.TextBox txtTotalExecutionTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBrowser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenScreenshotsFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOpenLogFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOpenInputFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}