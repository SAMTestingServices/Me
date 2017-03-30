using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObjects.Lloyd_s_Applications.LAF_Authenticated_Applications.Overseas_Reporting_System
{
    public class ORS_DocumentPackPage : PageMaster
    {

        [FindsBy(How = How.XPath, Using = "//a[text()='PDF']")]
        private IWebElement PDFLink { get; set; }

        public ORS_DocumentPackPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ORS_DocumentDownloadPopUpWindow clickPDFLink()
        {
            
            // Get the current window handle so you can switch back later.
            string currentHandle = driver.CurrentWindowHandle;

           
            // The Click method of the PopupWindowFinder class will click
            // the desired element, wait for the popup to appear, and return
            // the window handle to the popped-up browser window. Note that
            // you still need to switch to the window to manipulate the page
            // displayed by the popup window.
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            string popupWindowHandle = finder.Click(PDFLink);

            driver.SwitchTo().Window(popupWindowHandle);

            // Do whatever you need to on the popup browser, then...
            //driver.Close();
            //driver.SwitchTo().Window(currentHandle);
            return new ORS_DocumentDownloadPopUpWindow(driver,currentHandle);
        }

    }
}
