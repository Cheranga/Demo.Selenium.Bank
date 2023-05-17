using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Demo.Selenium.Bank.POM;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly string _url;
    private readonly WebDriverWait _wait;

    public HomePage(IWebDriver driver, string url)
    {
        _driver = driver;
        _url = url;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public LoginPage GoToOnlineBankingLogin()
    {
        _driver.Navigate().GoToUrl(_url);

        var accountLink = _wait.Until(ExpectedConditions.ElementExists(By.Id("AccountLink")));
        accountLink.Click();

        return new LoginPage(_driver);
    }
}
