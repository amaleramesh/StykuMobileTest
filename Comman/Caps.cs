using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace StykuMobileTest
{
    
    public class Caps
    {
        public  AppiumDriver<AndroidElement> driver;
        
        public void Appiumsetup()
        {
            string apkFilePath = new FileInfo($"{Path.GetTempPath()}/app-release.apk").FullName;
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.Appium);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, StringResources.DEVICE_NAME);
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, apkFilePath);
            driver = new AndroidDriver<AndroidElement>(new Uri(StringResources.APPIUM_SERVER_URL), capabilities);
        }

        private  AndroidElement GetWebElement(string webElement)
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
