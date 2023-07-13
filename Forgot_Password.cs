using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace StykuMobileTest
{
    public class Forgot_Password
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
        public void ForgotPasswordvalidverificationcode()
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

            //Click on Forgot Password link
            AndroidElement forgotpassword = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Forgot password\"]");
            forgotpassword.Click();

            // Enter verification code field
            AndroidElement verificationcodefield = GetWebElement("android.widget.EditText");
            verificationcodefield.Click();
            string verificationcode = "323345";
            verificationcodefield.SendKeys(verificationcode);

            // Click on email verification continue button
            AndroidElement vcontinuebutton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            vcontinuebutton.Click();

            // Enter new password 
            AndroidElement Enternewpasswordfield = GetWebElementusingxpath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[1]");
            Enternewpasswordfield.Click();
            Enternewpasswordfield.SendKeys("Test@123");
            driver.HideKeyboard();
            Thread.Sleep(2000);

            //Enter confirm password field
            AndroidElement Enternewconfirmpasswordfield = GetWebElementusingxpath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[2]");
            Enternewconfirmpasswordfield.Click();
            Enternewconfirmpasswordfield.SendKeys("Test@123");
            driver.HideKeyboard();


            // Click on set new password continue button
            AndroidElement npcontinuebutton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            npcontinuebutton.Click();
            Thread.Sleep(2000);

            // Get the value of the content-desc attribute
            AndroidElement element = driver.FindElementByXPath("/hierarchy/android.widget.Toast");
            string Actresult = element.GetAttribute("text");
            string Eepresult = StringResources.PASSWORD_CHANGED_SUCCESS_MESSAGE;
            Assert.That(Actresult, Is.EqualTo(Eepresult));

        }
        [Test]
        public void ForgotPasswordinvalidverificationcode() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            // Enter button on HomePage
            AndroidElement enterbutton = GetWebElement("android.widget.Button");
            enterbutton.Click();

            // Enter email Id on Welcome button
            AndroidElement emailinputBox = GetWebElement("android.widget.EditText");
            emailinputBox.Click();
            emailinputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            // Click on email continue button
            By emailcontinuebutton = By.XPath("//android.widget.Button[@content-desc=\"Continue\"]");
            AndroidElement cbutton = driver.FindElement(emailcontinuebutton);
            cbutton.Click();

            //Click on Forgot Password link
            AndroidElement forgotpassword = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Forgot password\"]");
            forgotpassword.Click();

            // Enter verification code field
            AndroidElement verificationcodefield = GetWebElement("android.widget.EditText");
            verificationcodefield.Click();
            string verificationcode = "184401";
            verificationcodefield.SendKeys(verificationcode);

            // Click on email verification continue button
            AndroidElement vcontinuebutton = GetWebElementusingxpath("//android.widget.Button[@content-desc=\"Continue\"]");
            vcontinuebutton.Click();

            // Get the value of the content-desc attribute
            AndroidElement element = driver.FindElementByXPath("//android.view.View[@content-desc=\"Incorrect Verification Code\"]");
            string Actresult = element.GetAttribute("text");
            string Eepresult = StringResources.EMAIL_VERIFICATION_VALIDATION_CODE;
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
