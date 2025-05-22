using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_from_java_to_csharp.Samples
{
    [TestClass]
    public class Sample6Task
    {
        IWebDriver driver;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://acctabootcamp.github.io/site/examples/locators");
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void FindElementByXPath()
        {
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='heading_2']")).Text);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='heading_2' and text()='Heading 2 text']")).Text);

            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test1']//*[@class='test']")).Text);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test1']//*[contains(text(),'Test Text 1')]")).Text);

            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test1']//*[@class='twoTest']")).Text);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test1']//*[contains(text(),'Test Text 2')]")).Text);

            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test3']//*[@class='test']")).Text);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test3']//*[contains(text(),'Test Text 3')]")).Text);

            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test3']//*[contains(text(),'Test Text 4')]")).Text);

            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test2']//*[@class='Test']")).Text);
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='test2']//*[contains(text(),'Test Text 5')]")).Text);

            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='buttonId']")).GetAttribute("value"));
            Console.WriteLine(driver.FindElement(By.XPath("//*[@name='randomButton2']")).GetAttribute("value"));

            //1-2 ways to find text: "Heading 2 text":
            //1-2 ways to find text: "Test Text 1"
            //1-2 ways to find text: "Test Text 2"
            //1-2 ways to find text: "Test Text 3"
            //1-2 ways to find text: "Test Text 4"
            //1-2 ways to find text: "Test Text 5"
            //1-2 ways to find text: "This is also a button"
        }

        [TestMethod]
        public void FindElementByCssName()
        {
            Console.WriteLine(driver.FindElement(By.CssSelector("#heading_2")).Text);
            Console.WriteLine(driver.FindElement(By.CssSelector("h2#heading_2")).Text);

            Console.WriteLine(driver.FindElement(By.CssSelector("#test1 .test")).Text);

            Console.WriteLine(driver.FindElement(By.CssSelector("#test1 .twoTest")).Text);

            Console.WriteLine(driver.FindElement(By.CssSelector("#test3 .test")).Text);

            Console.WriteLine(driver.FindElement(By.CssSelector("#buttonId")).GetAttribute("value"));
            Console.WriteLine(driver.FindElement(By.CssSelector("input[name='randomButton2']")).GetAttribute("value"));

            //1-2 ways to find text: "Heading 2 text"
            //1-2 ways to find text: "Test Text 1"
            //1-2 ways to find text: "Test Text 2"
            //1-2 ways to find text: "Test Text 3"
            //1-2 ways to find text: "This is also a button"
        }
    }
}
