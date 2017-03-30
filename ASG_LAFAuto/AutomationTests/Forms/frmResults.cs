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
using Engine.TestEngine;

namespace AutomationTests
{
    public partial class frmResults : Form
    {
        
        static List<ApplicationDataObject> applicationData;
        string filename;
        string environment;
        List<TestDataObject> testData;
        List<EnvironmentSettingsObject> environmentSettings;
        string LAFUserName;
        string LAFPassword;
        string inputFileLocation;



        public frmResults(TestResults testResults,string browser,string inputFileLocation)
        {
            InitializeComponent();
            txtBrowser.Text = browser;
            txtNumberTestsFailed.Text = testResults.numberFailures.ToString();
            txtNumberTestsPassed.Text = testResults.numberSuccesses.ToString();
            txtNumberTestsRan.Text = testResults.totalNumberOfTests.ToString();
            txtTotalExecutionTime.Text = testResults.totalExecutionTime;
            this.inputFileLocation = inputFileLocation;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            
            /**
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                filename = openFileDialog1.FileName;

                filePath.Text = filename;

                try {
                    //Get Objects from Spreadsheet
                    //TestSettingsObject testRunSettings = ExcelDrivenFunctional.GetTestRunSettings();
                    testData = ExcelDrivenFunctional.GetTestData();

                    environment = comboEnvironment.Text;
                    users = ExcelDrivenFunctional.GetUsers("Users");
                    applicationData = ExcelDrivenFunctional.GetApplicationData(environment);
                    environmentSettings = ExcelDrivenFunctional.GetEnvironmentSettings(environment);

                }
                catch
                {
                    MessageBox.Show("Problem reading input file - check format and content and try again.", "Could not load input file",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                MessageBox.Show("All Test Data loaded successfully. There are "+testData.Count+ "tests specified to run in this suite. Click Start to begin", "Test data loaded successfully",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button1.Enabled = true;

               
            }
    **/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**
            LAFUserName = txtUserName.Text;
            LAFPassword = txtPassword.Text;
            Engine.TestEngine.TestEngineClass.testEngine(testData, users, applicationData,environment, environmentSettings,LAFUserName,LAFPassword);
    **/
        }

        private void comboEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmResults_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.inputFileLocation);

        }

        private void btnOpenScreenshotsFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(TestEngineClass.screenshotDirectory);
        }

        private void btnOpenLogFile_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start(TestEngineClass.GetDirectoryAppIsRunningIn() + "\\Application.log");
        }
    }
}
