using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium_from_java_to_csharp.Pages
{
    public class FeedbackTaskPage
    {
        public FeedbackTaskPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "fb_name")]
        public IWebElement nameBox;

        [FindsBy(How = How.Id, Using = "fb_age")]
        public IWebElement ageBox;

        [FindsBy(How = How.ClassName, Using = "w3-check")]
        public IList<IWebElement> languageCheckbox;

        [FindsBy(How = How.ClassName, Using = "w3-radio")]
        public IList<IWebElement> genreRadio;

        [FindsBy(How = How.ClassName, Using = "w3-select")]
        public IWebElement ratingSelect;

        [FindsBy(How = How.Name, Using = "comment")]
        public IWebElement commentBox;

        [FindsBy(How = How.XPath, Using = "//button[text()='Send']")]
        public IWebElement sendButton;
    }
}