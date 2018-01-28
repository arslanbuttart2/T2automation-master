﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;

namespace T2automation.Pages.SystemManagement.SystemManagement
{
    class PermissionsPage : LeftMenu
    {
        protected readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[1]/a")]
        private IWebElement _userPermissionOnSystem;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[2]/a")]
        private IWebElement _userPermissionOnDept;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-tabs']/div[3]/a")]
        private IWebElement _sendingPermissions;

        [FindsBy(How = How.Id, Using = "btnIncludeException")]
        private IWebElement _systemIncludeList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'System Settings']/../span[1]")]
        private IWebElement _expandSystemSettings;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'System Management']/../span[1]")]
        private IWebElement _expandSystemManagement;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/a[text() = 'Message Permission']/../span[1]")]
        private IWebElement _expandMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']//a[text() = 'View Related Messages']/../span[1]")]
        private IWebElement _expandViewRelatedMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']//a[text() = 'Add Related Message']/../span[1]")]
        private IWebElement _expandAddRelatedMessagePermission;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span")]
        private IList<IWebElement> _systemMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span/a")]
        private IList<IWebElement> _systemMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li/span/span[2]")]
        private IList<IWebElement> _selectSystemMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/span")]
        private IList<IWebElement> _viewRelatedMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/span/a")]
        private IList<IWebElement> _viewRelatedMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/span/span[2]")]
        private IList<IWebElement> _viewRelatedMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[1]/ul/li/span")]
        private IList<IWebElement> _deptViewRelatedMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[1]/ul/li/span/span[2]")]
        private IList<IWebElement> _deptViewRelatedMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/ul/li/span")]
        private IList<IWebElement> _addRelatedMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/ul/li/span/a")]
        private IList<IWebElement> _addRelatedMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li[3]/ul/li[2]/ul/li/ul/li/span/span[2]")]
        private IList<IWebElement> _addRelatedMessagePermissionsCheckbox;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Ok']")]
        private IWebElement _okBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IWebElement _cancelBtn;

        [FindsBy(How = How.XPath, Using = "html/body/div/div/div/div/button[3]")]
        private IWebElement _crossBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'No']")]
        private IWebElement _noBtn;

        [FindsBy(How = How.Id, Using = "btnExcludeException")]
        private IWebElement _systemExcludeList;

        [FindsBy(How = How.Id, Using = "btnViewResult")]
        private IWebElement _viewSystemPermissionResult;

        [FindsBy(How = How.Id, Using = "txtUserRoleSearch")]
        private IWebElement _systemSearch;

        [FindsBy(How = How.Id, Using = "AddbuttondivUserRoleGrid")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.Id, Using = "buttondivUserRoleGrid")]
        private IWebElement _deleteBtn;

        [FindsBy(How = How.Id, Using = "btnUopViewResult")]
        private IWebElement _viewDeptPermissionResult;

        [FindsBy(How = How.Id, Using = "txtUserOrganizationRoleSearch")]
        private IWebElement _deptSearch;

        [FindsBy(How = How.XPath, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[1]")]
        private IList<IWebElement> _deptName;

        [FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[2]")]
        private IList<IWebElement> _deptPriSec;

        [FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[3]")]
        private IList<IWebElement> _deptRoleName;

        //[FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[4]")]
        //private IList<IWebElement> _deptIncludeList;

        [FindsBy(How = How.Id, Using = ".//*[@id='userDepartmentTable']/tbody/tr/td[5]")]
        private IList<IWebElement> _deptExcludeList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/span/span")]
        private IWebElement _expandDepartmant;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li/span/a[text() = 'Department Messaging Permissions']/../span")]
        private IWebElement _expandDeptMessagingPermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li/span")]
        private IList<IWebElement> _deptMessagePermissionsClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li/span/a")]
        private IList<IWebElement> _deptMessagePermissions;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li/span/span[2]")]
        private IList<IWebElement> _selectDeptMessagePermissions;

        public string title = "Permissions - Ole5.1";

        public PermissionsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        private IList<IWebElement> _deptViewRelatedMessagePermissions()
        {
            return _driver.FindElements(By.XPath(".//*[@id='divPermTree']/ul/li/ul/li[2]/ul/li[1]/ul/li/span/a"));
        }

        private IList<IWebElement> _deptIncludeList(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='userDepartmentTable']/tbody/tr/td[4]"));
        }


        public void SearchDept(IWebDriver driver, string text) {
            SendKeys(driver, _deptSearch, text);
            Thread.Sleep(5000);
        }

        public void IncludeSystemMessagePermissions(IWebDriver driver, string permissionName, bool value)
        {
            Click(driver, _systemIncludeList);
            Click(driver, _expandMessagePermission);
            if (permissionName.Equals("Add Related Message") || permissionName.Equals("Remove Related Messages") || permissionName.Equals("Open Related Messages"))
            {
                Click(driver, _expandViewRelatedMessagePermission);
                for (int index = 0; index < _viewRelatedMessagePermissions.Count; index++)
                {
                    if (GetText(driver, _viewRelatedMessagePermissions.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _viewRelatedMessagePermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _viewRelatedMessagePermissionsCheckbox.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            return;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
            else if (permissionName.Contains("Can Link"))
            {
                Click(driver, _expandViewRelatedMessagePermission);
                Click(driver, _expandAddRelatedMessagePermission);

                for (int index = 0; index < _addRelatedMessagePermissions.Count; index++)
                {
                    if (GetText(driver, _addRelatedMessagePermissions.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _addRelatedMessagePermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _addRelatedMessagePermissionsCheckbox.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            return;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
            else
            {
                for (int index = 0; index < _systemMessagePermissions.Count; index++)
                {
                    if (GetText(driver, _systemMessagePermissions.ElementAt(index)).Equals(permissionName))
                    {
                        if (GetAttribute(driver, _systemMessagePermissionsClass.ElementAt(index), "class").Contains("selected") != value)
                        {
                            Click(driver, _selectSystemMessagePermissions.ElementAt(index));
                            Click(driver, _okBtn);
                            Click(driver, _yesBtn);
                            return;
                        }
                        Click(driver, _cancelBtn);
                        return;
                    }
                }
            }
        }

        public void IncludeDeptMessagePermissions(IWebDriver driver, string dept, string permissionName, bool value)
        {
            Click(driver, _userPermissionOnDept);
            SearchDept(driver, dept);
            for (int index = 0; index < _deptName.Count; index++) {
                if (GetText(driver, _deptName.ElementAt(index)).Equals(dept)) {
                    var _includeList = _deptIncludeList(driver);
                    Click(driver, _includeList.ElementAt(index));
                    Click(driver, _expandDepartmant);
                    Click(driver, _expandDeptMessagingPermissions);

                    if (permissionName.Equals("Add Related Message") || permissionName.Equals("Remove Related Messages") || permissionName.Equals("Open Related Messages"))
                    {
                        Click(driver, _expandViewRelatedMessagePermission);
                        var elem = _deptViewRelatedMessagePermissions();
                        for (int index1 = 0; index1 < elem.Count; index1++)
                        {
                            if (GetText(driver, elem.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptViewRelatedMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _deptViewRelatedMessagePermissionsCheckbox.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }

                    else
                    {
                        for (int index1 = 0; index1 < _deptMessagePermissions.Count; index1++)
                        {
                            if (GetText(driver, _deptMessagePermissions.ElementAt(index1)).Equals(permissionName))
                            {
                                if (GetAttribute(driver, _deptMessagePermissionsClass.ElementAt(index1), "class").Contains("selected") != value)
                                {
                                    Click(driver, _selectDeptMessagePermissions.ElementAt(index1));
                                    Click(driver, _okBtn);
                                    Click(driver, _yesBtn);
                                    return;
                                }
                                Click(driver, _cancelBtn);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
