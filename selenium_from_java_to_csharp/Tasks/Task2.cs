using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_from_java_to_csharp.Tasks
{
    [TestClass]
    public class Task2
    {
        private IWebDriver driver;
        private IWebElement numberBox;
        private IWebElement submitButton;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://kristinek.github.io/site/tasks/provide_feedback");
            numberBox = driver.FindElement(By.Id("numb"));
            submitButton = driver.FindElement(By.XPath("//button[@class=\"w3-btn w3-orange w3-margin\"]"));
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void initialFeedbackPage() throws Exception
        {
            //         TODO:
            //         check that all field are empty and no ticks are clicked
            //         "Don't know" is selected in "Genre"
            //         "Choose your option" in "How do you like us?"
            //         check that the button send is blue with white letters
        }

        [TestMethod]
        public void emptyFeedbackPage() throws Exception
        {
            //         TODO:
            //         click "Send" without entering any data
            //         check fields are empty or "null"
            //         check button colors
            //         (green with white letter and red with white letters)
        }

        public void notEmptyFeedbackPage() throws Exception
        {
            //         TODO:
            //         fill the whole form, click "Send"
            //         check fields are filled correctly
            //         check button colors
            //         (green with white letter and red with white letters)
        }

        @Test
        public void yesOnWithNameFeedbackPage() throws Exception
        {
            //         TODO:
            //         enter only name
            //         click "Send"
            //         click "Yes"
            //         check message text: "Thank you, NAME, for your feedback!"
            //         color of text is white with green on the background
        }

        @Test
        public void yesOnWithoutNameFeedbackPage() throws Exception
        {
            //         TODO:
            //         click "Send" (without entering anything
            //         click "Yes"
            //         check message text: "Thank you for your feedback!"
            //         color of text is white with green on the background
        }

        @Test
        public void noOnFeedbackPage() throws Exception
        {
            //         TODO:
            //         fill the whole form
            //         click "Send"
            //         click "No"
            //         check fields are filled correctly
        }
    }
