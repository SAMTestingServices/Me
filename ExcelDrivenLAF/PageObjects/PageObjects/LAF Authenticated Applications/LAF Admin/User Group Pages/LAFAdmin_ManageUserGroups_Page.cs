using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AutomationTests.PageObjects
{
    public class LAFAdmin_ManageUserGroups_Page : PageMaster
    {
        private IWebDriver driver;


        //Constructor:
        public LAFAdmin_ManageUserGroups_Page(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        


        //User Groups Home Screen

        [FindsBy(How = How.XPath, Using = "//*[text()='Create New User Group']")]
        [CacheLookup]
        public IWebElement Create_New_User_Group_link { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//*[text()='Manage']")]
        [CacheLookup]
        public IWebElement Manage_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_Name']")]
        [CacheLookup]
        public IWebElement User_Group_Name_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_ApplicationId']")]
        [CacheLookup]
        public IWebElement Application_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@ah='ApplicationName']/a")]
        [CacheLookup]
        public IWebElement APPLICATION_SEARCH_RESULTS_links { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Name']")]
        [CacheLookup]
        public IWebElement Name_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Description']")]
        [CacheLookup]
        public IWebElement Description_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ApplicationId']")]
        [CacheLookup]
        public IWebElement Application_dropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Delete user group']")]
        [CacheLookup]
        public IWebElement Delete_user_group_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Search']")]
        [CacheLookup]
        public IWebElement Search_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//td/a[@href]")]
        [CacheLookup]
        public IWebElement SEARCH_RESULTS_links { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@type='checkbox']")]
        [CacheLookup]
        public IWebElement SEARCH_RESULTS_checkbox { get; set; }

        //View USer Group Details Screen:

        [FindsBy(How = How.XPath, Using = "//*[text()='Edit User Group Details']")]
        [CacheLookup]
        public IWebElement Edit_User_Group_Details_link { get; set; }












        [FindsBy(How = How.XPath, Using = "//*[text()='Add New User']")]
        [CacheLookup]
        public IWebElement Add_New_User_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='removeUsers']")]
        [CacheLookup]
        public IWebElement Remove_Users_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='UserSearchTerm']")]
        [CacheLookup]
        public IWebElement User_Search_text { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='CredentialSearchTerm']")]
        [CacheLookup]
        public IWebElement Credential_Search_text { get; set; }




        [FindsBy(How = How.XPath, Using = "//*[@value='Filter Users']")]
        [CacheLookup]
        public IWebElement Filter_Users_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Filter Credentials']")]
        [CacheLookup]
        public IWebElement Filter_Credentials_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='ah_searchresults_credentials']/tbody/tr/td")]
        [CacheLookup]
        public IWebElement Credential_Search_Results_table { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ah_searchresults_credentials']//*[@type='checkbox']")]
        [CacheLookup]
        public IWebElement Credential_Search_Results_checkbox { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[text()='Add Credentials']")]
        [CacheLookup]
        public IWebElement Add_Credentials_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='removeCredentials']")]
        [CacheLookup]
        public IWebElement Remove_Selected_Credentials_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ah_searchresults']//td")]
        [CacheLookup]
        public IWebElement SEARCH_RESULTS_table { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//*[@value='Add Users to User Group']")]
        [CacheLookup]
        public IWebElement Add_Users_to_User_Group_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Save']")]
        [CacheLookup]
        public IWebElement Save_link { get; set; }
        //Add Users to UserGroup screen:

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_EmailAddress']")]
        [CacheLookup]
        public IWebElement Email_Address_Text { get; set; }

        



        public void SearchByEmail(string emailaddress, log4net.ILog log)
        {


            Email_Address_Text.SendKeys(emailaddress);
            Search_link.Click();
        }


        public void AddUserGrouptoApplication(string applicationName, string usergroup, log4net.ILog log)
        {




            PageFactory.InitElements(driver, this);
            USER_GROUPS_link.Click();


            Create_New_User_Group_link.Click();
            Name_text.SendKeys(usergroup);
            Description_text.SendKeys(usergroup);
            Application_dropdown.SendKeys(applicationName);
            Save_link.Click();

            //Asertion Section:

            string actualUserGroupName;
            try
            {
                actualUserGroupName = Name_text.Text;
            }
            catch
            {
                Thread.Sleep(1000);
                PageFactory.InitElements(driver, this);
                actualUserGroupName = Name_text.Text;
            }
            Assert.AreEqual(usergroup, actualUserGroupName);

            log.Info(Name_text.Text);

            //Go back to home page...
            USERS_link.Click();

            


        }
        public void RemoveUserGroupFromApplication(string applicationName, string usergroup, log4net.ILog log, IWebDriver driver)
        {




            
            USER_GROUPS_link.Click();



            User_Group_Name_text.SendKeys(usergroup);
            Search_link.Click();
            SEARCH_RESULTS_links.Click();

            Delete_user_group_link.Click();

            Confirm_Deletion_checkbox.Click();
            Confirm_Deletion_Of_User_link.Click();


            //ASsertion delete successful
            try
            {
                USER_GROUPS_link.Click();
            }
            catch (TargetInvocationException)
            {
                Thread.Sleep(1000);
                PageFactory.InitElements(driver,this);
                USER_GROUPS_link.Click();
            }
            User_Group_Name_text.SendKeys(usergroup);
            Search_link.Click();
            Assert.IsFalse(isElementPresent(SEARCH_RESULTS_links));


            //back to home page
            USERS_link.Click();

            





        }
        public void AddCredentialtoApplication(string applicationName, string credentialName, string usergroup, log4net.ILog log)
        {


            //instantiate new USer Group page - as this is the easiest route for finding a specific applicaiton via automation (due to the way the application home page is layed out)
            log.Info("Entered AddCredentialToApplication");
            PageFactory.InitElements(driver,this);
            USER_GROUPS_link.Click();


            Application_text.SendKeys(applicationName);
            Search_link.Click();
            APPLICATION_SEARCH_RESULTS_links.Click();

            //Now we are on the application page - so create an application object
            LAFAdmin_Applications_Page applicationsPage = new LAFAdmin_Applications_Page(driver);
            applicationsPage.Add_Credential_link.Click();
            applicationsPage.credential_Name_text.SendKeys(credentialName);
            applicationsPage.credential_Description_text.SendKeys("Desription Test2");
            applicationsPage.Save_link.Click();

            //Assert Credential created:

            applicationsPage.credential_Search_text.SendKeys(credentialName);
            applicationsPage.Filter_Credentials_link.Click();
            Assert.IsTrue(applicationsPage.isElementPresent(applicationsPage.Credential_Values_link));


            applicationsPage.USERS_link.Click();

            
            log.Info("At end of AddCredentialTOApplication");




        }

        public void AddCredentialValueToApplication(string applicationName, string credentialName, string credentialValue, string usergroup, log4net.ILog log)
        {


            //instantiate new Adduserdetailspage

            PageFactory.InitElements(driver, this);
            USER_GROUPS_link.Click();


            Application_text.SendKeys(applicationName);
            Search_link.Click();
            APPLICATION_SEARCH_RESULTS_links.Click();

            LAFAdmin_Applications_Page applicationsPage = new LAFAdmin_Applications_Page(driver);
            applicationsPage.credential_Search_text.SendKeys(credentialName);
            applicationsPage.Filter_Credentials_link.Click();
            applicationsPage.Credential_Values_link.Click();
            applicationsPage.Create_New_Values_link.Click();
            applicationsPage.add_values_textbox.SendKeys(credentialValue);
            applicationsPage.Import_link.Click();


            //Assert Credential created:

            applicationsPage.Value_text.SendKeys(credentialValue);
            applicationsPage.Search_link.Click();
            Assert.IsTrue(applicationsPage.isElementPresent(applicationsPage.SEARCH_RESULTS_checkbox));





            //Go to home page
            applicationsPage.USERS_link.Click();

            
           





        }
        public void AddCredentialToUserGroup(string credentialName, string credentialValue, string usergroup, log4net.ILog log)
        {

            //instantiate new Adduserdetailspage
            PageFactory.InitElements(driver, this);
            USER_GROUPS_link.Click();
            User_Group_Name_text.SendKeys(usergroup);
            Search_link.Click();
            SEARCH_RESULTS_links.Click();


            Add_Credentials_link.Click();

            Credential_name_text.SendKeys(credentialName);
            Credential_value_text.SendKeys(credentialValue);
            try
            {
                Search_link.Click();
            }
            catch
            {
                PageFactory.InitElements(driver, this);
                Search_link.Click();
            }

            SEARCH_RESULTS_checkbox.Click();

            Add_Credentials_to_User_Group_link.Click();

            //Assertion of the above:
            //This should prob be wrapped up in function on the actual page?
            Credential_Search_text.SendKeys(credentialValue);
            Filter_Users_link.Click();

            Assert.IsTrue(isElementPresent(Credential_Search_Results_table));



            log.Info("Credential '" + credentialName + ", value: " + credentialValue + " added to user group '" + usergroup + "'successfully.");

            USERS_link.Click();
            




        }
        public void RemoveCredentialFromUserGroup(string credentialName, string credentialValue, string usergroup, log4net.ILog log)
        {


            //instantiate new Adduserdetailspage
            PageFactory.InitElements(driver, this);
            USER_GROUPS_link.Click();
            User_Group_Name_text.SendKeys(usergroup);
            Search_link.Click();
            SEARCH_RESULTS_links.Click();


            //Assuming here that only one credential will exist with a given value in each group, not neccessarily true
            //in terms of funcitonality, but operationally, this should be the case, fair assumption to make for 
            //this level of testing

            Credential_Search_text.SendKeys(credentialValue);
            Credential_Search_Results_checkbox.Click();
            Remove_Selected_Credentials_link.Click();

            //Now asserting if removed...
            try
            {
                Credential_Search_text.SendKeys(credentialValue);
            }
            catch
            {
                Thread.Sleep(1000);
                PageFactory.InitElements(driver, this);
                Credential_Search_text.SendKeys(credentialValue);
            }

            Filter_Users_link.Click();

            Assert.IsFalse(isElementPresent(SEARCH_RESULTS_table));



            USERS_link.Click();

            





        }









        public void RemoveCredentialFromApplication(string applicationName, string credentialName, string usergroup, log4net.ILog log)
        {


            //Go via User Groups to get to application

            PageFactory.InitElements(driver, this);
            USER_GROUPS_link.Click();


            Application_text.SendKeys(applicationName);
            Search_link.Click();
            APPLICATION_SEARCH_RESULTS_links.Click();
            LAFAdmin_Applications_Page applicationsPage = new LAFAdmin_Applications_Page(driver);

            applicationsPage.credential_Search_text.SendKeys(credentialName);
            applicationsPage.Filter_Credentials_link.Click();
            applicationsPage.SEARCH_RESULTS_checkbox.Click();

            applicationsPage.Delete_Selected_Credential_link.Click();

            //Assert Credential deleted:

            try
            {
                applicationsPage.credential_Search_text.SendKeys(credentialName);
            }


            catch
            {
                Thread.Sleep(1000);
                applicationsPage = new LAFAdmin_Applications_Page(driver);
                applicationsPage.credential_Search_text.SendKeys(credentialName);
            }



            applicationsPage.Filter_Credentials_link.Click();
            Assert.IsFalse(applicationsPage.isElementPresent(applicationsPage.Credential_Values_link));


            applicationsPage.USERS_link.Click();

         




        }






        public void RemoveCredentialValueFromApplication(string applicationName, string credentialName, string credentialValue, string usergroup, log4net.ILog log)
        {


            //find app via User Groups PAge
            PageFactory.InitElements(driver, this);
            
            USER_GROUPS_link.Click();


            Application_text.SendKeys(applicationName);
            Search_link.Click();
            APPLICATION_SEARCH_RESULTS_links.Click();

            LAFAdmin_Applications_Page applicationsPage = new LAFAdmin_Applications_Page(driver);

            applicationsPage.credential_Search_text.SendKeys(credentialName);
            applicationsPage.Filter_Credentials_link.Click();
            try
            {
                applicationsPage.Credential_Values_link.Click();
            }
            catch
            {
                PageFactory.InitElements(driver, applicationsPage);
                applicationsPage.Credential_Values_link.Click();
            }


            applicationsPage.Value_text.SendKeys(credentialValue);
            applicationsPage.Search_link.Click();
            applicationsPage.SEARCH_RESULTS_checkbox.Click();

            applicationsPage.Delete_Selected_Credential_Values_link.Click();

            //ASSERT:
            try
            {
                applicationsPage.Value_text.SendKeys(credentialValue);
            }
            catch
            {
                Thread.Sleep(1000);
                PageFactory.InitElements(driver, applicationsPage);
                applicationsPage.Value_text.SendKeys(credentialValue);
            }
            applicationsPage.Search_link.Click();
            Assert.IsFalse(applicationsPage.isElementPresent(applicationsPage.SEARCH_RESULTS_checkbox));





            applicationsPage.USERS_link.Click();

            applicationsPage = null;
           





        }



        //Add New Users To USer Groups Screen:

        public void AddUserToUserGroup(string emailaddress, string usergroup, log4net.ILog log)
        {

            //instantiate new Adduserdetailspage
            PageFactory.InitElements(driver, this);
            USER_GROUPS_link.Click();
            User_Group_Name_text.SendKeys(usergroup);
            Search_link.Click();
            SEARCH_RESULTS_links.Click();

            //Thread.Sleep(1000);
            Add_New_User_link.Click();
            //LAFAdminManageusersPage usersPage = new LAFAdminManageusersPage(driver);

            Email_Address_Text.SendKeys(emailaddress);
            
            PageFactory.InitElements(driver,this);

            Search_link.Click();





            try
            {
                SEARCH_RESULTS_checkbox.Click();
            }
            catch (TargetInvocationException)
            {
                PageFactory.InitElements(driver,this);
                SEARCH_RESULTS_checkbox.Click();
            }
            Add_Users_to_User_Group_link.Click();
            Thread.Sleep(1000);


            User_Search_text.SendKeys(emailaddress);
            Filter_Users_link.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(isElementPresent(SEARCH_RESULTS_links));

            log.Info("User '" + emailaddress + "' added to user group '" + usergroup + "'successfully.");
            USERS_link.Click();
            




        }





        public void SearchByUserGroupName(string usergroupname, log4net.ILog log)
        {


            User_Group_Name_text.SendKeys(usergroupname);
            Search_link.Click();
        }



        public void DeleteUserFromUserGroup(string emailaddress, string usergroup, log4net.ILog log)
        {


            PageFactory.InitElements(driver, this);
            Thread.Sleep(1000);
            USER_GROUPS_link.Click();
            User_Group_Name_text.SendKeys(usergroup);
           
            try
            {
                Search_link.Click();
                SEARCH_RESULTS_links.Click();
            }
            catch
            {
                PageFactory.InitElements(driver,this);
                Search_link.Click();
                SEARCH_RESULTS_links.Click();
            }

            User_Search_text.SendKeys(emailaddress);
            Filter_Users_link.Click();

            SEARCH_RESULTS_checkbox.Click();
            Remove_Users_link.Click();
            //Now asserting that removal was successful:

            try
            {
                User_Search_text.SendKeys(emailaddress);
            }
            catch (TargetInvocationException)
            {
                //Thread.Sleep(1000);
                PageFactory.InitElements(driver,this);

                User_Search_text.SendKeys(emailaddress);
            }

            Filter_Users_link.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(isElementPresent(SEARCH_RESULTS_links));


            log.Info("User '" + emailaddress + "' removed from user group '" + usergroup + "'successfully.");
            USERS_link.Click();
            





        }

        public bool doesUserGroupExist(string group)
        {
            
            USER_GROUPS_link.Click();
            User_Group_Name_text.SendKeys(group);
            PageFactory.InitElements(driver, this);
            Search_link.Click();
            Thread.Sleep(500);
            if (isElementPresent(SEARCH_RESULTS_links)) return true;
            else return false;

        }


        //Delete User Group Screen:

        [FindsBy(How = How.XPath, Using = "//*[@name='Confirm deletion of user group']")]
        [CacheLookup]
        public IWebElement Confirm_Deletion_Of_User_link { get; set; }


       


        [FindsBy(How = How.XPath, Using = "//*[@id='ConfirmDeletion']")]
        [CacheLookup]
        public IWebElement Confirm_Deletion_checkbox { get; set; }


        //Add Credential to User Group Screen:

        [FindsBy(How = How.XPath, Using = "//*[@value='Add Credentials to User Group']")]
        [CacheLookup]
        public IWebElement Add_Credentials_to_User_Group_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_CredentialId']")]
        [CacheLookup]
        public IWebElement Credential_name_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_CredentialValue']")]
        [CacheLookup]
        public IWebElement Credential_value_text { get; set; }

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



