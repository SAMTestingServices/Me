namespace AutomationTests
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEnvironment = new System.Windows.Forms.ComboBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Next = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbBrowser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWorksheets = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.label5.Location = new System.Drawing.Point(14, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "1. Select Environment to run test in:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "2. Enter User Name:";
            // 
            // comboEnvironment
            // 
            this.comboEnvironment.FormattingEnabled = true;
            this.comboEnvironment.Items.AddRange(new object[] {
            "DEV",
            "SYSTEM",
            "UAT",
            "PRODUCTION"});
            this.comboEnvironment.Location = new System.Drawing.Point(239, 73);
            this.comboEnvironment.Name = "comboEnvironment";
            this.comboEnvironment.Size = new System.Drawing.Size(200, 21);
            this.comboEnvironment.TabIndex = 14;
            this.comboEnvironment.SelectedIndexChanged += new System.EventHandler(this.comboEnvironment_SelectedIndexChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(239, 125);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 20);
            this.txtUserName.TabIndex = 15;
            this.txtUserName.Text = "LTP_LAF_TestUser@NoMailbox.com";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(239, 173);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "3. Enter Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "5. Browse for test data file:";
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(239, 287);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(200, 23);
            this.Next.TabIndex = 20;
            this.Next.Text = "Browse";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(17, 339);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(422, 20);
            this.filePath.TabIndex = 22;
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(171, 446);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(121, 23);
            this.startButton.TabIndex = 23;
            this.startButton.Text = "Start Test!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbBrowser
            // 
            this.cmbBrowser.FormattingEnabled = true;
            this.cmbBrowser.Items.AddRange(new object[] {
            "Internet Explorer",
            "Chrome"});
            this.cmbBrowser.Location = new System.Drawing.Point(239, 226);
            this.cmbBrowser.Name = "cmbBrowser";
            this.cmbBrowser.Size = new System.Drawing.Size(200, 21);
            this.cmbBrowser.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "4. Select Browser to run test in:";
            // 
            // cmbWorksheets
            // 
            this.cmbWorksheets.FormattingEnabled = true;
            this.cmbWorksheets.Location = new System.Drawing.Point(239, 393);
            this.cmbWorksheets.Name = "cmbWorksheets";
            this.cmbWorksheets.Size = new System.Drawing.Size(200, 21);
            this.cmbWorksheets.TabIndex = 27;
            this.cmbWorksheets.SelectedIndexChanged += new System.EventHandler(this.cmbWorksheets_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(214, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "6. Select Worksheet containing tests to run:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(465, 490);
            this.Controls.Add(this.cmbWorksheets);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbBrowser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.comboEnvironment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "LAF Automation Test Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEnvironment;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbBrowser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWorksheets;
        private System.Windows.Forms.Label label8;
    }
}