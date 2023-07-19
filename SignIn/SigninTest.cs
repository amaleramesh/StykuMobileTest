using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium;

namespace StykuMobileTest
{
    public class SigninTest : Caps
    {
        [SetUp]
        public void Setup()
        {
            Appiumsetup();
        }

        [Test]
        public void TestSignInNewUser()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AndroidElement ebutton = driver.FindElementByClassName("android.widget.Button");
            ebutton.Click();

            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            AndroidElement emailContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            emailContinueButton.Click();

            // Enter verification code field
            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationcode = "198829";
            verificationCodeField.SendKeys(verificationcode);
            driver.HideKeyboard();

            // click ok Verify button
            AndroidElement emailVerifyButton = driver.FindElementByAccessibilityId("Verify");
            emailVerifyButton.Click();

            //  Enter frist name
            AndroidElement fristNameField = driver.FindElementByClassName("android.widget.EditText");
            fristNameField.Click();
            fristNameField.SendKeys("Ramesh");
            driver.HideKeyboard();

            //  Enter last name 
            AndroidElement lastNameField = driver.FindElement(By.XPath("//android.widget.EditText[@index='3']"));
            lastNameField.Click();
            lastNameField.SendKeys("Amale");
            driver.HideKeyboard();

            //  Click on continue button
            AndroidElement nameContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            nameContinueButton.Click();

            //  Enter Password
            AndroidElement passwordField = driver.FindElementByClassName("android.widget.EditText");
            passwordField.Click();
            passwordField.SendKeys("Test@123");
            driver.HideKeyboard();

            //  Enter confirm Password
            AndroidElement confirmPasswordField = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.view.View/android.view.View/android.widget.ScrollView/android.widget.EditText[2]");
            confirmPasswordField.Click();
            confirmPasswordField.SendKeys("Test@123");
            driver.HideKeyboard();

            //  Remeber me button
            AndroidElement tbutton = driver.FindElement(By.XPath("//android.widget.Switch[@index='6']")); ;
            tbutton.Click();

            // click on continue button
            AndroidElement passwordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            passwordContinueButton.Click();


            //  click on dont allow
            AndroidElement dontallowbtn = driver.FindElementById("com.android.permissioncontroller:id/permission_deny_button");
            dontallowbtn.Click();

            //  click on country dropdown
            AndroidElement countryDropdown = driver.FindElementByAccessibilityId("🇺🇸");
            countryDropdown.Click();

            //click in serach box 
            AndroidElement countrySearchBox = driver.FindElement(By.XPath("//android.widget.EditText[@index='0']"));
            countrySearchBox.Click();
            countrySearchBox.SendKeys("91");
            driver.HideKeyboard();

            // Select country
            AndroidElement counrty = driver.FindElement(By.XPath("//android.view.View[@index='0']"));
            counrty.Click();

            //  Enter mobile number
            AndroidElement mobileNumberTextbox = driver.FindElement(By.XPath("//android.widget.EditText[@index='3']"));
            bool isEnabled = mobileNumberTextbox.Enabled;
            Console.WriteLine($"Is the element enabled? {isEnabled}");
            mobileNumberTextbox.Click();
            mobileNumberTextbox.SendKeys("9960797008");
            driver.HideKeyboard();

            //  Click on verify button
            AndroidElement phoneVerifyButton = driver.FindElementByAccessibilityId("Verify");
            phoneVerifyButton.Click();

            //  Enter OTP
            AndroidElement verificationCodeTextfield = driver.FindElement(By.ClassName("android.widget.EditText"));
            bool isEnabledotp = verificationCodeTextfield.Enabled;
            Console.WriteLine($"Is the element enabled? {isEnabledotp}");
            verificationCodeTextfield.Click();
            new Actions(driver).SendKeys("7109").Perform();

            //  Click on Verify button 
            AndroidElement codeVerifyButton = driver.FindElementByAccessibilityId("Verify");
            codeVerifyButton.Click();

            driver.FindElement(MobileBy.AndroidUIAutomator("android.widget.Button"));

        }
    }
}

