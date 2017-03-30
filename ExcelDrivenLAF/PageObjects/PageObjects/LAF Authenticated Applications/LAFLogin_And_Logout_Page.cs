using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading;
using System.Reflection;






namespace AutomationTests.PageObjects


    //This page object covers all LAF Authenticated applications

{
    public class LAFLogin_And_Logout_Page : PageMaster
    {
        private IWebDriver driver;

        //Log in Screen:

        [FindsBy(How = How.Id, Using = "Username")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id = 'login.submit']")]
        [CacheLookup]
        public IWebElement Login_Securely_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Login')]")]
        [CacheLookup]
        public IWebElement Login_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Register now']")]
        [CacheLookup]
        public IWebElement Register_now_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@type='checkbox' and @id='HasAccepted') or contains(@id,'chkTsAndCsAgreed')]")]
        [CacheLookup]
        public IWebElement chk_TCs { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='accepttermsandconditions.submit' or @type = 'submit']")]
        [CacheLookup]
        public IWebElement btn_TCsSubmit { get; set; }

        




        public void LoginToApplication(string username, string password, log4net.ILog log)
        {
            log.Info("in login method");




           

            //Check if Ts&Cs need to be accepted (first time visit)



            try
            {
                UserName.Clear();
            }
            catch (TargetInvocationException)
            {
                PageFactory.InitElements(driver, this);
                UserName.Clear();
            }
            UserName.SendKeys(username);
            Password.SendKeys(password);
            Login_Securely_button.Submit();
            log.Info("Login Successful");

            try
            {
                chk_TCs.Click();
                btn_TCsSubmit.Click();
            }
            catch
            {
                //Nothing to do - page not present
            }




        }

     


        




        public void LoginToApplicationNoAutoAuth(string username, string password, log4net.ILog log)
        {
            log.Info("Gone to Login To ApplicationNoAuth");

            try
            {

                Login_link.Click();
                log.Info("Clicked Login button");
                UserName.SendKeys(username);
                Password.SendKeys(password);
                Login_Securely_button.Submit();

                log.Info("Login submitted");
            }
            catch (Exception ex)
            {
                try
                {

                    driver.FindElement(By.XPath("//*[@name='HasAccepted' and @type='checkbox']")).Click();
                    driver.FindElement(By.XPath("//*[@value='Submit'")).Click();
                }
                catch
                {

                    log.Error("Failed to Submit login details");
                    
                    throw new Exception(ex.Message);
                }
            }
        }


        //Log Out Screen:

        [FindsBy(How = How.XPath, Using = "//*[contains(@href,'signout')or contains(@href,'Sign')or contains(@href,'Logout')or contains(text(),'Log out') or contains(text(),'Logout') or contains(text(),'LOGOUT') or contains(@src,'Logout.png') or @id='UserDisplay_LogOff' or text()='Logout']")]
        [CacheLookup]
        public IWebElement LogOut { get; set; }


        public LAFLogin_And_Logout_Page(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        //This method will eventually be inherited from a higher generic page class
        public void AssertTextPresent(string assertion, log4net.ILog log)



        {


            try
            {

                Assert.IsTrue(driver.PageSource.Contains(assertion));

                log.Info("Text present on site as expected: " + assertion);


            }
            catch (Exception ex)
            {
                

                log.Error("Text NOT present on site: " + assertion);
                throw new Exception(ex.Message);
            }

        }

        public void LogoutOfApplication(log4net.ILog log, string logoutURL)
        {
            //Need to add an assertion here that site has logged out successfully


            
            try
            {
                LogOut.Click();

            }
            catch (StaleElementReferenceException ex)
            {
                log.Info("Stale el" + ex.ToString());
                initElements(driver);
                LogOut.Click();
            }


            catch (TargetInvocationException ex)
            {
                log.Info("cannot find element" + ex.ToString());


                log.Error("Logout FAILURE");
                log.Info("Attempting to force logout via direct URL invocation..");
                log.Info(ex.ToString());
                try
                {
                    LoadUrl(logoutURL+"/LogOut", log);
                }
                catch
                {
                    log.Info("assuming timeout issue");
                    log.Error("Timeout Exception, wait 30 seconds then continue with test..");
                    Thread.Sleep(30000);
                }
                //If logout fails here, the whole test will fail, which needs to happen because not being logged out will invalidate the rest of the tests
                
                
                

            }

            catch (NoSuchElementException ex)
            {
                log.Info("cannot find element" + ex.ToString());


                log.Error("Logout FAILURE");
                log.Info("Attempting to force logout via direct URL invocation..");
                log.Info(ex.ToString());

                LoadUrl(logoutURL + "/LogOut", log);
                //If logout fails here, the whole test will fail, which needs to happen because not being logged out will invalidate the rest of the tests
                Assert.IsTrue(driver.PageSource.Contains("You have now successfully logged out."));
                log.Info("Forced logout succeeded");
            }

            catch (Exception ex)
            {
                log.Info("target invoc" + ex.ToString());
                log.Error("Timeout Exception, wait 30 seconds then continue with test..");
                Thread.Sleep(30000);
            }
            
            finally
            {
                
                Assert.IsTrue(driver.PageSource.Contains("You have now successfully logged out."));
                log.Info("Forced logout succeeded");
            }
   
            log.Info("finished in logout");
           


        }

 }
}
