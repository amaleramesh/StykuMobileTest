using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace StykuMobileTest
{
    public class Demographics : Caps
    {
        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }
        
        [Test]
        public void DemographicsForNewProfileTest() 
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

            AndroidElement demographicsContinueButton =driver.FindElementByAccessibilityId("Continue");
            demographicsContinueButton.Click();

            // Select date of date of birth
            SelectMonth();
            SelectDate();
            SelectYear();

            AndroidElement birthdayContinueButton = driver.FindElementByAccessibilityId("Continue");
            birthdayContinueButton.Click();

            AndroidElement metricButton =driver.FindElementByAccessibilityId("Metric");
            metricButton.Click();

            AndroidElement unitSystemContinueButton = driver.FindElementByAccessibilityId("Continue");
            unitSystemContinueButton.Click();

            // Select height
            SelectHeight();

            // gender continue button
            AndroidElement heightContinueButton = driver.FindElementByAccessibilityId("Continue");
            heightContinueButton.Click();

            // Select gender
            AndroidElement genderButton = driver.FindElementByAccessibilityId("Male");
            genderButton.Click();

            //gender continue button
            AndroidElement genderContinueButton = driver.FindElementByAccessibilityId("Continue");
            genderContinueButton.Click();

            // Select ethnicity
            AndroidElement ethnicity = driver.FindElementByAccessibilityId("Black or African American");
            ethnicity.Click();

            // continue button
            genderContinueButton.Click();

            // Click on skip button
            AndroidElement skipButton = driver.FindElementByAccessibilityId("Skip");
            skipButton.Click();

        }

        private void SelectMonth()
        {
           
            for (int i = 0; i <= 12; i++)
            {
                IReadOnlyCollection<AndroidElement> androidElements = driver.FindElementsByClassName("android.widget.SeekBar");
                AndroidElement monthElement = androidElements.ElementAt(0);
                string elementText = monthElement.GetAttribute("content-desc");

                if (elementText == "August")
                {
                    break;
                }
                else
                {
                    TouchAction touchAction = new TouchAction(driver);
                    touchAction.Press(180, 693).MoveTo(180, 591).Release().Perform();
                }
            }      

        }
        private void SelectDate() 
        {
            for (int i = 0; i <= 31; i++)
            {
                IReadOnlyCollection<AndroidElement> androidElements = driver.FindElementsByClassName("android.widget.SeekBar");
                AndroidElement dateElement = androidElements.ElementAt(1);
                string elementText = dateElement.GetAttribute("content-desc");

                if (elementText == "20")
                {
                    break;
                }
                else
                {
                    TouchAction touchAction = new TouchAction(driver);
                    touchAction.Press(419, 682).MoveTo(417, 593).Release().Perform();
                }
            }
        }
        public void SelectYear() 
        {
            for (int i = 0; i <= 50; i++)
            {
                IReadOnlyCollection<AndroidElement> androidElements = driver.FindElementsByClassName("android.widget.SeekBar");
                AndroidElement yearElement = androidElements.ElementAt(2);
                string elementText = yearElement.GetAttribute("content-desc");

                if (elementText == "2000")
                {
                    break;
                }
                else
                {
                    TouchAction touchAction = new TouchAction(driver);
                    touchAction.Press(538, 771).MoveTo(536, 673).Release().Perform();
                }
            }
        }
        private void SelectHeight() 
        {
            for (int i = 0; i <= 50; i++)
            {
                AndroidElement heightElement = driver.FindElementByClassName("android.widget.SeekBar");
                string elementText = heightElement.GetAttribute("content-desc");

                if (elementText == "155")
                {
                    break;
                }
                else
                {
                    TouchAction touchAction = new(driver);
                    touchAction.Press(328, 726).MoveTo(332, 639).Release().Perform();
                }
            }
        }


    }
}

