namespace Demo.Selenium.Bank.POM;

public class MyAccountPage
{
    private readonly IWebDriver _driver;

    public MyAccountPage(IWebDriver driver) => _driver = driver;

    public IWebElement GetAccountButton => _driver.FindElement(By.Id("btnGetAccount"));

    public bool IsSuccessfullyLoggedIn()
    {
        var getAccountButton = _driver.FindElement(By.Id("btnGetAccount"));
        return getAccountButton is { Displayed: true };
    }

    public GoldVisaPage BrowseToApplyForGoldVisa()
    {
        var link = _driver.FindElement(By.CssSelector("#_ctl0__ctl0_Content_Main_promo a"));
        link.Click();

        return new GoldVisaPage(_driver);
    }
}
