using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium_from_java_to_csharp.Pages
{
    public class FeedbackThankYouTaskPage
    {
        public FeedbackThankYouTaskPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement thankyouMessage;

        [FindsBy(How = How.CssSelector, Using = ".w3-panel.w3-green")]
        public IWebElement thankyouMessageBackground;
    }
}