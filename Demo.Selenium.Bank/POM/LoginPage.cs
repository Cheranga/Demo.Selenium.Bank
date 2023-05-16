namespace Demo.Selenium.Bank.POM;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver) => _driver = driver;

    private void EnterUserName(string userName)
    {
        var userIdText = _driver.FindElement(By.Id("uid"));
        userIdText.Clear();
        userIdText.SendKeys(userName);
    }

    private void EnterPassword(string password)
    {
        var passwordText = _driver.FindElement(By.Id("passw"));
        passwordText.Clear();
        passwordText.SendKeys(password);
    }

    public bool IsLoginUnsuccessful()
    {
        var label = _driver.FindElement(By.Id("_ctl0__ctl0_Content_Main_message"));
        return label.Displayed;
    }

    public MyAccountPage LoginWithValidCredentials(string userName, string password)
    {
        EnterUserName(userName);
        EnterPassword(password);
        var loginButton = _driver.FindElement(
            By.XPath("//input[@type='submit' and @value='Login']")
        );
        loginButton.Click();

        return new MyAccountPage(_driver);
    }

    public void LoginWithInvalidCredentials(string userName, string password)
    {
        EnterUserName(userName);
        EnterPassword(password);
        var loginButton = _driver.FindElement(
            By.XPath("//input[@type='submit' and @value='Login']")
        );
        loginButton.Click();
    }
}
