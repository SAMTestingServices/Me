using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using OpenQA.Selenium.Support.UI;
using AutomationTests.PageObjects.Lloyd_s_Applications.LAF_Authenticated_Applications.Overseas_Reporting_System;

namespace AutomationTests.PageObjects
{
    public class ORS_HomePage : PageMaster

        //Also used for Add Application Details PAge - unless not possible
    {
        private IWebDriver driver;



        [FindsBy(How = How.XPath, Using = "//select[@name='ctl00$c$MRSelectables$Countries']")]
        [CacheLookup]
        private IWebElement CountrySelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$c$MRSelectables$Quarters']")]
        [CacheLookup]
        private IWebElement QuarterSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$c$MRSelectables$SelectedSyndicateTextBox']")]
        [CacheLookup]
        private IWebElement SyndicateText { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$c$Update']")]
        [CacheLookup]
        private IWebElement btnUpdate { get; set; }

        //a[text()='Maintain']

        [FindsBy(How = How.XPath, Using = "//a[text()='Maintain']")]
        [CacheLookup]
        private IWebElement MaintainLink { get; set; }

        public ORS_MaintainPage selectAndUpdate(string SyndicateNumber)
            {

                var selectCountry = new SelectElement(CountrySelect);
                selectCountry.SelectByIndex(2);
                SyndicateText.SendKeys("0382");
                btnUpdate.Click();
                MaintainLink.Click();
                
                return new ORS_MaintainPage(driver);
                        
            }





        [FindsBy(How = How.XPath, Using = "//*[@title='Tasks']")]
        [CacheLookup]
        public IWebElement Tasks_link { get; set; }



        [FindsBy(How = How.XPath, Using = "//select[@name='taskGridAssignabled']")]
        [CacheLookup]
        public IWebElement Assignee_dropdown { get; set; }



        [FindsBy(How = How.XPath, Using = "//tbody//tr[1]//option")]
        [CacheLookup]
        public IList<IWebElement> Assignee_dropdown_members { get; set; }



     






        public ORS_HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        

    }


}
