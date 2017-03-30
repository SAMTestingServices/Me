using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading;

namespace AutomationTests.PageObjects
{
    public class LAFAdmin_ManageUsers_Page : PageMaster
    {
        private IWebDriver driver;


        public LAFAdmin_ManageUsers_Page(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ReInitElements(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        //MAnage Users Home Screen


        /**
        [FindsBy(How = How.XPath, Using = "//*[text()='Delete user account']")]
        [CacheLookup]
        public IWebElement Delete_user_account_link { get; set; }
            **/

        [FindsBy(How = How.XPath, Using = "//*[text()='Create New User']")]
        [CacheLookup]
        public IWebElement Create_New_User_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@ah='EmailAddress']")]
        [CacheLookup]
        public IWebElement EmailAddressesInTableList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='SearchOptions_EmailAddress']")]
        [CacheLookup]
        public IWebElement Email_Address_Text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Add Users to User Group']")]
        [CacheLookup]
        public IWebElement Add_Users_To_User_Group_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//td/a[@href]")]
        [CacheLookup]
        public IWebElement SEARCH_RESULTS_links { get; set; }




        /**
                public Boolean IsUserPresent(String email, log4net.ILog log)
                {
                    if (EmailAddressesInTableList.ToString().Contains(email))

                        return true;
                    else
                        log.Error("Did not find email on page: " + EmailAddressesInTableList.ToString());
                        return false;
                }
            **/







        //View User Screen:


        [FindsBy(How = How.XPath, Using = "//*[text()='Delete user account']")]
        [CacheLookup]
        public IWebElement Delete_user_account_link { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[text()='Disable user account']")]
        [CacheLookup]
        public IWebElement Disable_user_account_link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text()='Reset password attempts']")]
        [CacheLookup]
        public IWebElement Reset_password_attempts_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Enable user account']")]
        [CacheLookup]
        public IWebElement Enable_user_account_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Resend activation email']")]
        [CacheLookup]
        public IWebElement Resend_activation_email_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Reset user password']")]
        [CacheLookup]
        public IWebElement Reset_user_password_link { get; set; }




        [FindsBy(How = How.XPath, Using = "//*[text()='Change email address']")]
        [CacheLookup]
        public IWebElement Change_email_address_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnEditUserDetails']")]
        [CacheLookup]
        public IWebElement Edit_User_Details { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Add New User Group']")]
        [CacheLookup]
        public IWebElement Add_New_User_Group_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Statistics.LastLoginDate']")]
        [CacheLookup]
        public IWebElement Last_logged_in_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Statistics.IsDisabled']")]
        [CacheLookup]
        public IWebElement Account_disabled_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Statistics.RegistrationDate']")]
        [CacheLookup]
        public IWebElement Date_created_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Statistics.IsPasswordLocked']")]
        [CacheLookup]
        public IWebElement Password_locked_text { get; set; }

        //Edit User Details Page:

        [FindsBy(How = How.XPath, Using = "//*[@value='Save']")]
        [CacheLookup]
        public IWebElement Save_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Submit']")]
        [CacheLookup]
        public IWebElement Submit_link { get; set; }

        //*[text()='Cancel']

        [FindsBy(How = How.XPath, Using = "//*[text()='Cancel']")]
        [CacheLookup]
        public IWebElement Cancel_link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='EmailAddress']")]
        [CacheLookup]
        public IWebElement Email_Address_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PersonalDetails_Title']")]
        [CacheLookup]
        public IWebElement Title_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PersonalDetails_FirstName']")]
        [CacheLookup]
        public IWebElement First_Name_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PersonalDetails_LastName']")]
        [CacheLookup]
        public IWebElement Last_Name_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PersonalDetails_CountryOfResidenceId']")]
        [CacheLookup]
        public IWebElement Country_of_Residence_dropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PersonalDetails_Telephone']")]
        [CacheLookup]
        public IWebElement Contact_Telephone_Number_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PersonalDetails_IsInsuranceProfessional']")]
        [CacheLookup]
        public IWebElement Are_you_an_insurance_professional_dropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='CompanyDetails_JobTitle']")]
        [CacheLookup]
        public IWebElement Job_title_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='CompanyDetails_CompanyName']")]
        [CacheLookup]
        public IWebElement Company_name_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='CompanyDetails_OrganisationTypeId']")]
        [CacheLookup]
        public IWebElement Organisation_type_dropdown { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        [CacheLookup]
        public IWebElement Password_text { get; set; }

        [FindsBy(How = How.Id, Using = "ReEnteredPassword")]
        [CacheLookup]
        public IWebElement Re_enter_your_password_text { get; set; }

        [FindsBy(How = How.Id, Using = "AcceptedTermsAndConditions")]
        [CacheLookup]
        public IWebElement I_accept_checkbox { get; set; }


        //Delete User Screen:

        [FindsBy(How = How.XPath, Using = "//*[@name='Confirm deletion of user']")]
        [CacheLookup]
        public IWebElement Confirm_Deletion_Of_User_link { get; set; }


        //Cancel Link - already exists elsewhere in class (with same locator) so need to repeat


        [FindsBy(How = How.XPath, Using = "//*[@id='ConfirmDeletion']")]
        [CacheLookup]
        public IWebElement I_wish_to_delete_this_user_from_laf_checkbox { get; set; }


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

        [FindsBy(How = How.XPath, Using = "//*[@value='Search']")]
        [CacheLookup]
        public IWebElement Search_link { get; set; }




        public void DeleteUser(string emailaddress, log4net.ILog log)
        {

            //instantiate new Adduserdetailspage

            PageFactory.InitElements(driver, this);
            USERS_link.Click();

            Email_Address_Text.SendKeys(emailaddress);
            Search_link.Click();
            SEARCH_RESULTS_links.Click();

            Delete_user_account_link.Click();

            I_wish_to_delete_this_user_from_laf_checkbox.Click();
            Confirm_Deletion_Of_User_link.Click();


            try
            {
                Email_Address_Text.SendKeys(emailaddress);
            }
            catch
            {
                PageFactory.InitElements(driver, this);
                Email_Address_Text.SendKeys(emailaddress);
            }


            Search_link.Click();


            Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));
            USERS_link.Click();
            

            log.Info("User '" + emailaddress + "' deleted successfully.");
            /**
            try
            {
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            catch
            {

                Thread.Sleep(1000);
                usersPage = new LAFAdminManageusersPage(driver);
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            
    **/
        }

        public void ResetPasswordAttempts(string emailaddress, log4net.ILog log)
        {

            //instantiate new Adduserdetailspage
            
            USERS_link.Click();
            try
            {
                Email_Address_Text.SendKeys(emailaddress);
            }
            catch (StaleElementReferenceException ex)
            {

                log.Info("Staleblock" + ex.ToString());
                PageFactory.InitElements(driver, this);
                Email_Address_Text.SendKeys(emailaddress);

            }

            Search_link.Click();
            try
            {
                SEARCH_RESULTS_links.Click();
            }
            catch (Exception)
            {
                PageFactory.InitElements(driver, this);
                SEARCH_RESULTS_links.Click();
            }

            //Check that it is visible (i.e. USer needs to have attempts reset)
            Assert.IsTrue(isElementPresent(Reset_password_attempts_link));

            Reset_password_attempts_link.Click();

            driver.SwitchTo().ActiveElement().SendKeys("test");
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Return);

            //Ensure that it has been clicked
            Assert.IsFalse(isElementPresent(Reset_password_attempts_link));





            try
            {
                USERS_link.Click();
            }
            catch (Exception)
            {
                PageFactory.InitElements(driver, this);
                USERS_link.Click();
            }
            

            log.Info("User '" + emailaddress + "' password reset  successfully.");
            /**
            try
            {
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            catch
            {

                Thread.Sleep(1000);
                usersPage = new LAFAdminManageusersPage(driver);
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            
    **/
        }


        public void DisableUser(string emailaddress, log4net.ILog log)
        {

            //instantiate new Adduserdetailspage
            LAFAdmin_ManageUsers_Page usersPage = new LAFAdmin_ManageUsers_Page(driver);
            USERS_link.Click();
            Email_Address_Text.SendKeys(emailaddress);
            Search_link.Click();
            SEARCH_RESULTS_links.Click();

            try
            {
                Disable_user_account_link.Click();
                driver.SwitchTo().ActiveElement().SendKeys("test");
                driver.SwitchTo().ActiveElement().SendKeys(Keys.Return);
            }
            catch (NoSuchElementException ex)
            {
                //If failed, this is most likely because the user is disabled
                Assert.IsTrue(isElementPresent(Enable_user_account_link));
                //If so continue test
                log.Info("User already disabled. Continue Test");
            }


            Assert.IsTrue(isElementPresent(Enable_user_account_link));

            try
            {
                USERS_link.Click();
            }
            catch
            {
                PageFactory.InitElements(driver,this);
                USERS_link.Click();

            }
            usersPage = null;

            log.Info("User '" + emailaddress + "' disabled successfully.");
            /**
            try
            {
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            catch
            {

                Thread.Sleep(1000);
                usersPage = new LAFAdminManageusersPage(driver);
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            
    **/
        }

        public  void EnableUser(string emailaddress, log4net.ILog log, IWebDriver driver)
        {

            //instantiate new Adduserdetailspage
            
            
            try
            {
                USERS_link.Click();
                Email_Address_Text.SendKeys(emailaddress);
            }
            catch (Exception ex)
            {
                PageFactory.InitElements(driver, this);
                
                log.Info("Staleblock" + ex.ToString());
                USERS_link.Click();
                Email_Address_Text.SendKeys(emailaddress);

            }

            Search_link.Click();
            try
            {
                SEARCH_RESULTS_links.Click();
            }
            catch (Exception)
            {
                PageFactory.InitElements(driver, this);
                SEARCH_RESULTS_links.Click();
            }

            Enable_user_account_link.Click();

            driver.SwitchTo().ActiveElement().SendKeys("test");
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Return);

            Assert.IsTrue(isElementPresent(Disable_user_account_link));

            //Now check if reset password link is available - if it is click this too, to ensure that user is actually enabled
            //May move this to another test eventually



            try
            {
                USERS_link.Click();
            }
            catch (Exception)
            {
                PageFactory.InitElements(driver, this);
                USERS_link.Click();
            }
            

            log.Info("User '" + emailaddress + "' deleted successfully.");
            /**
            try
            {
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
            catch
            {

                Thread.Sleep(1000);
                usersPage = new LAFAdminManageusersPage(driver);
                Assert.IsFalse(isElementPresent((SEARCH_RESULTS_links)));

            }
                
    **/
        }

        //Methods:

        public void CreateNewUser(string emailaddress, string firstName, log4net.ILog log)
        {






            //Create an instance of the LAFAdmin_ManageUsers_Page
            //I will just call this instance 'usersPage' for short:
            log.Info("Test Start: CreateNewUser, username=" + emailaddress);
            
            


            try
            {
                USERS_link.Click();
                Create_New_User_link.Click();
            }
            catch
            {
                PageFactory.InitElements(driver,this);
                USERS_link.Click();
                Create_New_User_link.Click();
            }
            Email_Address_text.SendKeys(emailaddress);
            Title_text.SendKeys("Mr");
            First_Name_text.SendKeys(firstName);
            Last_Name_text.SendKeys("Test");
            Country_of_Residence_dropdown.SendKeys("United Kingdom");
            Contact_Telephone_Number_text.SendKeys("123");
            Are_you_an_insurance_professional_dropdown.SendKeys("No");
            Job_title_text.SendKeys("Tester");
            Company_name_text.SendKeys("Testing LTD");
            Organisation_type_dropdown.SendKeys("Lloyds corporation");

            Save_link.Click();

            //Assertion:

            Email_Address_Text.SendKeys(emailaddress);
            Search_link.Click();
            Assert.IsTrue(SEARCH_RESULTS_links.Displayed);

            log.Info("New User Created Successfully");


            try
            {
                USERS_link.Click();
            }
            catch
            {
                PageFactory.InitElements(driver,this);
                USERS_link.Click();

            }


        }

        




    

        public void SearchByEmail(string emailaddress, log4net.ILog log)
        {


            Email_Address_Text.SendKeys(emailaddress);
            Search_link.Click();
        }



    }


}

            
            