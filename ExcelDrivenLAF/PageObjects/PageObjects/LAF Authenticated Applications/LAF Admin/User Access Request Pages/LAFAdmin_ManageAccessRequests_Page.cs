using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace AutomationTests.PageObjects
{
    public class LAFAdmin_ManageAccessRequests_Page : PageMaster
    {

        private IWebDriver driver;

        //Constructor:

        public LAFAdmin_ManageAccessRequests_Page(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //Home Screen:

        [FindsBy(How = How.XPath, Using = "//*[@id='approve']")]
        [CacheLookup]
        public IWebElement Approve_link { get; set; }


        //*[text()='Cancel']

        [FindsBy(How = How.XPath, Using = "//*[@id='reject']")]
        [CacheLookup]
        public IWebElement Reject_link { get; set; }



        //Reject Screen Objects:

        [FindsBy(How = How.XPath, Using = "//*[@Name='MultiAction::ConfirmRejection']")]
        [CacheLookup]
        public IWebElement Confirm_Rejection_link { get; set; }


        

        [FindsBy(How = How.XPath, Using = "//*[@Name='MultiAction::CancelRejection']")]
        [CacheLookup]
        public IWebElement Cancel_Rejection_link { get; set; }



          //Top bar NAvigation Links:

        [FindsBy(How = How.XPath, Using = "//*[text()='Users']")]
        [CacheLookup]
        public IWebElement USERS_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='User Groups']")]
        [CacheLookup]
        public IWebElement USER_GROUPS_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Applications']")]
        [CacheLookup]
        public IWebElement Applications_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='User access requests']")]
        [CacheLookup]
        public IWebElement USER_ACCESS_REQUESTS_link { get; set; }




     

        

    }


}
