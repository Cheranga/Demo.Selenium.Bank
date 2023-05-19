using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Demo.Selenium.Bank.POM;

public class GoldVisaPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public GoldVisaPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public bool IsVisaAccepted()
    {
        var label = _wait.Until(
            ExpectedConditions.ElementExists(By.Id("_ctl0__ctl0_Content_Main_lblMessage"))
        );
        return label is { Displayed: true }
            && label.Text.StartsWith("Your new Altoro Mutual Gold VISA");
    }

    private void EnterPassword(string password)
    {
        var passwordText = _wait.Until(
            ExpectedConditions.ElementExists(By.XPath("//input[@type='password']"))
        );
        passwordText.Clear();
        passwordText.SendKeys("blah");
    }

    private void ClickApply()
    {
        var applyButton = _wait.Until(
            ExpectedConditions.ElementExists(
                By.XPath("//input[@type='submit' and @value='Submit']")
            )
        );
        applyButton.Click();
    }

    public void Apply(string password)
    {
        EnterPassword(password);
        ClickApply();
    }
}
