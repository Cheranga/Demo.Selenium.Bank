namespace Demo.Selenium.Bank.Login;

public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;

    public LoginTests()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        _driver = new ChromeDriver(options);
    }

    public void Dispose()
    {
        _driver.Close();
        _driver.Dispose();
    }

    [Fact(DisplayName = "Successful login")]
    public void SuccessfulLogin()
    {
        var homePage = new HomePage(_driver, @"http://demo.testfire.net/");
        var loginPage = homePage.GoToOnlineBankingLogin();
        var myAccountPage = loginPage.LoginWithValidCredentials("admin'--", "blah");
        myAccountPage.IsSuccessfullyLoggedIn().Should().BeTrue();
    }

    [Fact(DisplayName = "Unsuccessful login")]
    public void UnsuccessfulLogin()
    {
        var homePage = new HomePage(_driver, @"http://demo.testfire.net/");
        var loginPage = homePage.GoToOnlineBankingLogin();
        loginPage.LoginWithInvalidCredentials("abc", "xyz");
        loginPage.IsLoginUnsuccessful().Should().BeTrue();
    }
}
