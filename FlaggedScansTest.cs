using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StykuMobileTest
{
    public class FlaggedScansTest : Caps
    {
        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }
        [Test]
        public void KeepScan() 
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement eButton = driver.FindElementByClassName("android.widget.Button");
            eButton.Click();

            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            AndroidElement continueButton = driver.FindElementByAccessibilityId("Continue");
            continueButton.Click();

            AndroidElement passwordInputBox = driver.FindElementByClassName("android.widget.EditText");
            passwordInputBox.Click();
            passwordInputBox.SendKeys(StringResources.PASSWORD);
            driver.HideKeyboard();

            AndroidElement toogleButton = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.widget.Switch");
            toogleButton.Click();

            AndroidElement passwordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordContinueButton.Click();

            AndroidElement skipButton = driver.FindElementByAccessibilityId("Skip");
            skipButton.Click();

            AndroidElement reviewNowButton = driver.FindElementByAccessibilityId("Review Now");
            reviewNowButton.Click();

            AndroidElement predicatedValueButton = driver.FindElementByAccessibilityId("Predicted Value");
            predicatedValueButton.Click();

            TouchAction(960,746);

            AndroidElement keepScanButton = driver.FindElementByAccessibilityId("Keep Scan");
            keepScanButton.Click();

            TouchAction(542, 1196);

            AndroidElement dashBoardText = driver.FindElementByAccessibilityId("Dashboard");
            string actText = dashBoardText.GetAttribute("Dashboard");
            string expText = "Dashboard";

            Assert.That(expText, Is.EqualTo(actText));
        }
        [Test]
        public void RemoveScan() 
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement eButton = driver.FindElementByClassName("android.widget.Button");
            eButton.Click();

            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            AndroidElement continueButton = driver.FindElementByAccessibilityId("Continue");
            continueButton.Click();

            AndroidElement passwordInputBox = driver.FindElementByClassName("android.widget.EditText");
            passwordInputBox.Click();
            passwordInputBox.SendKeys(StringResources.PASSWORD);
            driver.HideKeyboard();

            AndroidElement toogleButton = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.widget.Switch");
            toogleButton.Click();

            AndroidElement passwordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordContinueButton.Click();

            AndroidElement skipButton = driver.FindElementByAccessibilityId("Skip");
            skipButton.Click();

            AndroidElement reviewNowButton = driver.FindElementByAccessibilityId("Review Now");
            reviewNowButton.Click();

            AndroidElement predicatedValueButton = driver.FindElementByAccessibilityId("Predicted Value");
            predicatedValueButton.Click();

            TouchAction(960, 746);

            AndroidElement removeScanButton = driver.FindElementByAccessibilityId("Remove Scan");
            removeScanButton.Click();

            //TouchAction(542, 1196);

            AndroidElement confirmRemoveScanButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Remove Scan\"]");
            confirmRemoveScanButton.Click();

            AndroidElement iWasWearingClothesButton = driver.FindElementByAccessibilityId("I was wearing clothes");
            iWasWearingClothesButton.Click();

            AndroidElement scanWasDistortedButton = driver.FindElementByAccessibilityId("Scan was distorted");
            scanWasDistortedButton.Click();

            AndroidElement nextButton = driver.FindElementByAccessibilityId("Next");
            nextButton.Click();

            AndroidElement dashBoardText = driver.FindElementByAccessibilityId("Dashboard");
            string actText = dashBoardText.GetAttribute("Dashboard");
            string expText = "Dashboard";

            Assert.That(expText, Is.EqualTo(actText));

        }
        public void TouchAction(int xCoordinate, int yCoordinate) 
        {
            var touchAction = new TouchAction(driver);
            touchAction.Press(x: xCoordinate, y: yCoordinate).Release().Perform();
        }
    }
}
