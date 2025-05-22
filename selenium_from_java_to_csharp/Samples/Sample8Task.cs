using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_from_java_to_csharp.Samples
{
    [TestClass]
    public class Sample8Task
    {
        IWebDriver driver;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://acctabootcamp.github.io/site/examples/po");
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void StyleChecks()
        {
            IWebElement top1 = driver.FindElement(By.ClassName("w3-pale-red"));
            IWebElement top2 = driver.FindElement(By.ClassName("w3-pale-yellow"));
            IWebElement h1 = driver.FindElement(By.XPath("//h1[@class='w3-jumbo']"));

            Assert.AreEqual("rgba(255, 221, 221, 1)", top1.GetCssValue("background-color"), "Pale red background color mismatch");
            Assert.AreEqual("rgba(255, 255, 204, 1)",top2.GetCssValue("background-color"), "Pale yellow background color mismatch");
            Assert.AreEqual("64px", h1.GetCssValue("font-size"), "H1 font size mismatch");
            //check the background of top 2 sections
            //rgba(255, 221, 221, 1)
            //check h1 element font-size 64px
        }
    }
}
