using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using selenium_from_java_to_csharp.Pages;
using OpenQA.Selenium.Support.UI;

namespace selenium_from_java_to_csharp.Tasks
{
    [TestClass]
    public class Task2
    {
        IWebDriver driver;
        FeedbackTaskPage taskPage;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://kristinek.github.io/site/tasks/provide_feedback");
            taskPage = new FeedbackTaskPage(driver);
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void InitialFeedbackPage()
        {
            Assert.AreEqual("", taskPage.nameBox.Text);
            Assert.AreEqual("", taskPage.ageBox.Text);
            foreach (var checkbox in taskPage.languageCheckbox)
            {
                Assert.IsFalse(checkbox.Selected);
            }
            Assert.IsTrue(taskPage.genreRadio[2].Selected);
            var select = new SelectElement(taskPage.ratingSelect);
            Assert.AreEqual("Choose your option", select.SelectedOption.Text);
            Assert.AreEqual("", taskPage.commentBox.Text);
            Assert.AreEqual("rgba(33, 150, 243, 1)", taskPage.sendButton.GetCssValue("background-color"));
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskPage.sendButton.GetCssValue("color"));
            
            //check that all field are empty and no ticks are clicked
            //"Don't know" is selected in "Genre"
            //"Choose your option" in "How do you like us?"
            //check that the button send is blue with white letters
        }

        [TestMethod]
        public void EmptyFeedbackPage()
        {
            taskPage.sendButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FeedbackCheckTaskPage taskCheckPage = new FeedbackCheckTaskPage(driver);
            Assert.IsTrue(taskCheckPage.submittedName.Text == "", $"Expected empty or 'null' but got '{taskCheckPage.submittedName.Text}'");
            Assert.IsTrue(taskCheckPage.submittedAge.Text == "", $"Expected empty or 'null' but got '{taskCheckPage.submittedAge.Text}'");
            Assert.IsTrue(taskCheckPage.submittedLanguage.Text == "", $"Expected empty or 'null' but got '{taskCheckPage.submittedLanguage.Text}'");
            Assert.IsTrue(taskCheckPage.submittedGender.Text == "null", $"Expected empty or 'null' but got '{taskCheckPage.submittedGender.Text}'");
            Assert.IsTrue(taskCheckPage.submittedOption.Text == "null", $"Expected empty or 'null' but got '{taskCheckPage.submittedOption.Text}'");
            Assert.IsTrue(taskCheckPage.submittedComment.Text == "", $"Expected empty or 'null' but got '{taskCheckPage.submittedComment.Text}'");
            Assert.AreEqual("rgba(76, 175, 80, 1)", taskCheckPage.yesButton.GetCssValue("background-color")); // green
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskCheckPage.yesButton.GetCssValue("color")); // white
            Assert.AreEqual("rgba(244, 67, 54, 1)", taskCheckPage.noButton.GetCssValue("background-color")); // red
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskCheckPage.noButton.GetCssValue("color")); // white
            
            //click "Send" without entering any data
            //check fields are empty or "null"
            //check button colors
            //(green with white letter and red with white letters)
        }

        [TestMethod]
        public void NotEmptyFeedbackPage()
        {
            //Arrange
            string name = "Marcis";
            string stringAge = "27";
            string selectElementRating = "Bad";
            string longComment = new string('X', 500);

            //Act
            taskPage.nameBox.SendKeys(name);
            taskPage.ageBox.SendKeys(stringAge);
            taskPage.languageCheckbox[0].Click(); //english
            taskPage.genreRadio[0].Click(); //male
            var select = new SelectElement(taskPage.ratingSelect);
            select.SelectByText(selectElementRating);
            taskPage.commentBox.SendKeys(longComment);
            taskPage.sendButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FeedbackCheckTaskPage taskCheckPage = new FeedbackCheckTaskPage(driver);

            //Assert
            Assert.AreEqual(name, taskCheckPage.submittedName.Text);
            Assert.AreEqual(stringAge, taskCheckPage.submittedAge.Text);
            Assert.AreEqual("English", taskCheckPage.submittedLanguage.Text);
            Assert.AreEqual("male", taskCheckPage.submittedGender.Text);
            Assert.AreEqual(selectElementRating, taskCheckPage.submittedOption.Text);
            Assert.AreEqual(longComment, taskCheckPage.submittedComment.Text);
            Assert.AreEqual("rgba(76, 175, 80, 1)", taskCheckPage.yesButton.GetCssValue("background-color")); // green
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskCheckPage.yesButton.GetCssValue("color")); // white
            Assert.AreEqual("rgba(244, 67, 54, 1)", taskCheckPage.noButton.GetCssValue("background-color")); // red
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskCheckPage.noButton.GetCssValue("color")); // white

            //fill the whole form, click "Send"
            //check fields are filled correctly
            //check button colors
            //(green with white letter and red with white letters)
        }

        [TestMethod]
        public void YesOnWithNameFeedbackPage()
        {
            //Arrange
            string name = "Marcis";

            //Act
            taskPage.nameBox.SendKeys(name);
            taskPage.sendButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FeedbackCheckTaskPage taskCheckPage = new FeedbackCheckTaskPage(driver);
            taskCheckPage.yesButton.Click();
            FeedbackThankYouTaskPage taskThankYouPage = new FeedbackThankYouTaskPage(driver);
            
            //Assert
            Assert.AreEqual($"Thank you, {name}, for your feedback!", taskThankYouPage.thankyouMessage.Text);
            Assert.AreEqual("rgba(76, 175, 80, 1)", taskThankYouPage.thankyouMessageBackground.GetCssValue("background-color")); // green
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskThankYouPage.thankyouMessage.GetCssValue("color")); // white

            //enter only name
            //click "Send"
            //click "Yes"
            //check message text: "Thank you, NAME, for your feedback!"
            //color of text is white with green on the background
        }

        [TestMethod]
        public void YesOnWithoutNameFeedbackPage()
        {
            taskPage.sendButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FeedbackCheckTaskPage taskCheckPage = new FeedbackCheckTaskPage(driver);
            taskCheckPage.yesButton.Click();
            FeedbackThankYouTaskPage taskThankYouPage = new FeedbackThankYouTaskPage(driver);
            Assert.AreEqual($"Thank you for your feedback!", taskThankYouPage.thankyouMessage.Text);
            Assert.AreEqual("rgba(76, 175, 80, 1)", taskThankYouPage.thankyouMessageBackground.GetCssValue("background-color")); // green
            Assert.AreEqual("rgba(255, 255, 255, 1)", taskThankYouPage.thankyouMessage.GetCssValue("color")); // white

            //click "Send" (without entering anything
            //click "Yes"
            //check message text: "Thank you for your feedback!"
            //color of text is white with green on the background
        }

        [TestMethod]
        public void NoOnFeedbackPage()
        {
            //Arrange
            string name = "Marcis";
            string stringAge = "27";
            string selectElementRating = "Bad";
            string longComment = new string('X', 500);

            //Act
            taskPage.nameBox.SendKeys(name);
            taskPage.ageBox.SendKeys(stringAge);
            taskPage.languageCheckbox[0].Click(); //english
            taskPage.genreRadio[0].Click(); //male
            var select = new SelectElement(taskPage.ratingSelect);
            select.SelectByText(selectElementRating);
            taskPage.commentBox.SendKeys(longComment);
            taskPage.sendButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FeedbackCheckTaskPage taskCheckPage = new FeedbackCheckTaskPage(driver);
            taskCheckPage.noButton.Click();
            FeedbackTaskPage taskPage2 = new FeedbackTaskPage(driver);

            //Assert
            Assert.AreEqual(name, taskPage2.nameBox.GetAttribute("value"));
            Assert.AreEqual(stringAge, taskPage2.ageBox.GetAttribute("value"));
            Assert.IsTrue(taskPage2.languageCheckbox[0].Selected, "Expected English checkbox to be selected");
            Assert.IsTrue(taskPage2.genreRadio[0].Selected, "Expected 'male' radio button to be selected");
            var reSelected = new SelectElement(taskPage2.ratingSelect);
            Assert.AreEqual(selectElementRating, reSelected.SelectedOption.Text);
            Assert.AreEqual(longComment, taskPage2.commentBox.GetAttribute("value"));

            //fill the whole form
            //click "Send"
            //click "No"
            //check fields are filled correctly
        }
    }
}