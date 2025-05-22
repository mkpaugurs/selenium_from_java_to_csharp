using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium_from_java_to_csharp.Samples
{
    [TestClass]
    public class Sample7Task
    {
        IWebDriver driver;

        [TestInitialize]
        public void StartingTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://acctabootcamp.github.io/site/examples/actions");
        }

        [TestCleanup]
        public void EndingTests()
        {
            driver.Quit();
        }

        [TestMethod]
        public void SelectCheckBox()
        {
            Assert.IsFalse(driver.FindElement(By.Id("vfb-6-0")).Selected);
            Assert.IsFalse(driver.FindElement(By.Id("vfb-6-1")).Selected);
            Assert.IsFalse(driver.FindElement(By.Id("vfb-6-2")).Selected);

            driver.FindElement(By.Id("vfb-6-1")).Click();

            Assert.IsFalse(driver.FindElement(By.Id("vfb-6-0")).Selected);
            Assert.IsTrue(driver.FindElement(By.Id("vfb-6-1")).Selected);
            Assert.IsFalse(driver.FindElement(By.Id("vfb-6-2")).Selected);

            driver.FindElement(By.Id("vfb-6-2")).Click();

            driver.FindElement(By.Id("result_button_checkbox")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("result_checkbox")).Displayed);
            Assert.AreEqual("You selected value(s): Option 2, Option 3",
                driver.FindElement(By.Id("result_checkbox")).Text);

            //check that none of the checkboxes are ticked
            //tick  "Option 2"
            //check that "Option 1" and "Option 3" are not ticked, but "Option 2" is ticked
            //tick  "Option 3"
            //click result
            //check that text 'You selected value(s): Option 2, Option 3' is being displayed
        }

        [TestMethod]
        public void SelectRadioButton()
        {
            IList<IWebElement> radioList = driver.FindElements(By.CssSelector("[name='vfb-7']"));


            foreach (var radio in radioList)
            {
                Assert.IsFalse(radio.Selected);
            }

            radioList[2].Click();

            Assert.IsFalse(radioList[0].Selected);
            Assert.IsFalse(radioList[1].Selected);
            Assert.IsTrue(radioList[2].Selected);

            radioList[0].Click();

            Assert.IsTrue(radioList[0].Selected);
            Assert.IsFalse(radioList[1].Selected);
            Assert.IsFalse(radioList[2].Selected);

            driver.FindElement(By.Id("result_button_ratio")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("result_radio")).Displayed);
            Assert.AreEqual("You selected option: Option 1",
                driver.FindElement(By.Id("result_radio")).Text);

            //check that none of the radio are selected
            //select  "Option 3"
            //check that "Option 1" and "Option 2' are not select, but "Option 3" is selected
            //select  "Option 1"
            //check that "Option 2" and "Option 3' are not select, but "Option 1" is selected
            //click result
            //check that 'You selected option: Option 1' text is being displayed
        }

        [TestMethod]
        public void SelectOption()
        {
            SelectElement selectElement = new(driver.FindElement(By.Id("vfb-12")));

            selectElement.SelectByText("Option 3");
            Assert.AreEqual("Option 3", selectElement.SelectedOption.Text);

            selectElement.SelectByText("Option 2");
            Assert.AreEqual("Option 2", selectElement.SelectedOption.Text);

            driver.FindElement(By.Id("result_button_select")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("result_select")).Displayed);
            Assert.AreEqual("You selected option: Option 2", driver.FindElement(By.Id("result_select")).Text);

            //select "Option 3" in Select
            //check that selected option is "Option 3"
            //select "Option 2" in Select
            //check that selected option is "Option 2"
            //click result
            //check that 'You selected option: Option 2' text is being displayed
        }
    }
}
