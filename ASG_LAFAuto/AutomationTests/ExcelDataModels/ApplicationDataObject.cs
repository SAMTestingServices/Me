
namespace AutomationTests.TestDataAccess
{
    public class ApplicationDataObject
    {
        public string Application { get; set; }
        public string AUTHENTICATES { get; set; }
        public string Site { get; set; }//Put SysTest_SITE into Site if SYS
        public string GROUP { get; set; }//Put SysTest Group into Group if Sys


        public string GROUP_SYSTEST { get; set; }//Put SysTest Group into Group if Sys
        public string GROUP_UAT { get; set; }//Put SysTest Group into Group if Sys
       
        public string GROUP_PROD { get; set; }//Put SysTest Group into Group if Sys
        public string SYSTEST_URL { get; set; }
        public string UAT_URL { get; set; }
        public string PROD_URL { get; set; }



        public string Username { get; set; }//?
        
        
        
        

        
        

        public string Password { get; set; }//?
        public string Element { get; set; }//?
       
        public string Skip { get; set; }//?
 

        public string AssertionText_SYS { get; set; }
        public string AssertionText_UAT { get; set; }
        public string AssertionText_PROD { get; set; }
    }
}