using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using StykuMobileTest.Comman;

namespace StykuMobileTest
{
    public class DemographicsTest : Caps
    {
        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void DemographicsProfileTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            AndroidElement enterButton = driver.FindElementByClassName("android.widget.Button");
            enterButton.Click();

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

            AndroidElement ProfileInformationContinueButton = driver.FindElementByAccessibilityId("Continue");
            ProfileInformationContinueButton.Click();

            AndroidElement metricButton = driver.FindElementByAccessibilityId("Metric");
            metricButton.Click();

            AndroidElement UnitSystemContinueButton = driver.FindElementByAccessibilityId("Continue");
            UnitSystemContinueButton.Click();

            // Select date of date of birth
            SelectMonth();
            SelectDate();
            SelectYear();

            AndroidElement birthdayContinueButton = driver.FindElementByAccessibilityId("Continue");
            birthdayContinueButton.Click();

            // Select height
            SelectHeight();

            // Height continue button
            AndroidElement heightContinueButton = driver.FindElementByAccessibilityId("Continue");
            heightContinueButton.Click();

            // Select weight for new profile
            try
            {
                AndroidElement weightElement = driver.FindElementByAccessibilityId("Weight");
                SelectWeight();
                AndroidElement weightContinueButton = driver.FindElementByAccessibilityId("Continue");
                weightContinueButton.Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Element not found: {e.Message}");
            }

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

            // Click on Country
            AndroidElement SelectCountry = driver.FindElementByAccessibilityId("Afghanistan");
            SelectCountry.Click();
            driver.HideKeyboard();

            // Click on Country Continue button
            AndroidElement CountryContinueButton = driver.FindElementByAccessibilityId("Continue");
            CountryContinueButton.Click();
        }
        public void SelectMonth()
        {
            for (int i = 0; i <= 12; i++)
            {
                IReadOnlyCollection<AndroidElement> androidElements = driver.FindElementsByClassName("android.widget.SeekBar");
                AndroidElement monthElement = androidElements.ElementAt(0);
                string elementText = monthElement.GetAttribute("content-desc");

                if (elementText == "May")
                {
                    break;
                }
                else
                {
                    TouchAction touchAction = new TouchAction(driver);
                    touchAction.Press(281, 936).MoveTo(281, 1069).Release().Perform();
                }
            }

        }
        private void SelectDate()
        {
            try
            {
                for (int i = 0; i <= 31; i++)
                {
                    IReadOnlyCollection<AndroidElement> androidElements = driver.FindElementsByClassName("android.widget.SeekBar");
                    AndroidElement dateElement = androidElements.ElementAt(1);
                    string elementText = dateElement.GetAttribute("content-desc");

                    if (elementText == "12")
                    {
                        break;
                    }
                    else
                    {
                        TouchAction touchAction = new TouchAction(driver);
                        touchAction.Press(626, 943).MoveTo(619, 1066).Release().Perform();
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Element not found: {e.Message}");
            }

        }
        public void SelectYear()
        {
            try
            {
                for (int i = 0; i <= 3; i++)
                {
                    IReadOnlyCollection<AndroidElement> androidElements = driver.FindElementsByClassName("android.widget.SeekBar");
                    AndroidElement yearElement = androidElements.ElementAt(2);
                    string elementText = yearElement.GetAttribute("content-desc");

                    if (elementText == "2015")
                    {
                        break;
                    }
                    else
                    {
                        TouchAction touchAction = new TouchAction(driver);
                        touchAction.Press(781, 946).MoveTo(788, 1062).Release().Perform();
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"Element not found: {e.Message}");
            }
        }
        private void SelectHeight()
        {
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    AndroidElement heightElement = driver.FindElementByClassName("android.widget.SeekBar");
                    string elementText = heightElement.GetAttribute("content-desc");

                    if (elementText == "150")
                    {
                        break;
                    }
                    else
                    {
                        TouchAction touchAction = new(driver);
                        touchAction.Press(510, 989).MoveTo(514, 1112).Release().Perform();
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                // Handle the exception gracefully (e.g., logging, print error message, etc.)
                Console.WriteLine($"Element not found: {e.Message}");
            }
        }
        private void SelectWeight()
        {
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    AndroidElement weightElement = driver.FindElementByClassName("android.widget.SeekBar");
                    string elementText = weightElement.GetAttribute("content-desc");

                    if (elementText == "58")
                    {
                        break;
                    }
                    else
                    {
                        TouchAction touchAction = new(driver);
                        touchAction.Press(528, 1010).MoveTo(528, 1122).Release().Perform();
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                // Handle the exception gracefully (e.g., logging, print error message, etc.)
                Console.WriteLine($"Element not found: {e.Message}");
            }
        }
    }
}

