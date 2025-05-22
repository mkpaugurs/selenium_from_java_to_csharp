using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using selenium_from_java_to_csharp.Pages;

namespace selenium_from_java_to_csharp.Samples
{
    [TestClass]
    public class Sample10Task
    {
        WebDriver driver;
        ColorSamplePage colorPage;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://kristinek.github.io/site/examples/loading_color");
            colorPage = new ColorSamplePage(driver);
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void LoadGreenSleep()
        {
            colorPage.ClickStartLoadingGreen();
            colorPage.AssertLoadingGreen();
            colorPage.AssertFinishGreen();

            //Use page object ColorSamplePage
            //* 1) click on start loading green button
            //* 2) check that button does not appear,
            //* but loading text is seen instead   "Loading green..."
            //* 3) check that both button
            //* and loading text is not seen,
            //* success is seen instead "Green Loaded"
        }
    }
}
