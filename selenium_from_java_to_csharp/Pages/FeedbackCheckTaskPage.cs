using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium_from_java_to_csharp.Pages
{
    public class FeedbackCheckTaskPage
    {
        public FeedbackCheckTaskPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement submittedName;

        [FindsBy(How = How.Id, Using = "age")]
        public IWebElement submittedAge;

        [FindsBy(How = How.Id, Using = "language")]
        public IWebElement submittedLanguage;

        [FindsBy(How = How.Id, Using = "gender")]
        public IWebElement submittedGender;

        [FindsBy(How = How.Id, Using = "option")]
        public IWebElement submittedOption;

        [FindsBy(How = How.Id, Using = "comment")]
        public IWebElement submittedComment;

        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        public IWebElement yesButton;

        [FindsBy(How = How.XPath, Using = "//button[text()='No']")]
        public IWebElement noButton;
    }
}