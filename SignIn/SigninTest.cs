using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.MultiTouch;

namespace StykuMobileTest
{
    public class SignInTest : Caps
    {
        
       [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void TestSignInNewUser()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AndroidElement eButton = driver.FindElementByClassName("android.widget.Button");
            eButton.Click();

            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            AndroidElement emailContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            emailContinueButton.Click();

            // Enter verification code field
            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationcode = "660499";
            verificationCodeField.SendKeys(verificationcode);
            driver.HideKeyboard();

            // Click ok verify button
            AndroidElement emailVerifyButton = driver.FindElementByAccessibilityId("Verify");
            emailVerifyButton.Click();

            // Enter first name
            AndroidElement fristNameField = driver.FindElementByClassName("android.widget.EditText");
            fristNameField.Click();
            fristNameField.SendKeys("Ramesh");
            driver.HideKeyboard();

            // Enter last name 
            AndroidElement lastNameField = driver.FindElement(By.XPath("//android.widget.EditText[@index='3']"));
            lastNameField.Click();
            lastNameField.SendKeys("Amale");
            driver.HideKeyboard();

            // Click on continue button
            AndroidElement nameContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            nameContinueButton.Click();

            // Enter password
            AndroidElement passwordField = driver.FindElementByClassName("android.widget.EditText");
            passwordField.Click();
            passwordField.SendKeys("Test@123");
            driver.HideKeyboard();

            // Enter confirm password
            AndroidElement confirmPasswordField = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View/android.view.View/android.widget.ScrollView/android.widget.EditText[2]");
            confirmPasswordField.Click();
            confirmPasswordField.SendKeys("Test@123");
            driver.HideKeyboard();

            // Remember me button
            AndroidElement toggleButton = driver.FindElement(By.XPath("//android.widget.Switch[@index='6']")); ;
            toggleButton.Click();

            // Click on continue button
            AndroidElement passwordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordContinueButton.Click();

            // Click on don't allow button
            AndroidElement dontAllowButton = driver.FindElementById("com.android.permissioncontroller:id/permission_deny_button");
            dontAllowButton.Click();

            // Click on country drop-down
            AndroidElement countryDropdown = driver.FindElementByAccessibilityId("🇺🇸");
            countryDropdown.Click();

            // Click in search box 
            AndroidElement countrySearchBox = driver.FindElement(By.XPath("//android.widget.EditText[@index='0']"));
            countrySearchBox.Click();
            countrySearchBox.SendKeys("91");
            driver.HideKeyboard();

            // Select country
            AndroidElement counrty = driver.FindElement(By.XPath("//android.view.View[@index='0']"));
            counrty.Click();

            // Enter mobile number
            AndroidElement mobileNumberTextbox = driver.FindElement(By.XPath("//android.widget.EditText[@index='3']"));
            mobileNumberTextbox.Click();
            mobileNumberTextbox.SendKeys("9960797008");
            driver.HideKeyboard();

            // Click on verify button
            AndroidElement phoneVerifyButton = driver.FindElementByAccessibilityId("Verify");
            phoneVerifyButton.Click();

            // Enter OTP
            AndroidElement verificationCodeTextfield = driver.FindElement(By.ClassName("android.widget.EditText"));
            bool isEnabledotp = verificationCodeTextfield.Enabled;
            Console.WriteLine($"Is the element enabled? {isEnabledotp}");
            verificationCodeTextfield.Click();
            new Actions(driver).SendKeys("1180").Perform();
            driver.HideKeyboard();

            // Click on Verify button
            AndroidElement phoneNumberVerifyButton = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Verify\"]\r\n"));
            phoneNumberVerifyButton.Click();

            // Scroll down
            AndroidElement element = driver.FindElement(By.XPath("//android.widget.Button[@index='1']"));
            TouchAction touchAction = new TouchAction(driver);
            touchAction.Tap(element).Perform();
            ScrollDown();

            // Click on accept button
            AndroidElement acceptButton = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Accept\"]"));
            acceptButton.Click();

        }

        private void ScrollDown()
        {
            TouchAction touchAction = new TouchAction(driver);
            int startX = driver.Manage().Window.Size.Width / 2;
            int startY = (int)(driver.Manage().Window.Size.Height * 0.8);
            int endY = (int)(driver.Manage().Window.Size.Height * - 9);
            touchAction.Press(startX, startY).Wait(2000).MoveTo(startX, endY).Release().Perform();

        }

    }
}

