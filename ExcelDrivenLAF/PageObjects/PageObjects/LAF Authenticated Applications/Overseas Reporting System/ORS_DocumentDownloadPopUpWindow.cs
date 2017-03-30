using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using AutomationTests.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTests.PageObjects.Lloyd_s_Applications.LAF_Authenticated_Applications.Overseas_Reporting_System
{
    public class ORS_DocumentDownloadPopUpWindow : PageMaster
    {

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Most Recent Download']")]
        private IWebElement MostRecentDownloadLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='ctl00$c$Action']")]
        private IWebElement GenerateNewLink { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[text()='The Pack is currently being generated and the download will resume once complete.']")]
        private IWebElement GeneratingMessage { get; set; }

        private string previousWindowHandle;

        public ORS_DocumentDownloadPopUpWindow(IWebDriver driver, string previousWindowHandle)
            : base(driver)
        {
            this.driver = driver;
            this.previousWindowHandle = previousWindowHandle;
            PageFactory.InitElements(driver, this);
        }

        public ORS_DocumentPackPage DownloadFile(int waitTimeSeconds)
        {
           


            int numberFilesBefore = LAFMethods.CheckNumberOfFilesinDownloadFolder();
            Thread.Sleep(1000);
            try
            {
                Assert.IsFalse(this.isElementPresent(GeneratingMessage));
            }
            catch(Exception ex)
            {
                driver.SwitchTo().Window(previousWindowHandle);
                throw new Exception(ex.ToString());
            }
                GenerateNewLink.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='The Pack is currently being generated and the download will resume once complete.']")));
            Assert.IsTrue(this.isElementPresent(GeneratingMessage));

            

            //new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeSeconds)).Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='Your download should begin shortly.']")));









            int numberFileAfter;
            //'bool fileDownloaded = false;
            int tick = 0;

            //Thread.Sleep(waitTimeSeconds * 1000);

            do

            {
                numberFileAfter = LAFMethods.CheckNumberOfFilesinDownloadFolder();

                try
                {
                    Assert.IsTrue(numberFileAfter == numberFilesBefore + 1);
                    break;
                }
                catch (Exception ex)
                {
                    if (tick >= waitTimeSeconds) {
                        driver.Close();
                        driver.SwitchTo().Window(previousWindowHandle);
                        throw new Exception(ex.ToString()); 
                    }
                    
                }
                Thread.Sleep(1000);
                tick += 1;
            }
            while(true);
            driver.Close();
            driver.SwitchTo().Window(previousWindowHandle);


            /**

                string currentHandle = driver.CurrentWindowHandle; 

            //Switching to correct window in case test fails (need to leave pop up open until download complete so can't close)
                
                Assert.IsTrue(numberFileAfter == numberFilesBefore + 1);

            //Test Succeeded so go back and close pop up and then swithc back to main
                driver.SwitchTo().Window(currentHandle);
                
               **/

         
            
            
            return new ORS_DocumentPackPage(driver);
        }

    }
}

