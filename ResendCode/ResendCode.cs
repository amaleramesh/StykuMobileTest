using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;

namespace StykuMobileTest
{
    public class ResendCode : Caps
    {
        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void  ResendEmailVerificationCode()
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

            AndroidElement resendEmailVerificationlink = driver.FindElementByAccessibilityId("Resend verification email");
            resendEmailVerificationlink.Click();

            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationcode = "080565";
            verificationCodeField.SendKeys(verificationcode);
            driver.HideKeyboard();

            AndroidElement emailVerifyButton = driver.FindElementByAccessibilityId("Verify");
            emailVerifyButton.Click();

            AndroidElement welComeText = driver.FindElementByAccessibilityId("Welcome");
            string actResult=welComeText.GetAttribute("content-desc");
            string expResult = "Welcome";

            Assert.That(actResult, Is.EqualTo(expResult));

        }
        [Test]
        public void ResendPhoneVerificationCode() 
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

            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationcode = "260379";
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
            AndroidElement counrty = driver.FindElementByClassName("android.view.View");
            counrty.Click();

            // Enter mobile number
            AndroidElement mobileNumberTextbox = driver.FindElement(By.XPath("//android.widget.EditText[@index='3']"));
            mobileNumberTextbox.Click();
            mobileNumberTextbox.SendKeys("9960797008");
            driver.HideKeyboard();

            // Click on verify button
            AndroidElement phoneVerifyButton = driver.FindElementByAccessibilityId("Verify");
            phoneVerifyButton.Click();

            AndroidElement resendButton=driver.FindElementByAccessibilityId("Resend");
            resendButton.Click();

            // Enter OTP
            AndroidElement verificationCodeTextfield = driver.FindElement(By.ClassName("android.widget.EditText"));
            verificationCodeTextfield.Click();
            new Actions(driver).SendKeys("0911").Perform();
            driver.HideKeyboard();

            // Click on Verify button
            AndroidElement phoneNumberVerifyButton = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Verify\"]\r\n"));
            phoneNumberVerifyButton.Click();

            AndroidElement infoStyku =driver.FindElementByAccessibilityId("info@styku.com");
            String actualResult=infoStyku.GetAttribute("content-desc");
            String expectedResult = "info@styku.com";
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }
    }
}
