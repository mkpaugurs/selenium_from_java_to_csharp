using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium_from_java_to_csharp.Samples
{
    [TestClass]
    public class Sample9Task
    {
        private IWebDriver driver;
        private IWebElement greenButton;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://kristinek.github.io/site/examples/loading_color");
            greenButton = driver.FindElement(By.Id("start_green"));
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void LoadGreenSleep()
        {
            greenButton.Click();
            Assert.IsFalse(greenButton.Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("loading_green")).Displayed);
            Assert.AreEqual("Loading green...", driver.FindElement(By.Id("loading_green")).Text);

            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.Id("finish_green")).Displayed);

            Assert.IsFalse(greenButton.Displayed);
            Assert.IsFalse(driver.FindElement(By.Id("loading_green")).Displayed);
            Assert.AreEqual("Green Loaded", driver.FindElement(By.Id("finish_green")).Text);

            //* 1) click on start loading green button
            //* 2) check that button does not appear,
            //* but loading text is seen instead   "Loading green..."
            //* 3) check that both button
            //* and loading text is not seen,
            //* success is seen instead "Green Loaded"
        }

        [TestMethod]
        public void LoadGreenImplicit()
        {
            greenButton.Click();
            Assert.IsFalse(greenButton.Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("loading_green")).Displayed);
            Assert.AreEqual("Loading green...", driver.FindElement(By.Id("loading_green")).Text);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(driver.FindElement(By.Id("finish_green")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            Assert.IsFalse(greenButton.Displayed);
            Assert.IsFalse(driver.FindElement(By.Id("loading_green")).Displayed);
            Assert.AreEqual("Green Loaded", driver.FindElement(By.Id("finish_green")).Text);

            //* 1) click on start loading green button
            //* 2) check that button does not appear,
            //* but loading text is seen instead   "Loading green..."
            //* 3) check that both button
            //* and loading text is not seen,
            //* success is seen instead "Green Loaded"
        }

        [TestMethod]
        public void LoadGreenExplicitWait()
        {
            greenButton.Click();
            Assert.IsFalse(greenButton.Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("loading_green")).Displayed);
            Assert.AreEqual("Loading green...", driver.FindElement(By.Id("loading_green")).Text);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => driver.FindElement(By.Id("finish_green")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("finish_green")).Displayed);

            Assert.IsFalse(greenButton.Displayed);
            Assert.IsFalse(driver.FindElement(By.Id("loading_green")).Displayed);
            Assert.AreEqual("Green Loaded", driver.FindElement(By.Id("finish_green")).Text);

            //* 1) click on start loading green button
            //* 2) check that button does not appear,
            //* but loading text is seen instead   "Loading green..."
            //* 3) check that both button
            //* and loading text is not seen,
            //* success is seen instead "Green Loaded"
        }

    }
}
