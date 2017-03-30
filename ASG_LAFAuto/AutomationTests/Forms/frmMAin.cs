using AutomationTests.TestDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
using System.Threading;
using Engine.TestEngine;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using AutomationTests.Domain;

namespace AutomationTests
{
    public partial class frmMain : Form
    {
        
        static List<ApplicationDataObject> applicationData;
        string filename;
        string environment;
        List<TestDataObject> testData;
        List<EnvironmentSettingsObject> environmentSettings;
        string UserName;
        
        string Password;
        string browser;
        string tabName;
        Thread childThread;
        OleDbConnection excelConnection;

        public frmMain()
        {
            InitializeComponent();
            string SolutionDirectory = TestEngineClass.GetDirectoryAppIsRunningIn() + "..\\..\\..\\TestDataFiles\\";

            openFileDialog1.InitialDirectory = SolutionDirectory;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {

            

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                filename = openFileDialog1.FileName;

                filePath.Text = filename;

                excelConnection = ExcelDataTools.GetTestDataFileConnection(filename);

                ExcelDataTools.PopulateWorkSheetCombo(excelConnection, cmbWorksheets);

                
            }
               

            }
        

       

        private void button1_Click(object sender, EventArgs e)
        {
            /**LAFUserName = txtUserName.Text;
            LAFPassword = txtPassword.Text;
            Engine.TestEngine.TestEngineClass.testEngine(testData, users, applicationData, environment, environmentSettings, LAFUserName, LAFPassword);
            **/
            environment = comboEnvironment.Text;
            UserName = txtUserName.Text;
            Password = txtPassword.Text;
            browser = cmbBrowser.Text;
            if (environment == "")
            {
                MessageBox.Show("You must select an environment before proceeding", "No environment selected",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (UserName == "")
            {
                MessageBox.Show("You must enter a Username before proceeding","No username entered",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Password == "")
            {
                MessageBox.Show("You must enter a Password before proceeding", "No password entered",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (browser == "")
            {
                MessageBox.Show("You must select a browser before proceeding", "No browser selected",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult msgResult = new DialogResult();
            try
            {
                //Get Objects from Spreadsheet
                //TestSettingsObject testRunSettings = ExcelDrivenFunctional.GetTestRunSettings();

                

                testData = ExcelDataTools.GetTestData(excelConnection, tabName);

                
                
                applicationData = ExcelDataTools.GetApplicationData(environment, excelConnection);
                environmentSettings = ExcelDataTools.GetEnvironmentSettings(environment, excelConnection);

                msgResult = MessageBox.Show("All Test Data loaded successfully. There are " + testData.Count + " tests specified to run in this suite. Click OK to begin", "Test data loaded successfully",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if (msgResult.ToString()=="OK")
                msgResult = MessageBox.Show(String.Format("Before proceding, ensure that the input Excel file '{0}' is closed to ensure test results are correctly updated. When closed, click OK to proceed.", this.filename), "Ensure Excel file is closed",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem reading input file - check format and content and try again.", "Could not load input file",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            if (msgResult.ToString() == "OK")
                {

                    try
                    {
                        TestResults testResults = TestEngineClass.testEngine(testData, applicationData, environment, environmentSettings, UserName, Password, browser, excelConnection, tabName);

                        frmResults frmResults1 = new frmResults(testResults, browser,filename);
                        frmResults1.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unhandled Exception while running the test:\n\n\n\n "+ex.ToString(), "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }


                    /**
                    ThreadStart childref = new ThreadStart(StartExecutionThread);
                    childThread = new Thread(childref);
                    childThread.Start();
                    //childThread.Join();
                    TestResults testResults = new TestResults(5, 3, 2, "a long time");
                    frmResults frmResults1 = new frmResults(testResults, "Chrome");
                    frmResults1.Show();

    **/
                }
               
        
    
            

            //this.Close();
    
        }

        private void comboEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbWorksheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabName = cmbWorksheets.Text;
            if (cmbWorksheets.SelectedIndex < 0) { startButton.Enabled = false; }

            else { startButton.Enabled = true; };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            childThread.Abort();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            comboEnvironment.DataSource = Enum.GetValues(typeof(Constants.Environment));
        }

        
    }
}
