using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium_from_java_to_csharp.Pages
{
    public class ColorSamplePage
    {
        public ColorSamplePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "start_green")]
        private IWebElement greenButton;

        [FindsBy(How = How.Id, Using = "loading_green")]
        private IWebElement loadingButton;

        [FindsBy(How = How.Id, Using = "finish_green")]
        private IWebElement finishButton;

        //Define elements in page
        //see https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/support/FindBy.html

        public void ClickStartLoadingGreen()
        {
            greenButton.Click();
            Assert.IsFalse(greenButton.Displayed);
            //implement clicking on "Start loading green" button
        }

        public void AssertLoadingGreen()
        {
            Assert.IsTrue(loadingButton.Displayed);
            Assert.AreEqual("Loading green...", loadingButton.Text);
        }

        public void AssertFinishGreen()
        {
            Assert.IsTrue(finishButton.Displayed);
            Assert.IsFalse(greenButton.Displayed);
            Assert.IsFalse(loadingButton.Displayed);
            Assert.AreEqual("Green Loaded", finishButton.Text);
        }
        //Implement methods for:
        //* 1) check that "Start loading green" button is not visible
        //* 2) check that text "Loading green..." is visible
        //* 3) check that text "Loading green..." is not visible
        //* 4) check that text "Green Loaded" is visible
    }
}
