
using System;

namespace AutomationTests.TestDataAccess
{
    public class TestDataObject
    {
        public int ID { get; set; }
        public string TestMethodName { get; set; }
        public string Environment { get; set; }
        public string ExecutionMode { get; set; }
        public string LAFAdmin { get; set; }
        public string LAFAdminPW { get; set; }
        public string Application { get; set; }
        public string TargetApplicationURL { get; set; }
        public string TargetApplicationUserGroup { get; set; }
        public string User { get; set; }
        public string UserA { get; set; }
        public string UserAUserName { get; set; }
        public string UserPW { get; set; }
        public string UserB { get; set; }
        public string UserBPW { get; set; }
        public string Result { get; set; }
        public string TestUser { get; set; }
        public string TestUserPassword { get; set; }
        public string CredentialA { get; set; }
        public string CredentialValueA { get; set; }
        public string userGroupA { get; set; }
        public string userGroupB { get; set; }
        public string FailReason { get; set; }
        public string Authenticates { get; set; }
        public string ExpectedText { get; set; }
        public string ExecutionTime { get; set; }
        public string StackTrace { get; set; }
    }
}