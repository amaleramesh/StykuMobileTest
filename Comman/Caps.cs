using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;


namespace StykuMobileTest.Comman
{
    public class Caps
    {
        public required AppiumDriver<AndroidElement> driver;

        public void AppiumSetup()
        {
            string apkFilePath = new FileInfo($"{Path.GetTempPath()}/app-release.apk").FullName;

            AppiumOptions capabilities = new();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.Appium);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, StringResources.DEVICE_NAME);
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, apkFilePath);

            driver = new AndroidDriver<AndroidElement>(new Uri(StringResources.APPIUM_SERVER_URL), capabilities);
        }

        public void LoginTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Enter button on homepage
            AndroidElement eButton = driver.FindElementByClassName("android.widget.Button");
            eButton.Click();

            // Enter email Id on welcome button
            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            // Click on email continue button
            AndroidElement emailContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            emailContinueButton.Click();

            // Enter password
            AndroidElement passwordInputBox = driver.FindElementByClassName("android.widget.EditText");
            passwordInputBox.Click();
            passwordInputBox.SendKeys(StringResources.PASSWORD);
            driver.HideKeyboard();

            // Click on toggle button
            AndroidElement toogleButton = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.widget.Switch");
            toogleButton.Click();

            // Click on password continue button
            AndroidElement passwordButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordButton.Click();

        }
    }
}
