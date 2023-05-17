﻿namespace Demo.Selenium.Bank.MyAccount;

public class GoldVisaCardTests : IDisposable
{
    private readonly IWebDriver _driver;

    public GoldVisaCardTests()
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

    [Fact(DisplayName = "Applying for GOLD Visa")]
    public void ApplyForGoldVisa()
    {
        var homePage = new HomePage(_driver, @"http://demo.testfire.net/");
        var loginPage = homePage.GoToOnlineBankingLogin();
        var myAccountPage = loginPage.LoginWithValidCredentials("admin'--", "blah");
        var goldVisaPage = myAccountPage.BrowseToApplyForGoldVisa();
        goldVisaPage.Apply();
        goldVisaPage.IsVisaAccepted().Should().BeTrue();
    }
}
