using OpenQA.Selenium.Appium.Android;

namespace StykuMobileTest
{
    public class ForgotPasswordTest : Caps
    {
       
        [SetUp]
        public void Setup()
        {
            AppiumSetup();
        }

        [Test]
        public void ForgotPasswordValidVerificationCode()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Enter button on homepage
            AndroidElement eButton = driver.FindElementByClassName("android.widget.Button");
            eButton.Click();

            // Enter email Id on welcome button
            AndroidElement emailInputBox = driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            // Click on email continue button
            AndroidElement emailContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            emailContinueButton.Click();

            // Click on forgot password link
            AndroidElement forgotPassword = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Forgot password\"]");
            forgotPassword.Click();

            // Enter verification code field
            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationcode = "311889";
            verificationCodeField.SendKeys(verificationcode);

            // Click on email verification continue button
            AndroidElement vContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            vContinueButton.Click();

            // Enter new password 
            AndroidElement enterNewPasswordField = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[1]");
            enterNewPasswordField.Click();
            enterNewPasswordField.SendKeys("Test@123");
            driver.HideKeyboard();
            Thread.Sleep(2000);

            //Enter confirm password field
            AndroidElement enterNewConfirmPasswordField = driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[2]");
            enterNewConfirmPasswordField.Click();
            enterNewConfirmPasswordField.SendKeys("Test@123");
            driver.HideKeyboard();


            // Click on set new password continue button
            AndroidElement newpPasswordContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            newpPasswordContinueButton.Click();
            Thread.Sleep(2000);

            // Get the value of the content-desc attribute
            AndroidElement element = driver.FindElementByXPath("/hierarchy/android.widget.Toast");
            string actResult = element.GetAttribute("text");
            string eResult = StringResources.PASSWORD_CHANGED_SUCCESS_MESSAGE;
            Assert.That(actResult, Is.EqualTo(eResult));

        }
        [Test]
        public void ForgotPasswordInvalidVerificationCode() {
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Enter button on homepage
            AndroidElement enterButton = driver.FindElementByClassName("android.widget.Button");
            enterButton.Click();

            // Enter email Id on welcome button
            AndroidElement emailInputBox =driver.FindElementByClassName("android.widget.EditText");
            emailInputBox.Click();
            emailInputBox.SendKeys(StringResources.EMAIL_ID);
            driver.HideKeyboard();

            // Click on email continue button
            AndroidElement emailContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            emailContinueButton.Click();
         
            // Click on forgot password link
            AndroidElement forgotPassword = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Forgot password\"]");
            forgotPassword.Click();

            // Enter verification code field
            AndroidElement verificationCodeField = driver.FindElementByClassName("android.widget.EditText");
            verificationCodeField.Click();
            string verificationCode = "184401";
            verificationCodeField.SendKeys(verificationCode);

            // Click on email verification continue button
            AndroidElement vContinueButton = driver.FindElementByXPath("//android.widget.Button[@content-desc=\"Continue\"]");
            vContinueButton.Click();

            // Get the value of the content-desc attribute
            AndroidElement element = driver.FindElementByXPath("//android.view.View[@content-desc=\"Incorrect Verification Code\"]");
            string actResult = element.GetAttribute("text");
            string expResult = StringResources.EMAIL_VERIFICATION_VALIDATION_CODE;
            Assert.That(actResult, Is.EqualTo(expResult));

        }  
    }
}
