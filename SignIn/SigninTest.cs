using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.MultiTouch;
using StykuMobileTest.Comman;

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
        public void TestNoScansVerified()
        {
            TestHasScansVerified();
        }

        [Test]
        public void TestHasScansVerified()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AndroidElement enterButton = driver.FindElementByClassName("android.widget.Button");
            enterButton.Click();

            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

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
            TouchAction(376, 981);

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
            new Actions(driver).SendKeys("1216").Perform();
            driver.HideKeyboard();

            // Click on Verify button
            AndroidElement phoneNumberVerifyButton = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Verify\"]\r\n"));
            phoneNumberVerifyButton.Click();

            // Scroll down
            AndroidElement element = driver.FindElementByXPath("//android.view.View[@content-desc=\". \"]");
            TouchAction touchAction = new TouchAction(driver);
            touchAction.Tap(element).Perform();
            ScrollDown();

            // Click on accept button
            AndroidElement acceptButton = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Accept\"]"));
            acceptButton.Click();
        }

        [Test]
        public void TestHasScansNotVerified()
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

            AndroidElement fristNameField = driver.FindElementByClassName("android.widget.EditText");
            String ActualName = fristNameField.GetAttribute("text");
            String ExpectedName = "Sitaram";
            Assert.That(ActualName, Is.EqualTo(ExpectedName));

            AndroidElement lastNameField = driver.FindElement(By.XPath("//android.widget.EditText[@index='3']"));
            String ActualLastName = lastNameField.GetAttribute("text");
            String ExpectedLastName = "Amale";
            Assert.That(ActualLastName, Is.EqualTo(ExpectedLastName));

            AndroidElement nameContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            nameContinueButton.Click();

            // Enter verification code field
            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationcode = "632797";
            verificationCodeField.SendKeys(verificationcode);
            driver.HideKeyboard();

            // Click OK verify button
            AndroidElement emailVerifyButton = driver.FindElementByAccessibilityId("Verify");
            emailVerifyButton.Click();

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
            TouchAction(376, 981);

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
            new Actions(driver).SendKeys("9035").Perform();
            driver.HideKeyboard();

            // Click on Verify button
            AndroidElement phoneNumberVerifyButton = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Verify\"]\r\n"));
            phoneNumberVerifyButton.Click();

            // Enter password 
            AndroidElement enterNewPasswordField = driver.FindElementByXPath("//android.widget.EditText[@index='2']");
            enterNewPasswordField.Click();
            enterNewPasswordField.SendKeys("Test@123");
            driver.HideKeyboard();
            Thread.Sleep(2000);

            //Enter confirm password field
            AndroidElement enterNewConfirmPasswordField = driver.FindElementByXPath("//android.widget.EditText[@index='7']");
            enterNewConfirmPasswordField.Click();
            enterNewConfirmPasswordField.SendKeys("Test@123");
            driver.HideKeyboard();

            //Click on toggle button
            AndroidElement toogleButton = driver.FindElementByXPath("//android.widget.Switch[@index='8']");
            toogleButton.Click();

            // Click on set new password continue button
            AndroidElement newpPasswordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            newpPasswordContinueButton.Click();
            Thread.Sleep(2000);
            
            // Scroll down
            AndroidElement element = driver.FindElementByXPath("//android.view.View[@content-desc=\". \"]");
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
            int endY = (int)(driver.Manage().Window.Size.Height * -14);
            touchAction.Press(startX, startY).Wait(2000).MoveTo(startX, endY).Release().Perform();

        }
        private void TouchAction(int xCoordinate, int yCoordinate)
        {
            var touchAction = new TouchAction(driver);
            touchAction.Press(x: xCoordinate, y: yCoordinate).Release().Perform();
        }

    }
}

