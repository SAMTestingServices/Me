using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace AutomationTests.PageObjects
{
    public class AtlasPage : PageMaster

        //Also used for Add Application Details PAge - unless not possible
    {
        private IWebDriver driver;

        

        [FindsBy(How = How.XPath, Using = "//*[@title='Company Search']")]
        [CacheLookup]
        public IWebElement Company_Search_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@title='Tasks']")]
        [CacheLookup]
        public IWebElement Tasks_link { get; set; }



        [FindsBy(How = How.XPath, Using = "//select[@name='taskGridAssignabled']")]
        [CacheLookup]
        public IWebElement Assignee_dropdown { get; set; }



        [FindsBy(How = How.XPath, Using = "//tbody//tr[1]//option")]
        [CacheLookup]
        public IList<IWebElement> Assignee_dropdown_members { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text() = 'New service company application']")]
        [CacheLookup]
        public IWebElement NewServiceCompany_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='LegalName']")]
        [CacheLookup]
        public IWebElement CompanyName_text { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='ApplicantsEmailAddress']")]
        [CacheLookup]
        public IWebElement Email_text { get; set; }

         [FindsBy(How = How.XPath, Using = "//*[@value='Submit']")]
        [CacheLookup]
        public IWebElement CompanySubmit_button { get; set; }

        public By ajaxTableEntries = By.XPath("//tr//td");
     
     



        public AtlasPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        

    }


}
