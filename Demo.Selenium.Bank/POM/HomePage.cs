namespace Demo.Selenium.Bank.POM;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly string _url;

    public HomePage(IWebDriver driver, string url)
    {
        _driver = driver;
        _url = url;
    }

    public LoginPage GoToOnlineBankingLogin()
    {
        _driver.Navigate().GoToUrl(_url);
        _driver.FindElement(By.Id("AccountLink")).Click();
        return new LoginPage(_driver);
    }
}
