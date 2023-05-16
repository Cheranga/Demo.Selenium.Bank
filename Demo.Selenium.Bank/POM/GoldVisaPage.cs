namespace Demo.Selenium.Bank.POM;

public class GoldVisaPage
{
    private readonly IWebDriver _driver;

    public GoldVisaPage(IWebDriver driver) => _driver = driver;

    public bool IsVisaAccepted()
    {
        var label = _driver.FindElement(By.Id("_ctl0__ctl0_Content_Main_lblMessage"));
        return label is { Displayed: true }
            && label.Text.StartsWith("Your new Altoro Mutual Gold VISA");
    }

    private void EnterPassword()
    {
        var passwordText = _driver.FindElement(By.XPath("//input[@type='password']"));
        passwordText.Clear();
        passwordText.SendKeys("blah");
    }

    private void ClickApply()
    {
        var applyButton = _driver.FindElement(
            By.XPath("//input[@type='submit' and @value='Submit']")
        );
        applyButton.Click();
    }

    public void Apply()
    {
        EnterPassword();
        ClickApply();
    }
}
