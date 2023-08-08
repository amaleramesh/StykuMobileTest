using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using StykuMobileTest.Comman;

namespace StykuMobileTest
{
    public class FlaggedScansTest : Caps
    {

        public readonly string DASHBOARD = "Dashboard";

        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void KeepScan()
        {
            LoginTest();

            ReviewScans();

            AndroidElement keepScanButton = driver.FindElementByAccessibilityId("Keep Scan");
            keepScanButton.Click();

            TouchAction(542, 1196);
        }

        [Test]
        public void RemoveScan()
        {
            LoginTest();

            ReviewScans();

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
            LoginTest();

            ReviewScans();

            AndroidElement keepScanButton = driver.FindElementByAccessibilityId("Keep Scan");
            keepScanButton.Click();

            TouchAction(542, 1196);

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    AndroidElement dashBoardText = driver.FindElementByAccessibilityId("Dashboard");

                    string dashboardAttribute = dashBoardText.GetAttribute("content-desc");

                    if (string.Equals(DASHBOARD, dashboardAttribute))
                    {
                        break;
                    }

                    Assert.That(dashboardAttribute, Is.EqualTo(DASHBOARD));
                }
                catch (NoSuchElementException e)
                {
                    keepScanButton.Click();

                    TouchAction(542, 1196);
                }
            }
        }

        // This method is used to the get elements likes skip, review now and predicated value. 
        private void ReviewScans()
        {
            AndroidElement skipButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Skip\"]");
            skipButton.Click();

            AndroidElement reviewNowButton = driver.FindElementByAccessibilityId("Review Now");
            reviewNowButton.Click();

            AndroidElement predicatedValueButton = driver.FindElementByAccessibilityId("Predicted Value");
            predicatedValueButton.Click();

            TouchAction(960, 746);
        }

        private void TouchAction(int xCoordinate, int yCoordinate)
        {
            var touchAction = new TouchAction(driver);
            touchAction.Press(x: xCoordinate, y: yCoordinate).Release().Perform();
        }
    }
}
