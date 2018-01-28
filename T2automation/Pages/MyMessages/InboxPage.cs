﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T2automation.Pages.Comm;
using T2automation.Util;
using T2automation.Init;
using AutoItX3Lib;

namespace T2automation.Pages.MyMessages
{
    class InboxPage : LeftMenu
    {
        private readonly IWebDriver _driver;
        private ReadFromConfig readFromConfig;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Internal Document']")]
        private IWebElement _internalDocument;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Encrypted internal message']")]
        private IWebElement _encryptInernalMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Incoming Document']")]
        private IWebElement _incomingDocument;

        [FindsBy(How = How.XPath, Using = ".//*[@id='head-menu']/div/a/label[text() = ' Outgoing Document']")]
        private IWebElement _outgoingDocument;

        [FindsBy(How = How.XPath, Using = ".//div[@class = 'ajs-content']/input")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IList<IWebElement> _cancelBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Yes']")]
        private IWebElement _yesBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectTo']")]
        private IWebElement _toButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSearch2Temp']")]
        private IWebElement _searchNameCode;

        [FindsBy(How = How.XPath, Using = ".//tbody/tr/td[1]/label")]
        private IList<IWebElement> _selectToCheck;

        [FindsBy(How = How.XPath, Using = ".//tbody/tr/td[2]")]
        private IList<IWebElement> _selectToName;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectToTemp']")]
        private IWebElement _selectToFrameToBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSelectCCTemp']")]
        private IWebElement _selectToFrameCCBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtSubject']")]
        private IWebElement _subject;

        [FindsBy(How = How.XPath, Using = ".//*[@id='cke_1_contents']/iframe")]
        private IWebElement _contentBodyIFrame;

        [FindsBy(How = How.XPath, Using = "html/body")]
        private IWebElement _contentBody;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[4]/div[1]/div[1]/a/label")]
        private IWebElement _sendBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td/label")]
        private IList<IWebElement> _checkboxList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[3]")]
        private IList<IWebElement> _senderList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[4]")]
        private IList<IWebElement> _subjectList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[5]")]
        private IList<IWebElement> _referenceNoList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/tbody/tr/td[6]")]
        private IList<IWebElement> _receiveDateList;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[1]/div[2]/ul")]
        private IWebElement _mailTo;

        [FindsBy(How = How.XPath, Using = ".//*[@id='doc-part']/div[2]/div[1]/div[2]/ul/li")]
        private IWebElement _subjectInbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='contentBody']/div/div[@class = 'contentBodyHtml']")]
        private IWebElement _contentBodyInbox;

        [FindsBy(How = How.Id, Using = "txtPass")]
        private IWebElement _encryptedPassword;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement _encryptedPasswordOkBtn;

        [FindsBy(How = How.Id, Using = "btnDepartmentTo")]
        private IWebElement _externalDeptToBtn;

        [FindsBy(How = How.Id, Using = "txtSearchTo3")]
        private IWebElement _searchDeptName;

        [FindsBy(How = How.Id, Using = "txtSearchExtDepToCode")]
        private IWebElement _searchDeptCodeName;

        [FindsBy(How = How.Id, Using = "tabDoc")]
        private IWebElement _documentTab;

        [FindsBy(How = How.Id, Using = "docContentDiv")]
        private IWebElement _contentTab;

        [FindsBy(How = How.Id, Using = "docPropertyDiv")]
        private IWebElement _propertiesTab;

        [FindsBy(How = How.Id, Using = "tabAttache")]
        private IWebElement _attachmentTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div[1]/a/label")]
        private IWebElement _attacheBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='attachmentDelete']/a")]
        private IWebElement _deleteBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div/a/label[text()=' Download']")]
        private IWebElement _downloadBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='att-head-menu']/div/a/label[text()=' Download All']")]
        private IWebElement _downloadAllBtn;

        [FindsBy(How = How.Id, Using = "txtIncomingMessageNumber")]
        private IWebElement _incommingMessageNo;

        [FindsBy(How = How.Id, Using = "txtSendDate2")]
        private IWebElement _incommingHijriMessageDate;

        [FindsBy(How = How.Id, Using = "txtSendDate")]
        private IWebElement _incommingGregorianMessageDate;

        [FindsBy(How = How.Id, Using = "relatedDocumentCount")]
        private IWebElement _connectedDocTab;

        [FindsBy(How = How.Id, Using = "Addbuttontbl_documentDocument")]
        private IWebElement _addNewBtn;

        [FindsBy(How = How.Id, Using = "buttontbl_documentDocument")]
        private IWebElement _connectedDocDeleteBtn;

        [FindsBy(How = How.Id, Using = "Subject")]
        private IWebElement _connectedDocSubject;

        [FindsBy(How = How.Id, Using = "btnDocumentSearch")]
        private IWebElement _connectedDocSearchBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Save']")]
        private IList<IWebElement> _connectedDocSaveBtn;

        [FindsBy(How = How.XPath, Using = ".//button[text() = 'Cancel']")]
        private IList<IWebElement> _connectedDocCancelBtn;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-mail-reply")]
        private IWebElement _replyBtn;     

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-forward")]
        private IWebElement _forwardBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-parent']/div/div[2]/div[2]/div[4]/div[1]/div[3]/a/label")]
        private IWebElement _deleteDraftBtn;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-save")]
        private IWebElement _saveDraftBtn;

        [FindsBy(How = How.Id, Using = "o-m-loader")]
        private IWebElement _createDocumentScreenLoader;

        private IList<IWebElement> _connectedDocSearchedSubjects()
        {
            return _driver.FindElements(By.XPath(".//*[@id='tbl_documentFilter']/tbody/tr/td[3]"));
        }

        private IList<IWebElement> _connectedDocSearchedCheckBoxes()
        {
            return _driver.FindElements(By.XPath(".//*[@id='tbl_documentFilter']/tbody/tr/td[1]/label"));
        }

        private IList<IWebElement> _progressbar(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//div[@class = 'pParent']"));
        }

        private IWebElement _notificationContent(IWebDriver driver)
        {
            return driver.FindElement(By.Id("not-content0"));
        }

        private IWebElement _processing(IWebDriver driver)
        {
            return driver.FindElement(By.ClassName("dataTables_processing"));
        }

        private IWebElement _mailLoading(IWebDriver driver)
        {
            return driver.FindElement(By.Id("container_processing"));
        }

        private IWebElement _okBtn()
        {
            var elements = _driver.FindElements(By.XPath(".//button[text() = 'Ok']"));
            foreach (IWebElement elem in elements) {
                if (elem.Displayed) {
                    return elem;
                }
            }
            return _driver.FindElement(By.XPath(".//button[text() = 'Ok']"));
        }

        private SelectElement _receiverType(IWebDriver driver) {
            return new SelectElement(driver.FindElement(By.Id("slctRecieverTypeTemp"))); 
        }

        private SelectElement _levelSelect(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("slctLevel0Temp")));
        }

        private SelectElement _deptType(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("slcTypeToSearch")));
        }

        private SelectElement _deliveryType()
        {
            return new SelectElement(_driver.FindElement(By.Id("slctDeliveryType")));
        }

        private SelectElement _securityLevel()
        {
            return new SelectElement(_driver.FindElement(By.Id("slctSecurityLevels")));
        }

        private IList<IWebElement> _deptRadioBtn(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentToGrid']/tbody/tr/td[1]/input"));
        }

        private IList<IWebElement> _deptNames(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='externalDepartmentToGrid']/tbody/tr/td[2]"));
        }

        private IList<IWebElement> _attachedFileNames(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='files-parent']/div/div[2]"));
        }

        private IList<IWebElement> _attachedFilesCheckboxes(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(".//*[@id='files-parent']/div/div[1]/label"));
        }

        private IList<IWebElement> _daysOnCal() {
            return _driver.FindElements(By.XPath("html/body/div/div/div[2]/div/table/tbody/tr/td/a[text()=.]"));
        }

        private IList<IWebElement> _connectedDocSubjectList()
        {
            return _driver.FindElements(By.XPath(".//table[@id = 'tbl_documentDocument']/tbody/tr/td[3]"));
        }

        public string title = "Inbox - Ole5.1";

        public InboxPage(IWebDriver driver) : base(driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string SearchNameCode
        {
            set
            {
                SendKeys(_driver, _searchNameCode, value);
            }
        }

        public string Subject
        {
            set
            {
                SendKeys(_driver, _subject, value);
            }
        }

        public string EncryptedPassword
        {
            set
            {
                SendKeys(_driver, _encryptedPassword, value);
            }
        }

        public bool CheckButtonAvailbility(IWebDriver driver, string buttonName, bool value) {
            IWebElement element = null;

            switch (buttonName) {
                case "Internal Document":
                    element = _internalDocument;
                    break;
                case "Encrypted internal message":
                    element = _encryptInernalMessage;
                    break;
                case "Incoming Document":
                    element = _incomingDocument;
                    break;
                case "Outgoing Document":
                    element = _outgoingDocument;
                    break;
            }

            return ElementIsDisplayed(driver, element) == value;
        }

        public bool CheckButtonClickable(IWebDriver driver, string buttonName)
        {
            IWebElement element = null;

            switch (buttonName)
            {
                case "Internal Document":
                    element = _internalDocument;
                    break;
                case "Encrypted internal message":
                    element = _encryptInernalMessage;
                    break;
                case "Incoming Document":
                    element = _incomingDocument;
                    break;
                case "Outgoing Document":
                    element = _outgoingDocument;
                    break;
            }

            Click(driver, element);
            Thread.Sleep(2000);
            if (buttonName.Equals("Encrypted internal message"))
            {
                EnterPassword(driver, "P@ssw0rd!@#");
                Thread.Sleep(2000);
            }

            while (!IsAt(driver, "Create document - Ole5.1")) {
                Console.WriteLine("Loading Page....");
                Thread.Sleep(1000);
            }
            return IsAt(driver, "Create document - Ole5.1");
        }

        public void WaitTillCreatePageLoad()
        {
            while (GetAttribute(_driver, _createDocumentScreenLoader, "class").Equals("")) {
                continue;
            }
        }

        public void EnterPassword(IWebDriver driver, string password)
        {
            SendKeys(driver, _passwordInput, password);
            Click(driver, _okBtn());
        }

        public void ClickToButton(IWebDriver driver)
        {
            Thread.Sleep(1000);
            Click(driver, _toButton);
            Thread.Sleep(2000);
        }

        public void SelectLevel(IWebDriver driver, string level) {
            DropdownSelectByText(driver, _levelSelect(driver), level);
            Thread.Sleep(1000);
        }

        public void SelectReceiverType(IWebDriver driver, string type)
        {
            DropdownSelectByText(driver, _receiverType(driver), type);
            Thread.Sleep(1000);
        }

        public void SelectToUser(IWebDriver driver, string user) {
            WaitTillProcessing();
            for (int index = 0; index < _selectToName.Count; index++) {
                if (GetText(driver, _selectToName.ElementAt(index)).Contains(user)) {
                    Click(driver, _selectToCheck.ElementAt(index));
                    Click(driver, _selectToFrameToBtn);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }

        public void ClickOkBtn() {
            Click(_driver, _okBtn());
            Thread.Sleep(1000);
        }

        public void EnterContentBody(string body) {
            _driver.SwitchTo().Frame(_contentBodyIFrame);
            SendKeys(_driver, _contentBody, body);
            _driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
        }

        public void clickOnSendBtn(bool checkPopup=false) {
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            if (checkPopup)
            {
                foreach (IWebElement cancelBtn in _cancelBtn)
                {
                    if (cancelBtn.Displayed)
                    {
                        Click(_driver, cancelBtn);
                        break;
                    }
                }
            }
        }

        public void SendMail(string subject, string contentBody, bool checkPopup = false, int multipleAttachementNo = 1, string multipleAttachmentType = "", string securityLevel = "") {
            ComposeMail(subject, contentBody);
            AddAttachments(multipleAttachmentType, multipleAttachementNo);
            SetProperties(securityLevel: securityLevel);
            Click(_driver, _sendBtn);
            Thread.Sleep(2000);
            if (checkPopup) {
                foreach (IWebElement cancelBtn in _cancelBtn) {
                    if (cancelBtn.Displayed) {
                        Click(_driver, cancelBtn);
                        break;
                    }
                }
            }
            WaitTillMailSent();
        }

        public bool OpenMail(IWebDriver driver, string subject, string encryptPass = "")
        {
            WaitTillMailsGetLoad();
            foreach (IWebElement elem in _subjectList)
            {
                if (GetText(driver, elem).Equals(subject))
                {
                    Click(driver, elem);
                    Thread.Sleep(1000);
                    if (!encryptPass.Equals("")) {
                        EncryptedPassword = encryptPass;
                        Click(driver, _encryptedPasswordOkBtn);
                        Thread.Sleep(5000);
                    }
                    return true;
                }
            }
            return false;
        }

        public bool ValidateTo(IWebDriver driver, string to)
        {
            return GetText(driver, _mailTo).Contains(to);
        }

        public bool ValidateSubject(IWebDriver driver, string subject)
        {
            return GetText(driver, _subjectInbox).Equals(subject);
        }

        public bool ValidateContentBody(IWebDriver driver, string contentBody)
        {
            return GetText(driver, _contentBodyInbox).Equals(contentBody);
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body)
        {
            if (OpenMail(driver, subject))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public bool ValidateMail(IWebDriver driver, string to, string subject, string body, string listSubject, string encryptPass)
        {
            if (OpenMail(driver, listSubject, encryptPass))
            {
                return (ValidateTo(driver, to) && ValidateSubject(driver, subject) && ValidateContentBody(driver, body));
            }
            return false;
        }

        public bool WaitTillMailSent()
        {
            try {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(drv => ElementIsDisplayed(_driver, _notificationContent(_driver)));
                return true;
            }
            catch (Exception) {
                Console.WriteLine("Notification on sending email does not appear");
                return false;
            }
        }

        public void WaitTillProcessing()
        {
            try
            {
                while (ElementIsDisplayed(_driver, _processing(_driver)))
                {
                    continue;
                }
                Thread.Sleep(5000);
            }
            catch (Exception) {
                return;
            }
        }

        public void WaitTillMailsGetLoad()
        {
            while (ElementIsDisplayed(_driver, _mailLoading(_driver)))
            {
                continue;
            }
        }

        public int SearchDept(string deptName = "", string deptCode = "", string type = "") {
            if (!deptName.Equals(""))
            {
                SendKeys(_driver, _searchDeptName, deptName);
            }
            if (!deptCode.Equals(""))
            {
                SendKeys(_driver, _searchDeptCodeName, deptName);
            }
            if (!type.Equals(""))
            {
                DropdownSelectByText(_driver, _deptType(_driver), type);
            }
            Thread.Sleep(5000);
            var deptNames = _deptNames(_driver);
            for (int index = 0; index < deptNames.Count; index++) {
                if (GetText(_driver, deptNames.ElementAt(index)).Equals(deptName)) {
                    return index;
                }
            }
            return -1;
        }

        public bool SelectExternalDeptTo(string deptName = "", string deptCode = "", string type = "") {
            Thread.Sleep(5000);
            Click(_driver, _externalDeptToBtn);
            int index = SearchDept(deptName, deptCode, type);
            if (index != -1) {
                Thread.Sleep(5000);
                Click(_driver, _deptRadioBtn(_driver).ElementAt(index));
                Thread.Sleep(2000);
                Click(_driver, _okBtn());
                Thread.Sleep(2000);
                return true;
            }
            Click(_driver, _okBtn());
            return false;
        }

        public void ComposeMail(string subject, string contentBody, string multipleAttachementNo = "No", string multipleAttachmentType = "png") {
            Subject = subject;
            EnterContentBody(contentBody);
        }

        public void SetProperties(string deliveryType = "", string securityLevel = "", string messageNo = "", string messageHijriDate = "", string messageGreorianDate = "")
        {
            Click(_driver, _documentTab);
            Click(_driver, _propertiesTab);
            if (!deliveryType.Equals(""))
            {
                DropdownSelectByText(_driver, _deliveryType(), deliveryType);
            }

            if (!securityLevel.Equals("")) {
                DropdownSelectByText(_driver, _securityLevel(), securityLevel);
            }

            if (!messageNo.Equals(""))
            {
                SendKeys(_driver, _incommingMessageNo, messageNo);
            }

            if (!messageGreorianDate.Equals(""))
            {
                SendKeys(_driver, _incommingGregorianMessageDate, new DateTimeHelper().GetDate(messageGreorianDate));
                var result = _daysOnCal();
                Click(_driver, _daysOnCal().ElementAt(new DateTimeHelper().GetDay(messageGreorianDate) - 1));
            }

            if (!messageHijriDate.Equals(""))
            {
                SendKeys(_driver, _incommingHijriMessageDate, messageHijriDate);
            }
        }

        public void SendOutgoingMessage(string subject, string contentBody, string deliveryType = "", string deptName = "", string deptCode = "", string type = "") {
            NavigateToMyMessageInbox(_driver);
            CheckButtonClickable(_driver, "Outgoing Document");
            SelectExternalDeptTo(deptName, deptCode, type);
            SetProperties(deliveryType);
            Click(_driver, _contentTab);
            SendMail(subject, contentBody, checkPopup: true);
        }

        public void WaitForUploading()
        {
            Thread.Sleep(1000);
            while (_progressbar(_driver).Count != 0 )
            {
                bool stillUploading = false;
                var progress = _progressbar(_driver);
                foreach (IWebElement progressbar in progress) {
                    if (ElementIsDisplayed(_driver, progressbar)) {
                        stillUploading = true;
                        break;
                    }
                }
                if (!stillUploading) {
                    return;
                }
            }
        }

        public void AddAttachments(string multipleAttachmentType, int multipleAttachementNo) {
            if (!multipleAttachmentType.Equals(""))
            {
                if (multipleAttachmentType.Contains(","))
                {
                    string[] types = multipleAttachmentType.Split(',');
                    foreach (string type in types)
                    {
                        Click(_driver, _attachmentTab);
                        Click(_driver, _attacheBtn);
                        AutoItX3 autoIt = new AutoItX3();
                        autoIt.WinActivate("Open");
                        readFromConfig = new ReadFromConfig();
                        var filePath = readFromConfig.GetValue("AttachementFolder") + type;
                        autoIt.Send(filePath);
                        autoIt.Send("{ENTER}");
                        WaitForUploading();
                    }
                }
                else
                {
                    for (int i = 0; i < multipleAttachementNo; i++)
                    {
                        Click(_driver, _attachmentTab);
                        Click(_driver, _attacheBtn);
                        AutoItX3 autoIt = new AutoItX3();
                        autoIt.WinActivate("Open");
                        readFromConfig = new ReadFromConfig();
                        var filePath = readFromConfig.GetValue("AttachementFolder") + multipleAttachmentType;
                        autoIt.Send(filePath);
                        autoIt.Send("{ENTER}");
                        WaitForUploading();
                    }
                }
            }
        }

        public void DeleteAttachments(string deleteAttachmentTypes, int deleteAttachmentNo)
        {
            if (!deleteAttachmentTypes.Equals(""))
            {
                var fileNames = _attachedFileNames(_driver);
                var checkBoxes = _attachedFilesCheckboxes(_driver);
                if (deleteAttachmentTypes.Contains(","))
                {
                    string[] types = deleteAttachmentTypes.Split(',');
                    foreach (string type in types)
                    {
                        for (int index = 0; index < fileNames.Count; index++) {
                            if (GetAttribute(_driver, fileNames.ElementAt(index), "title").Equals(type)) {
                                Click(_driver, checkBoxes.ElementAt(index));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < deleteAttachmentNo; i++)
                    {
                        if (GetAttribute(_driver, fileNames.ElementAt(i), "title").Equals(deleteAttachmentTypes))
                        {
                            Click(_driver, checkBoxes.ElementAt(i));
                        }
                    }
                }
                Click(_driver, _deleteBtn);
            }
        }

        public bool ValidateAttachments(IWebDriver driver, int attachmentNo, string attachment, int deleteAttachmentNo = 0)
        {
            var fileNames = _attachedFileNames(_driver);
            if (fileNames.Count == attachmentNo-deleteAttachmentNo)
            {
                for (int index = 0; index < attachmentNo - deleteAttachmentNo; index++)
                {
                    if (!attachment.Contains(GetAttribute(driver, fileNames.ElementAt(index), "title")))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void DownloadFile(string subject, string downloadFileName, int downloadFileNo)
        {
            OpenMail(_driver, subject);
            Click(_driver, _attachmentTab);
            if (!(downloadFileName.Equals("All") && downloadFileName.Equals("")))
            {
                var fileNames = _attachedFileNames(_driver);
                var checkBoxes = _attachedFilesCheckboxes(_driver);
                if (downloadFileName.Contains(","))
                {
                    string[] types = downloadFileName.Split(',');
                    foreach (string type in types)
                    {
                        for (int index = 0; index < fileNames.Count; index++)
                        {
                            if (GetAttribute(_driver, fileNames.ElementAt(index), "title").Equals(type))
                            {
                                Click(_driver, checkBoxes.ElementAt(index));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < downloadFileNo; i++)
                    {
                        if (GetAttribute(_driver, fileNames.ElementAt(i), "title").Equals(downloadFileName))
                        {
                            Click(_driver, checkBoxes.ElementAt(i));
                        }
                    }
                }
                Click(_driver, _downloadBtn);
            }
            else if (downloadFileName.Equals("All")) {
                Click(_driver, _downloadAllBtn);
            }
        }

        public void SearchConnectedDoc(string subject)
        {
            Click(_driver, _connectedDocTab);
            Click(_driver, _addNewBtn);
            SendKeys(_driver, _connectedDocSubject, subject);
            Click(_driver, _connectedDocSearchBtn);
            WaitTillProcessing();
        }

        public int SelectConnectedDoc(string subject)
        {
            SearchConnectedDoc(subject);
            int searchResults = _connectedDocSearchedSubjects().Count;
            if (searchResults >= 1) {
                Click(_driver, _connectedDocSearchedCheckBoxes().ElementAt(0));
                Click(_driver, _connectedDocSaveBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
                return searchResults;
            }
            Click(_driver, _connectedDocCancelBtn.ElementAt(_connectedDocSaveBtn.Count - 1));
            return searchResults;
        }

        public bool CheckVisibiltyOnConnectedDoc(string buttonName, bool value)
        {
            Click(_driver, _connectedDocTab);
            if (buttonName.Equals("Add")) {
                return ElementIsDisplayed(_driver, _addNewBtn) == value;
            }
            else if (buttonName.Equals("Delete"))
            {
                return ElementIsDisplayed(_driver, _connectedDocDeleteBtn) == value;
            }
            return false;
        }

        public bool CheckVisibiltyOfTab(string tab, bool value)
        {
            if (tab.Equals("Connected Document"))
            {
                return ElementIsDisplayed(_driver, _connectedDocTab) == value;
            }
            return false;
        }

        public void ClickOnReply()
        {
            Click(_driver, _replyBtn);
            Thread.Sleep(5000);
        }

        public void ClickOnForward()
        {
            Click(_driver, _forwardBtn);
            Thread.Sleep(5000);
        }

        public void DeleteDraft()
        {
            Thread.Sleep(5000);
            Click(_driver, _deleteDraftBtn);
            Click(_driver, _yesBtn);
        }

        public void SaveDraft()
        {
            Click(_driver, _saveDraftBtn);
        }

        public bool ValidateConnectedDocumentList(string subject)
        {
            var subjects = _connectedDocSubjectList();
            foreach (IWebElement listSubject in subjects) {
                if (GetText(_driver, listSubject).Equals(subject)) {
                    return true;
                }
            }
            return false;
        }
    }
}
