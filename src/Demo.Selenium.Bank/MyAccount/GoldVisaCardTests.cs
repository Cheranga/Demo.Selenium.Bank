using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Demo.Selenium.Bank.MyAccount;

[Collection(TestCollection.Name)]
public class GoldVisaCardTests : IDisposable
{
    private readonly ApiSettings _apiSettings;
    private readonly IWebDriver _driver;
    private readonly ITestOutputHelper _logger;

    public GoldVisaCardTests(TestInitializer initializer, ITestOutputHelper logger)
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        _driver = new ChromeDriver(options);
        _apiSettings = initializer.ServiceProvider.GetRequiredService<ApiSettings>();
        _logger = logger;
    }

    public void Dispose()
    {
        _driver.Close();
        _driver.Dispose();
    }

    [Fact(DisplayName = "Applying for GOLD Visa")]
    public void ApplyForGoldVisa()
    {
        var homePage = new HomePage(_driver, _apiSettings.BaseUrl);
        var loginPage = homePage.GoToOnlineBankingLogin();
        var myAccountPage = loginPage.LoginWithValidCredentials(
            _apiSettings.UserName,
            _apiSettings.Password
        );
        var goldVisaPage = myAccountPage.BrowseToApplyForGoldVisa();
        goldVisaPage.Apply();
        goldVisaPage.IsVisaAccepted().Should().BeTrue();
        _logger.WriteLine($"{nameof(ApplyForGoldVisa)} success");
    }
}
