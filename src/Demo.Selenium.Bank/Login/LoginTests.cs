using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Demo.Selenium.Bank.Login;

[Collection(TestCollection.Name)]
public class LoginTests : IDisposable
{
    private readonly ApiSettings _apiSettings;
    private readonly IWebDriver _driver;
    private readonly ITestOutputHelper _logger;

    public LoginTests(TestInitializer testInitializer, ITestOutputHelper logger)
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        _driver = new ChromeDriver(options);
        _apiSettings = testInitializer.ServiceProvider.GetRequiredService<ApiSettings>();
        _logger = logger;
    }

    public void Dispose()
    {
        _driver.Close();
        _driver.Dispose();
    }

    [Fact(DisplayName = "Successful login")]
    public void SuccessfulLogin()
    {
        var homePage = new HomePage(_driver, _apiSettings.BaseUrl);
        var loginPage = homePage.GoToOnlineBankingLogin();
        var myAccountPage = loginPage.LoginWithValidCredentials(
            _apiSettings.UserName,
            _apiSettings.Password
        );
        myAccountPage.IsSuccessfullyLoggedIn().Should().BeTrue();
        _logger.WriteLine($"{nameof(SuccessfulLogin)} success");
    }

    [Fact(DisplayName = "Unsuccessful login")]
    public void UnsuccessfulLogin()
    {
        var homePage = new HomePage(_driver, _apiSettings.BaseUrl);
        var loginPage = homePage.GoToOnlineBankingLogin();
        loginPage.LoginWithInvalidCredentials("abc", "xyz");
        loginPage.IsLoginUnsuccessful().Should().BeTrue();
        _logger.WriteLine($"{nameof(UnsuccessfulLogin)} success");
    }
}
