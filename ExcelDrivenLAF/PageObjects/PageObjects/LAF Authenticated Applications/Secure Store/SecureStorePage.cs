using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageObjects
{
    public class SecureStorePage : PageMaster

        //Also used for Add Application Details PAge - unless not possible
    {
        //private IWebDriver driver;

        





        //Admin/list view:

        [FindsBy(How = How.XPath, Using = "//*[@href='/sites/admin/Lists/Syndicates/AllItems.aspx' and text()='Syndicates']")]
        [CacheLookup]
        public IWebElement Synidicates_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text()='Add new item']")]
        [CacheLookup]
        public IWebElement Add_new_item_link { get; set; }



        
        //Enter syndicate pop-up            

        [FindsBy(How = How.XPath, Using = "//*[@title='Entity Code Required Field']")]
        [CacheLookup]
        public IWebElement EntityCode_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@title='Entity Name Required Field']")]
        [CacheLookup]
        public IWebElement EntityName_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Save' and @type='button']")]
        [CacheLookup]
        public IWebElement Save_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@title='Devolved Admin']")]
        [CacheLookup]
        public IWebElement Devolved_Admin_text { get; set; }

        

        [FindsBy(How = How.XPath, Using = "(//body/iframe)[1]")]
        [CacheLookup]
        public IWebElement iframe { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'DlgFrame')]")]
        [CacheLookup]
        public IWebElement iframe2 { get; set; }
        




        public SecureStorePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        

    }


}
