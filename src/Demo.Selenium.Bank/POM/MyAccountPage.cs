using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Demo.Selenium.Bank.POM;

public class MyAccountPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public MyAccountPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public bool IsSuccessfullyLoggedIn()
    {
        var getAccountButton = _wait.Until(
            ExpectedConditions.ElementExists(By.Id("btnGetAccount"))
        );
        return getAccountButton is { Displayed: true };
    }

    public GoldVisaPage BrowseToApplyForGoldVisa()
    {
        var link = _wait.Until(
            ExpectedConditions.ElementExists(By.CssSelector("#_ctl0__ctl0_Content_Main_promo a"))
        );
        link.Click();

        return new GoldVisaPage(_driver);
    }
}
