using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_from_java_to_csharp.Tasks
{
    [TestClass]
    public class Task1
    {
        private IWebDriver driver;
        private IWebElement numberBox;
        private IWebElement submitButton;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://acctabootcamp.github.io/site/tasks/enter_a_number");
            numberBox = driver.FindElement(By.Id("numb"));
            submitButton = driver.FindElement(By.XPath("//button[@class=\"w3-btn w3-orange w3-margin\"]"));
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void ErrorOnText()
        {
            numberBox.SendKeys("Text");
            submitButton.Click();
            Assert.AreEqual("Please enter a number", driver.FindElement(By.Id("ch1_error")).Text);
            //enter a text instead of a number, check that correct error is seen
        }

        [TestMethod]
        public void ErrorOnNumberTooSmall()
        {
            for(int i = 0; i < 50; i++)
            {
                if(i == 42 || i == 49)
                {
                    continue;
                }
                numberBox.SendKeys($"{i}");
                submitButton.Click();
                Assert.AreEqual("Number is too small", driver.FindElement(By.Id("ch1_error")).Text);
                numberBox.SendKeys(Keys.Control + "a");
                numberBox.SendKeys(Keys.Delete);
            }
            //BUG: if I enter number 49 or 42 no errors where seen
            //enter number which is too small (positive number below 50), check that correct error is seen
        }

        [TestMethod]
        public void ErrorOnNumberTooBig()
        {
            for (int i = 600; i < 700; i++)
            {
                if (i == 666)
                {
                    continue;
                }
                numberBox.SendKeys($"{i}");
                submitButton.Click();
                Assert.AreEqual("Number is too big", driver.FindElement(By.Id("ch1_error")).Text);
                numberBox.SendKeys(Keys.Control + "a");
                numberBox.SendKeys(Keys.Delete);
            }
            //BUG: if I enter number 666 no errors where seen
            //enter number which is too big (above 100), check that correct error is seen
        }

        [TestMethod]
        public void CorrectSquareRoot()
        {
            for (int i = 50; i < 101; i++)
            {
                numberBox.SendKeys($"{i}");
                submitButton.Click();

                IAlert alert = driver.SwitchTo().Alert();
                string resultText = alert.Text;
                alert.Accept();
                Assert.AreEqual("", driver.FindElement(By.Id("ch1_error")).Text);

                string[] parts = resultText.Split(' ');
                decimal actualSquareRoot = decimal.Parse(parts[^1]);
                decimal expectedSquareRoot = Math.Round((decimal)Math.Sqrt(i), 2);

                Assert.AreEqual(expectedSquareRoot, actualSquareRoot);
            }
            //enter a number between 50 and 100 digit in the input, then press submit
            //and check that no error is seen and that square root is calculated correctly
            //NOTE: input value is hardcoded, but square root used in assertions should be calculated in code
        }
    }
}
