using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using log4net;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObjects
{
    public class PageMaster
    {


        /// <summary>
        /// This Class covers functions and properties (elements) common to all web pages. 
        /// </summary>

        public IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//body")]
        [CacheLookup]
        private IWebElement SiteBody { get; set; }

        [FindsBy(How = How.XPath, Using = "//a")]
        [CacheLookup]
        public IWebElement AnyLink { get; set; }


        //Required by LoginLogout Test to click a link after logging out and clicking back (to trigger logout page display)
        [FindsBy(How = How.XPath, Using = "//a[not(contains(@href,'signout')or contains(@href,'Sign')or contains(@href,'Logout')or contains(text(),'Log out') or contains(text(),'Logout') or contains(text(),'LOGOUT') or contains(@src,'Logout.png') or @id='UserDisplay_LogOff' or @href='#' or text()='Site Actions' or @id='zz3_SiteActionsMenu' or @unselectable='on' or contains(@href,'javascript') or contains(@onclick,'javascript') or text()[string-length() < 3]) and @href]")]
        [CacheLookup]
        public IList<IWebElement> AllLinksOnPageExceptLogOut { get; set; }

        
        public PageMaster(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void initElements(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
                }


        public void Click(IWebElement element, PageMaster page)
        {
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                PageFactory.InitElements(driver, page);
                element.Click();
            }
            

        }

        virtual public void TestMethod() { }

        public void LoadUrl(string url, ILog log)
        {


            try
            {
                driver.Navigate().GoToUrl(url);

                log.Info("URL loaded: " + url);
            }
            catch (Exception ex)
            {
                log.Error("Failed to load URL");
            
                throw new Exception(ex.Message);

            }
        }


        public void findTextOnPageWithWait(string textToFind, ILog log)
        {
            

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(d=>d.FindElement(By.XPath("//*[(contains(text(),'" + textToFind + "') or contains(@value, '" + textToFind + "')) and not(name()='script')]")));
                   
            
            

         }
        

        public Boolean findTextOnPage(string textToFind, ILog log)
        {




            int numberelements = driver.FindElements(By.XPath("//*[(contains(text(),'" + textToFind + "') or contains(@value, '" + textToFind + "')) and not(name()='script')]")).Count;
            if (numberelements < 1)
            {
               
                log.Error("Failed to find Text: " + textToFind);
                
                return false;
            }
            else {
                log.Info("Text found: " + textToFind);

                return true;



            }
        }
        public Boolean findTextOnPage(string textToFind)
        {




            int numberelements = driver.FindElements(By.XPath("//*[(contains(text(),'" + textToFind + "') or contains(@value, '" + textToFind + "')) and not(name()='script')]")).Count;
            if (numberelements < 1)
            {
              
                
                return false;
            }
            else
            {
                

                return true;



            }
        }

        public Boolean isElementPresent(IWebElement element)
        {
            try
            {
                element.GetAttribute("type");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean click(IWebElement element, ILog log)
        {
            try { 
            element.Click();
                log.Info("Element clicked: " + element);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Failed to click element: " + element + ". It is most likely due to the element not being found.");
           
                return false;
            }
        }

       
    }
    


    }



