using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Demo.Selenium.Bank.POM;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    private void EnterUserName(string userName)
    {
        var userIdText = _wait.Until(ExpectedConditions.ElementExists(By.Id("uid")));
        userIdText.Clear();
        userIdText.SendKeys(userName);
    }

    private void EnterPassword(string password)
    {
        var passwordText = _wait.Until(ExpectedConditions.ElementExists(By.Id("passw")));
        passwordText.Clear();
        passwordText.SendKeys(password);
    }

    public bool IsLoginUnsuccessful()
    {
        var label = _wait.Until(
            ExpectedConditions.ElementExists(By.Id("_ctl0__ctl0_Content_Main_message"))
        );
        return label.Displayed;
    }

    public MyAccountPage LoginWithValidCredentials(string userName, string password)
    {
        EnterUserName(userName);
        EnterPassword(password);
        var loginButton = _wait.Until(
            ExpectedConditions.ElementExists(By.XPath("//input[@type='submit' and @value='Login']"))
        );
        loginButton.Click();

        return new MyAccountPage(_driver);
    }

    public void LoginWithInvalidCredentials(string userName, string password)
    {
        EnterUserName(userName);
        EnterPassword(password);
        var loginButton = _wait.Until(
            ExpectedConditions.ElementExists(By.XPath("//input[@type='submit' and @value='Login']"))
        );
        loginButton.Click();
    }
}
