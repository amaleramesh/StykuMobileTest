using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace StykuMobileTest
{
    public class FlaggedScansTest : Caps
    {
        
        string expText = "Dashboard";

        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void KeepScan()
        {
            FlagScanCommonCode();

            AndroidElement keepScanButton = driver.FindElementByAccessibilityId("Keep Scan");
            keepScanButton.Click();

            TouchAction(542, 1196);
        }

        [Test]
        public void RemoveScan()
        {
            FlagScanCommonCode();

            AndroidElement removeScanButton = driver.FindElementByAccessibilityId("Remove Scan");
            removeScanButton.Click();

            AndroidElement confirmRemoveScanButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Remove Scan\"]");
            confirmRemoveScanButton.Click();

            AndroidElement iWasWearingClothesButton = driver.FindElementByAccessibilityId("I was wearing clothes");
            iWasWearingClothesButton.Click();

            AndroidElement scanWasDistortedButton = driver.FindElementByAccessibilityId("Scan was distorted");
            scanWasDistortedButton.Click();

            AndroidElement nextButton = driver.FindElementByAccessibilityId("Next");
            nextButton.Click();
        }

        [Test]
        public void MultipleFlagScan()
        {
            FlagScanCommonCode();

            AndroidElement keepScanButton = driver.FindElementByAccessibilityId("Keep Scan");
            keepScanButton.Click();

            TouchAction(542, 1196);

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    AndroidElement dashBoardText = driver.FindElementByAccessibilityId("Dashboard");
                    
                    string actText = dashBoardText.GetAttribute("content-desc");
                    
                    if (string.Equals(expText, actText))
                    {
                        break;
                    }
                    
                    Assert.That(actText, Is.EqualTo(expText));
                }
                catch (NoSuchElementException e)
                {
                    keepScanButton.Click();

                    TouchAction(542, 1196);
                }
            }

        }

        public void FlagScanCommonCode()
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

            AndroidElement passwordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordContinueButton.Click();

            AndroidElement skipButton = driver.FindElementByAccessibilityId("Skip");
            skipButton.Click();

            AndroidElement reviewNowButton = driver.FindElementByAccessibilityId("Review Now");
            reviewNowButton.Click();

            AndroidElement predicatedValueButton = driver.FindElementByAccessibilityId("Predicted Value");
            predicatedValueButton.Click();

            TouchAction(960, 746);

        }

        public void TouchAction(int xCoordinate, int yCoordinate)
        {
            var touchAction = new TouchAction(driver);
            touchAction.Press(x: xCoordinate, y: yCoordinate).Release().Perform();
        }

    }
}
