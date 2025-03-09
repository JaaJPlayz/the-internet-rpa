using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using var driver = new ChromeDriver();

string baseUrl = "http://the-internet.herokuapp.com/";
driver.Url = baseUrl;

void automateCheckboxes()
{
    var checkboxLink = driver.FindElement(By.XPath("/html/body/div[2]/div/ul/li[6]/a"));
    checkboxLink.Click();

    var upperCheckbox = driver.FindElement(By.XPath("//*[@id=\"checkboxes\"]/input[1]"));
    var lowerCheckbox = driver.FindElement(By.XPath("//*[@id=\"checkboxes\"]/input[2]"));

    for (int i = 0; i < 100; i++)
    {
        upperCheckbox.Click();
        lowerCheckbox.Click();
    }

    driver.Navigate().GoToUrl(baseUrl);
}

void automateContextMenu()
{
    var contextMenuLink = driver.FindElement(By.XPath("/html/body/div[2]/div/ul/li[7]/a"));
    contextMenuLink.Click();

    var box = driver.FindElement(By.XPath("//*[@id=\"hot-spot\"]"));

    // Right click the box element
    Actions action = new Actions(driver);
    action.ContextClick(box).Perform();

    var alert = driver.SwitchTo().Alert();
    alert.Accept();

    Thread.Sleep(1000);

    driver.Navigate().GoToUrl(baseUrl);
}



// automateCheckboxes();
automateContextMenu();


Console.WriteLine("Press enter to exit. . .");
Console.ReadLine();
