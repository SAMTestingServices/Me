using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;

//using AutomationTests.WrapperFactory;
using AutomationTests.TestDataAccess;

using log4net;
using System.Collections.Generic;
using System.Reflection;
using AutomationTests.TestCases;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Data.OleDb;
using System.Threading;
using AutomationTests.Methods;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;

namespace Engine.TestEngine{
   
    public static class TestEngineClass

    {

        public static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public static string screenshotDirectory;
        
        //TEST DATA - STATIC (PRE-EXISTING IN SYSTEM):

            
        //CREATED (and deleted) AS PART OF THIS TEST:
        /**
        private string applicationName = "for test";
        private string existingUserGroup = "Laatch2";

        private string newPassword = "Password12";
        private string gmailPassword = "Clar2017";
        **/

        //string url = ConfigurationManager.AppSettings["URL"];


        //target app data:


            

        


       


        //Admin prob not needed anymore

        //public static string LAFSuperAdminEmail;
        //public static string LAFSuperAdminPassword;
        public static string LAFAdminURL;

       

        public static ApplicationDataObject thisApp;

        static string iEDriverLocationRelativeToExecutionDirectory = ConfigurationManager.AppSettings["iEDriverLocationRelativeToExecutionDirectory"];
        static string chromeDriverLocationRelativeToExecutionDirectory = ConfigurationManager.AppSettings["ChromeDriverLocationRelativeToExecutionDirectory"];

        

        static public TestResults testEngine(List<TestDataObject> testData, List<ApplicationDataObject> applicationData, string environment, List<EnvironmentSettingsObject> environmentSettings, string username, string password, string browser, OleDbConnection excelConnection, string tab)

        //public void TestEngineClass()
        {
            IWebDriver driver;

            if (browser == "Internet Explorer")

               
            {
                string iEDriverLocation = GetDirectoryAppIsRunningIn() + iEDriverLocationRelativeToExecutionDirectory;

                var options = SetInternetExplorerDriverOptions();
                driver = new InternetExplorerDriver(iEDriverLocation,options);


            }
            else
            {
                string chromeDriverLocation = GetDirectoryAppIsRunningIn() + chromeDriverLocationRelativeToExecutionDirectory;
                driver = new ChromeDriver(chromeDriverLocation);
                // (@"C:\Users\dev_muldoons\Documents\Visual Studio 2015\Projects\AutomationTests\packages\WebDriver.IEDriver.32-bit.2.33.0\tools\");


            }
            //First lookup Data required and copy into currentTest object
            try
            {
                Thread th = Thread.CurrentThread;
                log.Info("Is Background = " + th.IsBackground.ToString());

                

                screenshotDirectory = CreateScreenShotDirectory();

                //IWebDriver driver = BrowserFactory.GetBrowser("IE");
                

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
                driver.Manage().Window.Maximize();

                //driver.Navigate().GoToUrl(url);

                Stopwatch stopWatch = new Stopwatch();

                //driver.Navigate().GoToUrl(url);


                log.Info("created lafdata object with this many rows:" + testData.Count);
                log.Info("created applicationData object with this many rows:" + applicationData.Count);
                log.Info("created environmentSettings object with this many rows:" + environmentSettings.Count);



                //Find LAF Admin user for current environment

                //UserDataObject Admin = users.Find(item => item.User == "LAFAdmin" && item.Environment == environment);

                //Find LAF Admin URL for current environment

                EnvironmentSettingsObject currentEnvironment = environmentSettings.Find(item => item.Environment == environment);

                log.Info("currentEnvironment = " + currentEnvironment.Environment);

                log.Info("Admin URL = " + currentEnvironment.LAFAdminURL);

                //LAFSuperAdminEmail = LAFAdminUser;

                //LAFSuperAdminPassword = LAFAdminPW;



                LAFAdminURL = currentEnvironment.LAFAdminURL;

                int numberSuccesses = 0;
                int numberFailures = 0;
                TimeSpan totaltime = new TimeSpan(0);
                string totalTimeString = "";

                foreach (var currentTest in testData)
                {

                    if (currentTest.ExecutionMode == "RUN")
                    {

                        //First move current run to previous run and ensure CurrentTest.Result is set to NULL (as this object has already been loaded so updating excel
                        //will not change this


                        ExcelDataTools.WriteToCell(currentTest.ID, "PreviousRun", currentTest.Result, tab, excelConnection);
                        ExcelDataTools.WriteToCell(currentTest.ID, "Result", "", tab, excelConnection);



                        currentTest.Result = null;
                        currentTest.FailReason = null;
                        //First set test data for currentTest...


                        //Should surround with try / Catch with TEST DATA ERROR

                        //Add a try catch block around the data setup so can report in spreadsheet if there is a failure here as opposed to in test
                        try
                        {

                            currentTest.User = username;
                            currentTest.UserPW = password;

                            thisApp = null;

                            if (!(currentTest.Application == null))
                            {
                                //convert to Call Method to call the below
                                thisApp = applicationData.Find(item => item.Application == currentTest.Application);
                                log.Info("app name from app settings = " + thisApp.Application);

                                //Will have to branch the following out into System, UAT,etc.. at some point...
                                //NEED TO REWORK NEXT BIT - NEEDS TO EXCLUDE WHEN NO RESULTS RETURNED 



                            }

                        }
                        catch (Exception ex)
                        {
                            //Must be a test data failure, write to spreadsheet
                            log.Error("Failure in test data setup for this test case. Exception details = " + ex.ToString());
                            //ExcelDrivenFunctional.WriteToCell(currentTest.ID, "Test Data/Setup Failure - see application log for exception detail", "", "TestCases");
                        }
                        //Now do test
                        MethodInfo method;
                        string elapsedTime = "N/A";
                        try
                        {

                            // Get MethodInfo.
                            Type type = typeof(Tests);
                            method = type.GetMethod(currentTest.TestMethodName);
                            if (method == null) { throw new Exception(); }
                        }
                        catch
                        {

                            log.Error("Method does not exist (check spelling): " + currentTest.TestMethodName);
                            currentTest.Result = "FAIL";
                            currentTest.FailReason = String.Format("Method with name {0} does not exist in Test Suite", currentTest.TestMethodName);
                            ExcelDataTools.WriteToCell(currentTest.ID, "Result", currentTest.Result, tab, excelConnection);
                            ExcelDataTools.WriteToCell(currentTest.ID, "FailReason", currentTest.FailReason, tab, excelConnection);
                            numberFailures++;

                            continue;
                            //break;
                        }



                        log.Info("before invoke, current test usergroupA = " + currentTest.userGroupA);



                        stopWatch.Restart();
                        //TestData currentTest, UserDataObject userData, EnvironmentSettingsObject environment, ApplicationDataObject appData,
                        try
                        {
                            method.Invoke(null, new object[] { currentTest, currentEnvironment, thisApp, driver });
                            //Some methods may record result as part of the test case, hence test if set first:
                            numberSuccesses++;
                            if (currentTest.Result == null)
                            {
                                currentTest.Result = "PASS";


                            }
                            log.Info("at end of catch block, current test result is = " + currentTest.Result);
                        }




                        catch (Exception ex)
                        {
                            if (thisApp.Application == null) { thisApp.Application = "LAF"; }
                            TakeScreenshot(driver, screenshotDirectory, currentTest.TestMethodName, currentTest.ID,thisApp.Application);
                            numberFailures++;

                            //Logout of LAF to ensure cleaned up for next Test

                            if (currentTest.Result == null) { currentTest.Result = "FAIL"; }
                            //currentTest.StackTrace = ex.ToString();
                            log.Info(ex.ToString());
                            log.Info("in catch block, current test result is = " + currentTest.Result);
                        }
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;

                        elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                        if (currentTest.Result == "PASS") { currentTest.FailReason = "N/A"; }
                        log.Info("In if passed block, current test result is = " + currentTest.Result);

                        ExcelDataTools.WriteToCell(currentTest.ID, "Result", currentTest.Result, tab, excelConnection);
                        log.Info("after writing result");
                        ExcelDataTools.WriteToCell(currentTest.ID, "ExecutionTime", elapsedTime, tab, excelConnection);
                        log.Info("after writing exec time");
                        ExcelDataTools.WriteToCell(currentTest.ID, "FailReason", currentTest.FailReason, tab, excelConnection);
                        log.Info("after writing fail reason");
                        //ExcelDrivenFunctional.WriteToCell(currentTest.ID, "StackTrace", currentTest.StackTrace, "TestCases");
                        log.Info("at end of test");
                        totaltime = totaltime + ts;

                        totalTimeString = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    }





                }

                driver.Dispose();
                return new TestResults(testData.Count, numberFailures, numberSuccesses, totalTimeString);
            }
            catch (Exception ex)
            {
                driver.Dispose();
                log.Error(ex.ToString());
                    throw new Exception(ex.ToString());
            }
        }

        private static string CreateScreenShotDirectory()
        {
            string testRunName = String.Format("TestRun_{0}_{1}_{2}_{3}_{4}",DateTime.Now.Year.ToString(),DateTime.Now.Month.ToString(),DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString(),DateTime.Now.Minute.ToString());
            string outputDirectory = GetDirectoryAppIsRunningIn() + "\\Screenshots\\" + testRunName;
            Directory.CreateDirectory(outputDirectory);
            return outputDirectory;
            
        }

        private static void TakeScreenshot(IWebDriver driver,string directory,string testMethodName, int testId,string application)
        {
            try
            {
               
                
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(String.Format("{0}\\TestID_{1}_{2}_{3}_Error.jpg",directory,testId,testMethodName,application), System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static string GetDirectoryAppIsRunningIn()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static InternetExplorerOptions SetInternetExplorerDriverOptions()
        {
           
                var options = new InternetExplorerOptions();
                options.EnsureCleanSession = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss;
                options.PageLoadStrategy = InternetExplorerPageLoadStrategy.Normal;

                return options;

          
        }

    }
    }