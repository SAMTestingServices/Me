using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTests.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.IO;

namespace AutomationTests.Methods
{
    public static class LAFMethods
    {
       

        public static bool IsCookiePresent(string cookieName, IWebDriver driver)
        {
            return driver.Manage().Cookies.GetCookieNamed(cookieName) != null;
        }

        public static bool isStringinDropDown(string text, IWebElement element, string attribute)
        {



            SelectElement selectList = new SelectElement(element);
            IList<IWebElement> options = selectList.Options;

            {
                foreach (var option in options)
                {
                    if (option.GetAttribute(attribute) == text)
                    {
                        return true;
                    }


                }
                //If it reaches here then it wasn't in the list so return false
                return false;
            }

        }

        


        public static int CheckNumberOfFilesinDownloadFolder()
        {
            
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            DirectoryInfo info = new DirectoryInfo(@userProfile + @"\AppData\Local\Temp\Downloads");
            return info.GetFiles().Length;
            
        }

        

    }
}