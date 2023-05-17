using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Demo.Selenium.Bank.Login;

public class LoginTests : IDisposable, IClassFixture<TestInitializer>
{
    private readonly IWebDriver _driver;
    private readonly IServiceProvider _serviceProvider;
    private readonly ITestOutputHelper _logger;

    public LoginTests(TestInitializer testInitializer, ITestOutputHelper logger)
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        _driver = new ChromeDriver(options);
        _serviceProvider = testInitializer.ServiceProvider;
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
        // var configuration = _serviceProvider.GetRequiredService<IConfiguration>();
        // var baseUrl = configuration.GetValue<string>("baseUrl");
        var configuration = _serviceProvider.GetRequiredService<ApiSettings>();
        var baseUrl = configuration.BaseUrl;
        var homePage = new HomePage(_driver, baseUrl!);
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