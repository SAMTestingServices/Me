using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using OpenQA.Selenium.Support.UI;
using AutomationTests.PageObjects.Lloyd_s_Applications.LAF_Authenticated_Applications.Overseas_Reporting_System;

namespace AutomationTests.PageObjects.Lloyd_s_Applications.LAF_Authenticated_Applications.Overseas_Reporting_System
{
    public class ORS_MaintainPage : PageMaster
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//tr[2]//a[contains(@href,'ViewSyndicatePack')]")]
        private IWebElement DocumentLinkFirst { get; set; }

        public ORS_MaintainPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        

        public ORS_DocumentPackPage clickFirstDocumentLink(){
            DocumentLinkFirst.Click();
            return new ORS_DocumentPackPage(driver);
        
        
    }
    }
}
