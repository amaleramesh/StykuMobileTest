using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;


namespace StykuMobileTest
{
    public class LoginTest
    {
        public AppiumDriver<AndroidElement> driver;


        [SetUp]

        public void Setup()
        {
            string apkFilePath = new FileInfo($"{Path.GetTempPath()}/app-release.apk").FullName;
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.Appium);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, StringResources.DEVICE_NAME);
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, apkFilePath);
            driver = new AndroidDriver<AndroidElement>(new Uri(StringResources.APPIUM_SERVER_URL), capabilities);
        }

        [Test]
        public void TestLoginSucess()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // Enter button on HomePage

            AndroidElement ebutton = GetWebElement("android.widget.Button");
            ebutton.Click();

            // Enter email Id on Welcome button
            AndroidElement emailinputBox = GetWebElement("android.widget.EditText");
            emailinputBox.Click();
            emailinputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();


            // Click on email continue button
            By emailcontinuebutton = By.XPath("//android.widget.Button[@content-desc=\"Continue\"]");
            AndroidElement cbutton = driver.FindElement(emailcontinuebutton);
            cbutton.Click();

            // Enter Password
            AndroidElement passwordinputBox = GetWebElement("android.widget.EditText");
            passwordinputBox.Click();
            passwordinputBox.SendKeys(StringResources.PASSWORD);
            driver.HideKeyboard();

            // Click on toggle button

            AndroidElement tbutton = GetWebElementusingxpath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.widget.Switch");
            tbutton.Click();

            // Click on password continue button

            AndroidElement pbutton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            pbutton.Click();

            // Click on Skip button
            AndroidElement sbutton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Skip\"]");
            sbutton.Click();
            driver.Quit();

        }

        [Test]
        public void TestLoginWithInvalidEmail()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement ebutton = GetWebElement("android.widget.Button");
            ebutton.Click();

            AndroidElement emailinputBox = GetWebElement("android.widget.EditText");
            emailinputBox.Click();

            emailinputBox.SendKeys(StringResources.INVALID_EMAIL_ID);

            driver.HideKeyboard();

            AndroidElement element = driver.FindElementByXPath("//android.view.View[@content-desc=\"Please enter a valid email format\"]");

            // Get the value of the content-desc attribute
            string Actresult = element.GetAttribute("content-desc");
            string Eepresult = StringResources.EMAIL_VALIDATION_MESSAGE;
            Assert.That(Actresult, Is.EqualTo(Eepresult));
            driver.Quit();

        }

        [Test]
        public void TestLoginWithInvaliPassword()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement ebutton = GetWebElement("android.widget.Button");
            ebutton.Click();

            AndroidElement emailinputBox = GetWebElement("android.widget.EditText");
            emailinputBox.Click();

            emailinputBox.SendKeys(StringResources.EMAIL_ID);

            driver.HideKeyboard();

            // Click on email continue button
            By emailcontinuebutton = By.XPath("//android.widget.Button[@content-desc=\"Continue\"]");
            AndroidElement cbutton = driver.FindElement(emailcontinuebutton);
            cbutton.Click();

            // Enter Password
            AndroidElement passwordinputBox = GetWebElement("android.widget.EditText");
            passwordinputBox.Click();
            passwordinputBox.SendKeys(StringResources.INVALID_PASSWORD);
            driver.HideKeyboard();

            // Click on password continue button

            AndroidElement pbutton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            pbutton.Click();

            AndroidElement element = driver.FindElementByXPath("/hierarchy/android.widget.Toast");

            // Get the value of the content-desc attribute
            string Actresult = element.GetAttribute("text");
            string Eepresult = StringResources.INVALID_PASSWORD_MESSAGE;
            Assert.That(Actresult, Is.EqualTo(Eepresult));

        }

        private AndroidElement GetWebElement(string webElement)
        {
            By enterbutton = By.ClassName(webElement);

            return driver.FindElement(enterbutton);
        }

        private AndroidElement GetWebElementusingxpath(string webElement)
        {
            By enterbutton = By.XPath(webElement);

            return driver.FindElement(enterbutton);
        }
    }
}