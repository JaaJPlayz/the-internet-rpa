using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

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
}



automateCheckboxes();

Console.WriteLine("Press enter to exit. . .");
Console.ReadLine();
