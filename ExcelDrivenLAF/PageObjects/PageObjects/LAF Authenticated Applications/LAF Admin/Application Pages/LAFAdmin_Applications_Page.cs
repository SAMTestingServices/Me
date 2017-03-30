using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace AutomationTests.PageObjects
{
    public class LAFAdmin_Applications_Page : PageMaster

    {
        
        private IWebDriver driver;




        //Constructor:

        public LAFAdmin_Applications_Page(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        



        //Application Home Page Objects:

        [FindsBy(How = How.XPath, Using = "//*[@value='Save']")]
        [CacheLookup]
        public IWebElement Save_link { get; set; }


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

        [FindsBy(How = How.XPath, Using = "//*[text()='Log out']")]
        [CacheLookup]
        public IWebElement LOG_OUT_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@type='checkbox']")]
        [CacheLookup]
        public IWebElement SEARCH_RESULTS_checkbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Search']")]
        [CacheLookup]
        public IWebElement Search_link { get; set; }


        //Application Details Page Objects: 

        [FindsBy(How = How.XPath, Using = "//*[@id='btnEditApplicationDetails']")]
        [CacheLookup]
        public IWebElement Edit_Application_Details_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='btnAddCredential']")]
        [CacheLookup]
        public IWebElement Add_Credential_link { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_Value']")]
        [CacheLookup]
        public IWebElement Value_text { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='CredentialSearchTerm']")]
        [CacheLookup]
        public IWebElement credential_Search_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Filter Credentials']")]
        [CacheLookup]
        public IWebElement Filter_Credentials_link { get; set; }
        


        [FindsBy(How = How.XPath, Using = "//*[@class='button' and text()='Credential']")]
        [CacheLookup]
        public IWebElement Credential_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@class='button' and text()='Credential Values']")]
        [CacheLookup]
        public IWebElement Credential_Values_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='deleteCredentials']")]
        [CacheLookup]
        public IWebElement Delete_Selected_Credential_link { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='deleteCredentialValues']")]
        [CacheLookup]
        public IWebElement Delete_Selected_Credential_Values_link { get; set; }

        //*[text()='Cancel']

        [FindsBy(How = How.XPath, Using = "//*[@class= 'ui-icon ui-icon-folder-open' and text()='Manage']")]
        [CacheLookup]
        public IWebElement Manage_user_group_icon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value= 'Import']")]
        [CacheLookup]
        public IWebElement Import_link { get; set; }

        


        //Add Credentials Pages:
        [FindsBy(How = How.XPath, Using = "//*[text()= 'Create New Value(s)']")]
        [CacheLookup]
        public IWebElement Create_New_Values_link { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id= 'UniformResourceNameId']")]
        [CacheLookup]
        public IWebElement credential_Name_text { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@class= 'lined']")]
        [CacheLookup]
        public IWebElement add_values_textbox { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[@id= 'Description']")]
        [CacheLookup]
        public IWebElement credential_Description_text { get; set; }


        //Top Bar Navigation Links:





        //Edit Application Details Objects:
        /**
        [FindsBy(How = How.XPath, Using = "//*[@name='Confirm deletion of user']")]
        [CacheLookup]
        public IWebElement Confirm_deletion_of_user_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text()='Cancel']")]
        [CacheLookup]
        public IWebElement Cancel_link { get; set; }
    **/











        

    }


}
