using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using AutomationTests.TestDataAccess;

using log4net;
using AutomationTests.Methods;

using System.Threading;
using Engine.TestEngine;
using OpenQA.Selenium.Support.UI;
using AutomationTests.PageObjects.Lloyd_s_Applications.LAF_Authenticated_Applications.Overseas_Reporting_System;
using System.Reflection;

namespace AutomationTests.TestCases
{
    
    public class Tests

    {

        private static readonly log4net.ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static bool isLAFloggedin = false;
        //IWebDriver driver;


        //static string LAFSuperAdminEmail = TestEngineClass.LAFSuperAdminEmail;
        //static string LAFSuperAdminPassword = TestEngineClass.LAFSuperAdminPassword;
        static string LAFAdminURL = TestEngineClass.LAFAdminURL;



        //TEST DATA - STATIC (PRE-EXISTING IN SYSTEM):






        //CREATED (and deleted) AS PART OF THIS TEST:
        /**
        private string applicationName = "for test";
        private string existingUserGroup = "Laatch2";

        private string newPassword = "Password12";
        private string gmailPassword = "Clar2017";
        **/

        //string url = ConfigurationManager.AppSettings["URL"];


        //target app data:





        //List<TestData> testData = ExcelDrivenFunctional.GetTestData(tabName);



        /**

        [TestInitialize]
        public void TestSetup()
        {
            //log.Info("Started Test Setup");
            
            driver = BrowserFactory.GetBrowser("Chrome");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

            //driver.Navigate().GoToUrl(url);


            log.Info("created lafuserdata object with this many rows:" + testData.Count);
  

        }
    **/


    
        
        public static void LoginToLAFAdmin(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {
            //Test Data:

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            

            LAFAdminURL = environment.LAFAdminURL;
            
            log.Info("LAFAdminURLintc = " + LAFAdminURL);
            loginPage.LoadUrl(LAFAdminURL, log);
            loginPage.LoginToApplication(currentTest.User, currentTest.UserPW, log);

           
            Thread.Sleep(2000);

            
            

            Assert.IsFalse(driver.PageSource.Contains("Remember me on this computer"));
            isLAFloggedin = true;




        }


        
        public static void LoginToLAFWithLogoutIfNeeded(LAFLogin_And_Logout_Page loginPage, string logoutURL,string User, string UserPW,string targetAppUrl,IWebDriver driver)
        {
            //Test Data:

            //loginPage.initElements(driver);
            try
            {
                loginPage.LoginToApplication(User, UserPW, log);
            }
            catch
            //if here, then was not logged out previously, so log out first and login again
            {
                loginPage.LogoutOfApplication(log, logoutURL);
                loginPage.LoadUrl(targetAppUrl, log);
                loginPage.LoginToApplication(User, UserPW, log);
            }



        }

         


        
        public static void CreateNewUser(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {
            //Test Data:

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch (Exception ex) { log.Info("Already logged in"); }//No action needed 

            

            string newEmail = currentTest.TestUser;
            string newFirstName = "Steve"; // May need to add as parameter??

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);


            LAFAdmin_ManageUsers_Page usersPage = new LAFAdmin_ManageUsers_Page(driver);


            try
            {
                usersPage.DeleteUser(newEmail, log);
                log.Info("User with this email address exists (from previous test) - deleting first to allow test to proceed");
            }
            catch
            {
                log.Info("No user with this email already exists - test can proceed");
            }

            usersPage.CreateNewUser(newEmail, newFirstName, log);



            //If here, test succeeded, so mark currentTest as Pass

            //Update Excel wit hthe relevant result



        }




        


        public static void AddUserGroupToApplication(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 


            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            string newUserGroup = currentTest.userGroupA;

            string applicationName = currentTest.Application;

            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);

            try
            {
                userGroupsPage.RemoveUserGroupFromApplication(applicationName, newUserGroup, log, driver);
                log.Info("UserGroup with this name already exists (from previous test) - deleting first to allow test to proceed");
            }
            catch
            {
                log.Info("No group with this name already exists - test can proceed");
            }

            userGroupsPage.AddUserGrouptoApplication(applicationName, newUserGroup, log);


        }

        
        public static void AddCredentialToApplication(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }catch { log.Info("Already logged in"); }//No action needed 

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            string newCredentialName = currentTest.CredentialA;
            string applicationName = currentTest.Application;
            string existingUserGroup = currentTest.userGroupA;


            log.Info("About to call AddCrednetial Method");
            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);

            try
            {
                userGroupsPage.RemoveCredentialFromApplication(applicationName, newCredentialName, existingUserGroup,log);
                log.Info("Credential with this name already exists (from previous test) - deleting first to allow test to proceed");
            }
            catch
            {
                log.Info("No credential with this name already exists - test can proceed");
            }
            userGroupsPage.AddCredentialtoApplication(applicationName, newCredentialName, existingUserGroup, log);

        }




        
        public static void AddCredentialValueToApplication(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }     catch { log.Info("Already logged in"); }//No action needed 


            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            string CredentialName = currentTest.CredentialA;
            string newCredentialValue = currentTest.CredentialValueA;
            string applicationName = currentTest.Application;
            string existingUserGroup = currentTest.userGroupA;
            
            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);

            try
            {
                userGroupsPage.RemoveCredentialValueFromApplication(applicationName, CredentialName, newCredentialValue, existingUserGroup, log);
                log.Info("Credential Value with this value already exists (from previous test) - deleting first to allow test to proceed");
            }
            catch
            {
                log.Info("No credential with this name already exists - test can proceed");
            }
            

            

            userGroupsPage.AddCredentialValueToApplication(applicationName, CredentialName, newCredentialValue, existingUserGroup, log);
        }

        

        public static void AddUserToUserGroup(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            string newUserGroup = currentTest.userGroupA;
            string newEmail = currentTest.TestUser;
            string LAFSuperAdminEmail = currentTest.LAFAdmin;
            string LAFSuperAdminPassword = currentTest.LAFAdminPW;


            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);

            try
            {
                userGroupsPage.DeleteUserFromUserGroup(newEmail, newUserGroup, log);
                log.Info("User already exists in this group - removing first so can proceed with test");
            }
            catch
            {
                log.Info("No user with this email already exists in group- test can proceed");
            }
            userGroupsPage.AddUserToUserGroup(newEmail, newUserGroup, log);



        }




        

        public static void AddCredentialValueToUserGroup(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            string newCredentialName = currentTest.CredentialA;
            string newCredentialValue = currentTest.CredentialValueA;
            string newUserGroup = currentTest.userGroupA;




            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPage.AddCredentialToUserGroup(newCredentialName, newCredentialValue, newUserGroup, log);



        }




        

        public static void RemoveCredentialValueFromUserGroup(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            string newCredentialName = currentTest.CredentialA;
            string newCredentialValue = currentTest.CredentialValueA;
            string newUserGroup = currentTest.userGroupA;

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);


            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPage.RemoveCredentialFromUserGroup(newCredentialName, newCredentialValue, newUserGroup, log);


        }


        

        public static void RemoveUserFromUserGroup(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            string newUserGroup = currentTest.userGroupA; //i.e. Using one previously created
            string newEmail = currentTest.TestUser;//i.e. As created earlier

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);
            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPage.DeleteUserFromUserGroup(newEmail, newUserGroup, log);


        }





        
        public static void RemoveCredentialValueFromApplication(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            string newCredentialName = currentTest.CredentialA;
            string newCredentialValue = currentTest.CredentialValueA;
            string newUserGroup = currentTest.userGroupA; ; ; //i.e. Using one previously created
            string applicationName = currentTest.Application;

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPage.RemoveCredentialValueFromApplication(applicationName, newCredentialName, newCredentialValue, newUserGroup, log);






        }

        
        public static void RemoveCredentialFromApplication(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 


            string newCredentialName = currentTest.CredentialA;

            string newUserGroup = currentTest.userGroupA;
            string applicationName = currentTest.Application;

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            LAFAdmin_ManageUserGroups_Page userGroupsPAge = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPAge.RemoveCredentialFromApplication(applicationName, newCredentialName, newUserGroup, log);



        }
        
        public static void RemoveUserGroupFromApplication(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            string newUserGroup = currentTest.userGroupA;
            string applicationName = currentTest.Application;
            //i.e. Using one previously created

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);


            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPage.RemoveUserGroupFromApplication(applicationName, newUserGroup, log, driver);



        }

        

        public static void DeleteUser(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //loginPage.LoadUrl(LAFAdminURL, log);

            string newEmail = currentTest.TestUser;


            LAFAdmin_ManageUsers_Page usersPage = new LAFAdmin_ManageUsers_Page(driver);

            usersPage.DeleteUser(newEmail, log);
            currentTest.Result = "PASS";



        }




        
        //This test can not be used with 1 user
        
        public static void DisableEnableUser(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            try { LoginToLAFAdmin(currentTest, environment, appData, driver); }
            catch { log.Info("Already logged in"); }//No action needed 

            
            

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            //Commenting out following line as will assume that user is in SuperAdmins going into the test as a pre-req.

            LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
            userGroupsPage.AddUserToUserGroup(currentTest.TestUser, "LAF_SuperAdmins", log);

            LAFAdmin_ManageUsers_Page usersPage = new LAFAdmin_ManageUsers_Page(driver);
            usersPage.DisableUser(currentTest.TestUser, log);





            loginPage.LogoutOfApplication(log, environment.LAFSecureURL);

            isLAFloggedin = false;


            loginPage.LoadUrl(LAFAdminURL, log);

            loginPage.LoginToApplication(currentTest.TestUser, currentTest.TestUserPassword, log);

            Assert.IsTrue(loginPage.findTextOnPage("The username or password you entered is incorrect.", log));

            loginPage.LoginToApplication(currentTest.User, currentTest.UserPW, log);
            isLAFloggedin = true;

            
            usersPage.EnableUser(currentTest.TestUser, log, driver);



            //Check if Reset password attempts needs clicking - it may not so surround in try/catch block


             try {
                 usersPage.ResetPasswordAttempts(currentTest.TestUser, log);
                 log.Info("password attempts successfully reset");
             }
             catch
             {
                 log.Info("ResetPassword attempts not successful - assuming that it was not visible, hence user does not need password attempts resetting. Continue test");
                 //If exception, assuming that it doesn't need doing
             }




             loginPage.LogoutOfApplication(log,  environment.LAFSecureURL);

            isLAFloggedin = false;
            loginPage.LoadUrl(LAFAdminURL, log);

            //driver.SwitchTo().ActiveElement().SendKeys(Keys.F5);

            //driver.FindElement(By.Name("s")).SendKeys(Keys.F5);
            
            loginPage.LoginToApplication(currentTest.TestUser, currentTest.TestUserPassword, log);

            Assert.IsFalse(loginPage.findTextOnPage("The username or password you entered is incorrect.", log));


            //To cleanup for next test (other tests expect either admin logged in, or nobody logged in as starting point):
            userGroupsPage.DeleteUserFromUserGroup(currentTest.TestUser, "LAF_SuperAdmins", log);
            loginPage.LogoutOfApplication(log, environment.LAFSecureURL);


        }

        

        

        public static void LoginLogout(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);


            
            
            string User = currentTest.User;
            string UserPW = currentTest.UserPW;
            string targetAppUrl = null;
            string targetAppUserGroup = null;
            string assertionText = null;


            switch (environment.Environment)
            {
                case "SYSTEM":

                    targetAppUrl = appData.SYSTEST_URL;
                    targetAppUserGroup = appData.GROUP_SYSTEST;
                    assertionText = appData.AssertionText_SYS;
                    break;

                case "UAT":
                    targetAppUrl = appData.UAT_URL;
                    targetAppUserGroup = appData.GROUP_UAT;
                    assertionText = appData.AssertionText_UAT;
                    break;
                case "PROD":
                    targetAppUrl = appData.PROD_URL;
                    targetAppUserGroup = appData.GROUP_PROD;
                    assertionText = appData.AssertionText_PROD;
                    break;
            }


            




            
            /**

            
            LAFMethods.AddUserToUserGroup(User, targetAppUserGroup, log, driver);
            
                LAFMethods.LogoutOfApplication(log, driver);
          
                
          
            isAdminloggedin = false;
            **/
            try {
                loginPage.LoadUrl(targetAppUrl, log);
            }
            catch(Exception)
            {
                if (!(currentTest.FailReason == null)) { currentTest.FailReason = "URL Load Failed"; };
                
            }


            

            LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, User, UserPW, targetAppUrl, driver);
            





            Thread.Sleep(1000);
            loginPage.initElements(driver);

            try
            {
                Assert.IsTrue(loginPage.findTextOnPage(assertionText, log));
            }
            catch (Exception ex)
            {
                currentTest.FailReason = "Assertion text not found (suggests login failure)";
                log.Error("Login does not appear to be successful - Assertion text not found.");
                throw new Exception(ex.ToString());
            }
            try
            {
                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);
            }
            catch(Exception ex)
            {
                currentTest.FailReason = "Failed to logout";
                log.Error("Logout does not appear to be successful");
                throw new Exception(ex.ToString());
            }
            Thread.Sleep(5000);
            driver.Navigate().Back();
            Thread.Sleep(5000);
            //Some sites still show logged out page until a link is clicked (when they try to get the token, hence click any link if this is the case
            //before testing for logoff page. This has been raised seperately in a query on expected behaviour, hence no need to cause failure at this point
            loginPage.initElements(driver);
            if (loginPage.findTextOnPage(assertionText, log)) 
            {

               
               
                foreach (var element in loginPage.AllLinksOnPageExceptLogOut)
                {
                    try
                    {
                        if (element.Displayed == false ||element==null||element.Text=="") { continue; }
                        element.Click();
                       
                        
                        break;
                    }
                    catch
                    {
                        //Do nothing here - just want to try the next one - we need to click any link and out trying to avoid element not visible errors etc...
                    }
                }
                Thread.Sleep(1000);
                if (loginPage.findTextOnPage(assertionText, log)) { driver.Navigate().Refresh(); }
                
            };
            //COnfirm that user is on login page..

            Thread.Sleep(5000);
            
            try {
                Assert.IsTrue(loginPage.findTextOnPage("Do I need a lloyds.com account?"));
            Assert.IsFalse(loginPage.findTextOnPage(assertionText, log));
                log.Info("login button found");
            }
            catch (Exception ex)
            {

            
                if (currentTest.FailReason == null)
                {
                    currentTest.FailReason = "Not on login page after log-off and clicking back";
                    log.Error("login button not found");
                    
                }
                throw ex;
            }

           
           
      






        }






        public static void RestrictedAgentAtlasRead(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {
            //Test Data

           

            

                LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);


                string targetAppUrl = null;
                string Atlasusergroup = null;

                switch (environment.Environment)
                {
                    case "SYSTEM":

                        targetAppUrl = appData.SYSTEST_URL;
                        Atlasusergroup = appData.GROUP_SYSTEST;
                        log.Info("In SYSTEM, Atlas User group = " + Atlasusergroup);
                        break;

                    case "UAT":
                        targetAppUrl = appData.UAT_URL;
                        Atlasusergroup = appData.GROUP_UAT;
                        break;
                    case "PROD":
                        targetAppUrl = appData.PROD_URL;
                        Atlasusergroup = appData.GROUP_PROD;
                        break;
                }




                string UserA = currentTest.User;
                string UserApw = currentTest.UserPW;

                string millisecond = DateTime.Now.Millisecond.ToString();

                string UserB = String.Format("AtlasRAReadTest{0}@lloyds.com", millisecond);



                //string LAFAdmin = currentTest.User;

                string LAFAdminpw = currentTest.UserPW;

                log.Info("User group is = " + Atlasusergroup);






                loginPage.LoadUrl(targetAppUrl, log);


                LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, currentTest.User, currentTest.UserPW, targetAppUrl, driver);

                //WaitForAjax(driver, 30);



                AtlasPage atlasPage = new AtlasPage(driver);

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait.Until(ExpectedConditions.ElementIsVisible(atlasPage.ajaxTableEntries));
                }
                catch (Exception ex)
                {

                    currentTest.FailReason = "Atlas Page failed to load loaded";
                    
                    throw new Exception(ex.ToString());
                }
                //Check how many users are in the dropdown (for later comparison after additon of a new user - i.e. Check it increments as confirmation
                //that it is reading from the LAF DB
                //      Thread.Sleep(5000);
                int NumberOfMembersAtlasBefore = atlasPage.Assignee_dropdown_members.Count;

                //Can also perform a quick smoke test here - I know there are multiple expected to be here following the 
                //migration, rather than check the exact amount (which could be fluid up until the migration, just checking
                //that there is more than zero would be sufficient.

                try
                {
                    Assert.IsTrue(NumberOfMembersAtlasBefore > 0);
                }
                catch (Exception ex)
                {
                    currentTest.FailReason = "There were 0 users available in drop down at start of test - at least 1 (test exeuction user) should be showing.";
                    
                    throw new Exception(ex.ToString());
                }



                //log into LAF Admin now     
                loginPage.LoadUrl(LAFAdminURL, log);
                //loginPage.LoginToApplication(LAFSuperAdminEmail, LAFSuperAdminPassword, log);

                LAFAdmin_ManageUsers_Page usersPage = new LAFAdmin_ManageUsers_Page(driver);

                usersPage.CreateNewUser(UserB, "AtlasRAReadTest" + millisecond, log);

                //add the user to the group that Atlas Reads from
                LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
                userGroupsPage.AddUserToUserGroup(UserB, Atlasusergroup, log);


                atlasPage = new AtlasPage(driver);

                atlasPage.LoadUrl(targetAppUrl, log);

                //Repeat what was done earlier..
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait.Until(ExpectedConditions.ElementIsVisible(atlasPage.ajaxTableEntries));
                }
                catch (Exception ex)
                {

                    currentTest.FailReason = "Atlas Page failed to load loaded";
                    
                    throw new Exception(ex.ToString());
                }


                Thread.Sleep(5000);
                atlasPage.initElements(driver);
                int NumberOfMembersAtlasAfter = atlasPage.Assignee_dropdown_members.Count;
                log.Info("NumberOfMembersAtlasBefore = " + NumberOfMembersAtlasBefore);
                log.Info("NumberOfMembersAtlasAfter = " + NumberOfMembersAtlasAfter);

                //and make sure that it has incremented by 1
                try
                {
                    Assert.IsTrue(NumberOfMembersAtlasAfter == (NumberOfMembersAtlasBefore + 1));

                    //Finally check that the user IS now in the assignee drop down list
                    Assert.IsTrue(LAFMethods.isStringinDropDown(UserB, atlasPage.Assignee_dropdown, "value"));
                }
                catch (Exception ex)
                {
                    currentTest.FailReason = "New user is not in drop down / total number has not incremented by 1 as expected";
                    
                    throw new Exception(ex.ToString());
                }

                loginPage.LoadUrl(LAFAdminURL, log);
                //loginPage.LoginToApplication(LAFSuperAdminEmail, LAFSuperAdminPassword, log);

                //userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver1);

                userGroupsPage.DeleteUserFromUserGroup(UserB, Atlasusergroup, log);

                usersPage.DeleteUser(UserB, log);

                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);

            }



           
        



        /**
        internal static void WaitForAjax(IWebDriver driver,int timeOut = 15)
        {
            var value = "";
            RepeatUntil(
                () => value = GetJavascriptValue("jQuery.active",driver),
                () => value == "0",
                "Ajax calls did not complete before timeout"
            );
        }
        **/
        /**
        internal static void RepeatUntil(Action repeat, Func<bool> until, string errorMessage, int timeout = 15)
        {
            var end = DateTime.Now + TimeSpan.FromSeconds(timeout);
            var complete = false;

            while (DateTime.Now < end)
            {
                repeat();
                try
                {
                    if (until())
                    {
                        complete = true;
                        break;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(500);
            }
            if (!complete)
                throw new TimeoutException(errorMessage);
        }
         * **/

        internal static string GetJavascriptValue(string variableName,IWebDriver driver)
        {
            var id = Guid.NewGuid().ToString();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            var value = jse.ExecuteScript(String.Format(@"window.$('body').append(""<input type='text' value='""+{0}+""' id='{1}'/>"");", variableName, id));
            return value.ToString();
           
       
        }

        
        public static void RestrictedAgentLatchRead(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)

        {

            
            
          
                string targetAppUrl = null;
                string Latchusergroup = null;

                switch (environment.Environment)
                {
                    case "SYSTEM":

                        targetAppUrl = appData.SYSTEST_URL;
                        Latchusergroup = appData.GROUP_SYSTEST;
                        break;

                    case "UAT":
                        targetAppUrl = appData.UAT_URL;
                        Latchusergroup = appData.GROUP_UAT;
                        break;
                    case "PROD":
                        targetAppUrl = appData.PROD_URL;
                        Latchusergroup = appData.GROUP_PROD;
                        break;
                }

                //Test Data
                string day = DateTime.Now.Day.ToString();
                string UserA = currentTest.User;

                string millisecond = DateTime.Now.Millisecond.ToString();

                string UserB = String.Format("LatchRAtest{0}@lloyds.com", millisecond);
                string UserBFisrtName = String.Format("LatchTest{0}", millisecond);
                string UserBFullName = String.Format("{0} Test", UserBFisrtName);
                string UserApw = currentTest.UserPW;
                string LAFAdmin = UserA;
                string LAFAdminpw = UserApw;


                LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);

                
                loginPage.LoadUrl(LAFAdminURL, log);

                LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, currentTest.User, currentTest.UserPW, targetAppUrl, driver);

                LAFAdmin_ManageUsers_Page usersPage = new LAFAdmin_ManageUsers_Page(driver);

                usersPage.CreateNewUser(UserB, UserBFisrtName, log);


                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);

                /**if (isAdminloggedin == true)
                {
                    loginPage.LogoutOfApplication(log, environment.LAFSecureURL);
                }
                **/

                //Login to Latch:            
                
                loginPage.LoadUrl(targetAppUrl, log);

                LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, currentTest.User, currentTest.UserPW, targetAppUrl, driver);
                
                LATCHPage latchPage = new LATCHPage(driver);
                Thread.Sleep(5000);
                latchPage.Submission_link.Click();
                Thread.Sleep(10000);
                //Check how many users are in the dropdown (for later comparison after additon of a new user - i.e. Check it increments as confirmation
                //that it is reading from the LAF DB
                int NumberOfMembersLatchBefore = latchPage.Assignee_dropdown_members.Count;
                log.Info("number of members of LAtch =" + NumberOfMembersLatchBefore);
                log.Info(NumberOfMembersLatchBefore + latchPage.Assignee_dropdown_members.ToString());

                //Can also perform a quick smoke test here - I know there are multiple expected to be here following the 
                //migration, rather than check the exact amount (which could be fluid up until the migration, just checking
                //that there is more than zero would be sufficient.
                Assert.IsTrue(NumberOfMembersLatchBefore > 10);


                //A check to make sure that the user we will add later is not already in the group - i.e. 
                //confirm pre-requisites     
                Assert.IsFalse(LAFMethods.isStringinDropDown(UserBFullName, latchPage.Assignee_dropdown, "label"));

                //log into LAF Admin now     
                loginPage.LoadUrl(LAFAdminURL, log);
                //loginPage.LoginToApplication(UserA, UserApw, log);


                //add a user to the group that Latch Reads from
                LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);
                userGroupsPage.AddUserToUserGroup(UserB, Latchusergroup, log);


                latchPage = new LATCHPage(driver);

                latchPage.LoadUrl(targetAppUrl, log);
                Thread.Sleep(5000);
                latchPage.Submission_link.Click();


                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select")));



                //Repeat what was done earlier..
                int NumberOfMembersLatchAfter = latchPage.Assignee_dropdown_members.Count;
                log.Info("NumberOfMembersLatchBefore = " + NumberOfMembersLatchBefore);
                log.Info("NumberOfMembersLatchAfter = " + NumberOfMembersLatchAfter);




                //and make sure that it has incremented by 1
                Assert.IsTrue(NumberOfMembersLatchAfter == (NumberOfMembersLatchBefore + 1));

                //Finally check that the user IS now in the assignee drop down list
                Assert.IsTrue(LAFMethods.isStringinDropDown(UserBFullName, latchPage.Assignee_dropdown, "label"));




                loginPage.LoadUrl(LAFAdminURL, log);
                //loginPage.LoginToApplication(LAFSuperAdminEmail, LAFSuperAdminPassword, log);

                //userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver1);
                userGroupsPage.DeleteUserFromUserGroup(UserB, Latchusergroup, log);

                usersPage.DeleteUser(UserB, log);

                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);

            }
           

        



        public static void RestrictedAgent_SecureStore(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {


           


                string secureStoreURL = null;
                string secureStoreAdminUserGroup = null;
                string entityCode = "SY_LTPTest" + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString();
                string expectedGroupNamePattern = String.Format("*{0}*", entityCode);

                switch (environment.LAFSecureURL)
                {
                    case "SYSTEM":

                        secureStoreURL = appData.SYSTEST_URL;
                        secureStoreAdminUserGroup = appData.GROUP_SYSTEST;


                        break;

                    case "UAT":
                        secureStoreURL = appData.UAT_URL;
                        secureStoreAdminUserGroup = appData.GROUP_UAT;



                        break;
                    case "PROD":
                        secureStoreURL = appData.PROD_URL;
                        secureStoreAdminUserGroup = appData.GROUP_PROD;
                        break;
                }


                string secureStoreAdminURL = secureStoreURL + "/sites/admin/_layouts/viewlsts.aspx";



                //string secureStoreAdminUserGroup = "securestore_ma02_site_owners";
                //string secureStoreAdminUserGroup = currentTest.userGroupA;


                string entityName = "LTP Test Entity " + entityCode;
                string testUserA = currentTest.User;
                string testUserAPassword = currentTest.UserPW;


                LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);

                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);




                


                /**
                try
                {

                    LoginToLAFAdmin(currentTest, environment, appData, driver);
                }
                catch
                {
                    log.Info("Already logged in. Continue with test. No exception");
                }

                 * **/
                

                /**
            
                userGroupsPage.AddUserToUserGroup(testUserA, secureStoreAdminUserGroup, log);







                Assert.IsFalse(userGroupsPage.doesUserGroupExist(expectedGroupNamePattern));
          
            

                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);
                **/

                loginPage.LoadUrl(secureStoreURL, log);


                if (environment.Environment == "SYSTEM")
                {

                    var element = driver.FindElement(By.XPath("//select"));
                    var selectElement = new SelectElement(element);
                    selectElement.SelectByIndex(2);
                    log.Info("Click Worked");

                }



                loginPage.LoginToApplication(currentTest.User, currentTest.UserPW, log);

                Thread.Sleep(3000);
                //loginPage.LoginToApplication(testUserA, testUserAPassword, log);



                //First create a new syndicate:
                SecureStorePage securestorepage = new SecureStorePage(driver);
                securestorepage.LoadUrl(secureStoreAdminURL, log);
                Thread.Sleep(1000);
                securestorepage.Synidicates_link.Click();
                Thread.Sleep(1000);
                securestorepage.Add_new_item_link.Click();
                Thread.Sleep(5000);

                driver.SwitchTo().Frame(securestorepage.iframe2);

                // driver.switchTo.frame(WebElement frameElement)
                //driver.SwitchTo().Frame(0);



                securestorepage.EntityCode_text.SendKeys(entityCode);
                securestorepage.EntityName_text.SendKeys(entityName);
                securestorepage.initElements(driver);

                driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
                if (environment.Environment == "SYSTEM") { driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab); }
                driver.SwitchTo().ActiveElement().SendKeys(Keys.Return);









                //Then login to LAF Admin and search for the user groups that should have been created as a 
                //result of that
                //loginPage.LogoutOfApplication(log);
                loginPage.LoadUrl(LAFAdminURL, log);
                //loginPage.LoginToApplication(LAFSuperAdminEmail, LAFSuperAdminPassword, log);



                LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);

                try
                {
                    Assert.IsTrue(userGroupsPage.doesUserGroupExist(expectedGroupNamePattern));
                }
                catch
                {
                    //if not there yet, maybe delayed (sometimes happens in systest. Wait and check again).
                    Thread.Sleep(40000);
                    Assert.IsTrue(userGroupsPage.doesUserGroupExist(expectedGroupNamePattern));
                }
               

                
                
                



                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);

            
        }

        public static void ORS_CheckDocumentService(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {
            
           

                string User = currentTest.User;
                string UserPW = currentTest.UserPW;
                string targetAppUrl = null;
                string targetAppUserGroup = null;
                string assertionText = null;

                switch (environment.Environment)
                {
                    case "SYSTEM":

                        targetAppUrl = appData.SYSTEST_URL;
                        targetAppUserGroup = appData.GROUP_SYSTEST;
                        assertionText = appData.AssertionText_SYS;
                        break;

                    case "UAT":
                        targetAppUrl = appData.UAT_URL;
                        targetAppUserGroup = appData.GROUP_UAT;
                        assertionText = appData.AssertionText_UAT;
                        break;
                    case "PROD":
                        targetAppUrl = appData.PROD_URL;
                        targetAppUserGroup = appData.GROUP_PROD;
                        assertionText = appData.AssertionText_PROD;
                        break;
                }

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);



                try
                {
                    loginPage.LoadUrl(targetAppUrl, log);
                }
                catch (Exception)
                {
                    if (!(currentTest.FailReason == null)) { currentTest.FailReason = "URL Load Failed"; };

                }


                
                LoginToLAFWithLogoutIfNeeded(loginPage,environment.LAFSecureURL,User,UserPW,targetAppUrl,driver);
                    



                ORS_HomePage oRS_HomePAge1 = new ORS_HomePage(driver);

                ORS_MaintainPage oRS_MaintainPage1 = oRS_HomePAge1.selectAndUpdate("0382");

                ORS_DocumentPackPage oRS_DocumentPackPage = oRS_MaintainPage1.clickFirstDocumentLink();

                ORS_DocumentDownloadPopUpWindow oRS_DocumentDownloadPopUpWindow1 = oRS_DocumentPackPage.clickPDFLink();




                
                    oRS_DocumentPackPage = oRS_DocumentDownloadPopUpWindow1.DownloadFile(300);
                
               
                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);



            }
            
        



        public static void CheckSlidingSessionCookieIsUpdated_Atlas(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

           
            
             LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);

            


            string User = currentTest.User;
            string UserPW = currentTest.UserPW;
            string targetAppUrl = null;
            string targetAppUserGroup = null;
            string assertionText = null;
            string cookieName = "FedAuth_Atlas";

            int slidingSessionInterval = 4;

            switch (environment.Environment)
            {
                case "SYSTEM":

                    targetAppUrl = appData.SYSTEST_URL;
                    targetAppUserGroup = appData.GROUP_SYSTEST;
                    assertionText = appData.AssertionText_SYS;
                    break;

                case "UAT":
                    targetAppUrl = appData.UAT_URL;
                    targetAppUserGroup = appData.GROUP_UAT;
                    assertionText = appData.AssertionText_UAT;
                    break;
                case "PROD":
                    targetAppUrl = appData.PROD_URL;
                    targetAppUserGroup = appData.GROUP_PROD;
                    assertionText = appData.AssertionText_PROD;
                    break;
            }
            
            //This assumes 20 min expiry and 4 min interval
            
            
            
            //string LAFAdmin = UserA;
            // string LAFAdminpw = UserApw;




            
            loginPage.LoadUrl(targetAppUrl, log);

            LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, User, UserPW, targetAppUrl, driver);
            AtlasPage atlasPage = new AtlasPage(driver);
            Thread.Sleep(3000);

            Assert.IsTrue(LAFMethods.IsCookiePresent(cookieName, driver));

            Cookie FedAuth1 = driver.Manage().Cookies.GetCookieNamed(cookieName);

            Thread.Sleep(1000);
            //Atlas: driver.FindElement(By.XPath("//*[@title='Company Search']"));
            atlasPage.AnyLink.Click();
            //Thread.Sleep(3000);

            Cookie FedAuth2 = driver.Manage().Cookies.GetCookieNamed(cookieName);
            log.Info("(FedAuth1.Value: " + FedAuth1.Value);
            log.Info("(FedAuth2.Value: " + FedAuth2.Value);
            Assert.IsTrue(FedAuth1.Value == FedAuth2.Value);

            Thread.Sleep((slidingSessionInterval * 60000) + 1000);

            atlasPage.initElements(driver);

            atlasPage.Company_Search_link.Click();
            atlasPage.Tasks_link.Click();
            

            Thread.Sleep(20000);
            atlasPage.initElements(driver);
            atlasPage.Company_Search_link.Click();
            Cookie FedAuth3 = driver.Manage().Cookies.GetCookieNamed(cookieName);
            log.Info("(FedAuth3.Value: " + FedAuth3.Value);
            log.Info("(FedAuth2.Value: " + FedAuth2.Value);
            Assert.IsFalse(FedAuth2.Value == FedAuth3.Value);

            loginPage.LogoutOfApplication(log, environment.LAFSecureURL);

           
        }

        public static void CheckSlidingSessionCookieIsUpdatedOnAjaxCall_Latch(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {

           
            
            
            string User = currentTest.User;
            string UserPW = currentTest.UserPW;
            string targetAppUrl = null;
            string targetAppUserGroup = null;
            string assertionText = null;
            string cookieName = "FedAuth_LATCH";

            int slidingSessionInterval = 4;

            switch (environment.Environment)
            {
                case "SYSTEM":

                    targetAppUrl = appData.SYSTEST_URL;
                    targetAppUserGroup = appData.GROUP_SYSTEST;
                    assertionText = appData.AssertionText_SYS;
                    break;

                case "UAT":
                    targetAppUrl = appData.UAT_URL;
                    targetAppUserGroup = appData.GROUP_UAT;
                    assertionText = appData.AssertionText_UAT;
                    break;
                case "PROD":
                    targetAppUrl = appData.PROD_URL;
                    targetAppUserGroup = appData.GROUP_PROD;
                    assertionText = appData.AssertionText_PROD;
                    break;
            }

            //This assumes 20 min expiry and 4 min interval



            //string LAFAdmin = UserA;
            // string LAFAdminpw = UserApw;

           string policyNumber = "LTPTest"; 

            LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);
            
            loginPage.LoadUrl(targetAppUrl, log);

            LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, User, UserPW, targetAppUrl, driver);
            LATCHPage latchPage = new LATCHPage(driver);

                   
            
            Assert.IsTrue(LAFMethods.IsCookiePresent(cookieName, driver));

            Cookie FedAuth1 = driver.Manage().Cookies.GetCookieNamed(cookieName);

            
            //Atlas: driver.FindElement(By.XPath("//*[@title='Company Search']"));
            latchPage.SubmitNewPolicy(driver, policyNumber);
            //Thread.Sleep(3000);


            //Adding explicit wait to take account of asynchronous (ajax) behaviour (Webdriver does not register Ajax loads)
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));

            wait.Until(ExpectedConditions.ElementIsVisible(latchPage.PolicySubmitted_By));
            
            Cookie FedAuth2 = driver.Manage().Cookies.GetCookieNamed(cookieName);
            log.Info("(FedAuth1.Value: " + FedAuth1.Value);
            log.Info("(FedAuth2.Value: " + FedAuth2.Value);
            Assert.IsTrue(FedAuth1.Value == FedAuth2.Value);

            Thread.Sleep((slidingSessionInterval * 60000) + 1000);


            latchPage.SubmitNewPolicy(driver, policyNumber);
            wait.Until(ExpectedConditions.ElementIsVisible(latchPage.PolicySubmitted_By));
            //Hopefully this won't be needed: Thread.Sleep(3000);
            Cookie FedAuth3 = driver.Manage().Cookies.GetCookieNamed(cookieName);
            log.Info("(FedAuth3.Value: " + FedAuth3.Value);
            log.Info("(FedAuth2.Value: " + FedAuth2.Value);
            Assert.IsFalse(FedAuth2.Value == FedAuth3.Value);

            loginPage.LogoutOfApplication(log, environment.LAFSecureURL);


            }
            
        






        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }


        


        public static void RestrictedAgent_AtlasWrite(TestDataObject currentTest, EnvironmentSettingsObject environment, ApplicationDataObject appData, IWebDriver driver)
        {


            
            


                string targetAppUrl = null;
                string Atlasusergroup = null;

                string companyName = "LTP_Test " + GetTimestamp(DateTime.Now);

                switch (environment.Environment)
                {
                    case "SYSTEM":

                        targetAppUrl = appData.SYSTEST_URL;
                        Atlasusergroup = appData.GROUP_SYSTEST;
                        log.Info("In SYSTEM, Atlas User group = " + Atlasusergroup);
                        break;

                    case "UAT":
                        targetAppUrl = appData.UAT_URL;
                        Atlasusergroup = appData.GROUP_UAT;
                        break;
                    case "PROD":
                        targetAppUrl = appData.PROD_URL;
                        Atlasusergroup = appData.GROUP_PROD;
                        break;
                }



                string UserA = currentTest.User;
                string UserApw = currentTest.UserPW;

                string millisecond = DateTime.Now.Millisecond.ToString();

                string UserB = String.Format("AtlasRAReadTest{0}@lloyds.com", millisecond);



                //string LAFAdmin = currentTest.User;

                string LAFAdminpw = currentTest.UserPW;

                log.Info("User group is = " + Atlasusergroup);

                LAFLogin_And_Logout_Page loginPage = new LAFLogin_And_Logout_Page(driver);




                loginPage.LoadUrl(targetAppUrl, log);
                LoginToLAFWithLogoutIfNeeded(loginPage, environment.LAFSecureURL, UserA, UserApw, targetAppUrl, driver);


                //WaitForAjax(driver, 30);



                AtlasPage atlasPage = new AtlasPage(driver);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementIsVisible(atlasPage.ajaxTableEntries));



                atlasPage.Company_Search_link.Click();

                atlasPage.initElements(driver);

                atlasPage.NewServiceCompany_link.Click();

                atlasPage.CompanyName_text.SendKeys(companyName);
                atlasPage.Email_text.SendKeys("LTPTest@test.com");

                atlasPage.CompanySubmit_button.Click();



                loginPage.LoadUrl(LAFAdminURL, log);

                try
                {

                    LoginToLAFAdmin(currentTest, environment, appData, driver);
                }
                catch
                {
                    log.Info("Already logged in. Continue with test. No exception");
                }

                LAFAdmin_ManageUserGroups_Page userGroupsPage = new LAFAdmin_ManageUserGroups_Page(driver);





                string group = String.Format("*{0}*", companyName);



                Assert.IsTrue(userGroupsPage.doesUserGroupExist(group));





                loginPage.LogoutOfApplication(log, environment.LAFSecureURL);


            }
           

        

    }

}