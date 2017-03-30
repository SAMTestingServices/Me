using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace AutomationTests.PageObjects
{
    public class LATCHPage : PageMaster

        //Also used for Add Application Details PAge - unless not possible
    {
        private IWebDriver driver;

        

        [FindsBy(How = How.XPath, Using = "//*[@title='Company Search']")]
        [CacheLookup]
        public IWebElement Company_Search_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@title='Tasks']")]
        [CacheLookup]
        public IWebElement Tasks_link { get; set; }


        
        [FindsBy(How = How.XPath, Using = "//select")]
        [CacheLookup]
        public IWebElement Assignee_dropdown { get; set; }
    


        [FindsBy(How = How.XPath, Using = "//select/option")]
        [CacheLookup]
        public IList<IWebElement> Assignee_dropdown_members { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='sidebar']/ul/li[2]/a[1]/i")]
        [CacheLookup]
        public IWebElement Submission_link { get; set; }






        public void SubmitNewPolicy(IWebDriver driver, string policyNumber)
        {


            policyNumber = policyNumber + DateTime.Now.ToString();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(newPolicyLinkLocator)));
            this.NewPolicy_Link.Click();
            this.Name_NewPolicy_Text.SendKeys("Test Name LTP");
            this.Email_NewPolicy_Text.SendKeys("TestEmail@test.com");
            this.Company_NewPolicy_Text.SendKeys("Test Company LTP");
            this.Illinois_NewPolicy_Radio.Click();
           
            this.LloydsCustomer_Text.SendKeys("s");
           
                
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='autocomplete-suggestion'][1]")));
                PageFactory.InitElements(driver, this);
                CompanyAutoComplete_dropdownItem1.Click();
            
            
           
            this.PolicyNumber_Text.SendKeys(policyNumber);
            this.Submit_Button.Click();

        }

        //Adding as string so can reference from wait..

        public By PolicySubmitted_By = By.XPath("//*[text()='Your data has been submitted. Thank you.']");
        public string  PolicySubmitted_Xpath = "//*[text()='Your data has been submitted. Thank you.']";

       
        public String newPolicyLinkLocator = "//*[@ui-sref = 'new-policy']";


        [FindsBy(How = How.XPath, Using = "//*[@ui-sref = 'new-policy']")]
        [CacheLookup]
        public IWebElement NewPolicy_Link { get; set; }




            [FindsBy(How = How.XPath, Using = "//*[@id = 'submitted-by-name']")]
        [CacheLookup]
        public IWebElement Name_NewPolicy_Text { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id = 'submitted-by-email']")]
               [CacheLookup]
               public IWebElement Email_NewPolicy_Text { get; set; }

               [FindsBy(How = How.XPath, Using = "//*[@id = 'submitted-by-company']")]
               [CacheLookup]
               public IWebElement Company_NewPolicy_Text { get; set; }

               [FindsBy(How = How.XPath, Using = "//*[@id = 'rbIllinois']")]
               [CacheLookup]
               public IWebElement Illinois_NewPolicy_Radio { get; set; }


         [FindsBy(How = How.XPath, Using = "//*[@id = 'lloyds-customer']")]
        [CacheLookup]
        public IWebElement LloydsCustomer_Text { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='autocomplete-suggestion'][1]")]
        [CacheLookup]
        public IWebElement CompanyAutoComplete_dropdownItem1 { get; set; }

         [FindsBy(How = How.XPath, Using = "//*[@id='policy-number']")]
        [CacheLookup]
        public IWebElement PolicyNumber_Text { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@ng-click='vm.submitClick(SaveAction.Submit)']")]
        [CacheLookup]
        public IWebElement Submit_Button { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//button[@ng-click='vm.isActionButtonShown(SaveAction.SubmitAndProcess)']")]
        [CacheLookup]
        public IWebElement SubmitAndProcess_Button { get; set; }
       
        public LATCHPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        

    }


}
