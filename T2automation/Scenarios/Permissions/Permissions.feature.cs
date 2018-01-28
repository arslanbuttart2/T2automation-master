﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace T2automation.Scenarios.Permissions
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Permissions of user")]
    public partial class PermissionsOfUserFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Permissions.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Permissions of user", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User permissions on system")]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Internal Message", "True", "User", "UserName", "Password", "Internal Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Internal Message", "False", "User", "UserName", "Password", "Internal Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Encrypted Message", "True", "User", "UserName", "Password", "Encrypted internal message", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Encrypted Message", "False", "User", "UserName", "Password", "Encrypted internal message", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Incoming Message", "True", "User", "UserName", "Password", "Incoming Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Incoming Message", "False", "User", "UserName", "Password", "Incoming Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Outing Message", "True", "User", "UserName", "Password", "Outgoing Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Outing Message", "False", "User", "UserName", "Password", "Outgoing Document", null)]
        public virtual void UserPermissionsOnSystem(string adminUserName, string adminPassword, string permissionName, string permissionValue, string user, string userName, string password, string button, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User permissions on system", exampleTags);
#line 4
  this.ScenarioSetup(scenarioInfo);
#line 5
    testRunner.Given(string.Format("Admin logged in \"{0}\" \"{1}\"", adminUserName, adminPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
    testRunner.When(string.Format("Admin set system message permissions for user \"{0}\" \"{1}\" \"{2}\"", permissionName, permissionValue, user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
    testRunner.And(string.Format("User logs in \"{0}\" \"{1}\"", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
    testRunner.Then(string.Format("\"{0}\" visibility should be on My Messages inbox \"{1}\"", button, permissionValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User permissions on Department")]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Internal Message", "True", "User", "internalDepartmentSameDep", "UserName", "Password", "Internal Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Internal Message", "False", "User", "internalDepartmentSameDep", "UserName", "Password", "Internal Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Incoming Message", "True", "User", "internalDepartmentSameDep", "UserName", "Password", "Incoming Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Incoming Message", "False", "User", "internalDepartmentSameDep", "UserName", "Password", "Incoming Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Outing Message", "True", "User", "internalDepartmentSameDep", "UserName", "Password", "Outgoing Document", null)]
        [NUnit.Framework.TestCaseAttribute("AdminUserName", "AdminPassword", "Create Outing Message", "False", "User", "internalDepartmentSameDep", "UserName", "Password", "Outgoing Document", null)]
        public virtual void UserPermissionsOnDepartment(string adminUserName, string adminPassword, string permissionName, string permissionValue, string user, string dept, string userName, string password, string button, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User permissions on Department", exampleTags);
#line 21
  this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given(string.Format("Admin logged in \"{0}\" \"{1}\"", adminUserName, adminPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.When(string.Format("Admin set department message permissions for user \"{0}\" \"{1}\" \"{2}\" \"{3}\"", permissionName, permissionValue, user, dept), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
    testRunner.And(string.Format("User logs in \"{0}\" \"{1}\"", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.Then(string.Format("\"{0}\" visibility should be \"{1}\" on Department Messages inbox", button, permissionValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
