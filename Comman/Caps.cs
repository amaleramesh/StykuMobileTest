using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;

namespace StykuMobileTest
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
    }
}
