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

void automateDragAndDrop()
{
    var dragAndDropLink = driver.FindElement(By.XPath("/html/body/div[2]/div/ul/li[10]/a"));
    dragAndDropLink.Click();

    var source = driver.FindElement(By.Id("column-a"));
    var target = driver.FindElement(By.Id("column-b"));

    Actions action = new Actions(driver);
    action.DragAndDrop(source, target).Perform();

    driver.Navigate().GoToUrl(baseUrl);
}

void automateDropdown()
{
    var dropdownLink = driver.FindElement(By.XPath("/html/body/div[2]/div/ul/li[11]/a"));
    dropdownLink.Click();

    var dropdown = driver.FindElement(By.Id("dropdown"));
    dropdown.Click();

    var option = driver.FindElement(By.XPath("/html/body/div[2]/div/div/select/option[2]"));
    option.Click();

    driver.Navigate().GoToUrl(baseUrl);
}

void applicationMenu()
{
    int option = 0;

    while (option != 5)
    {
        // Create a menu with the options for automation
        string[] options = { "Automate Checkboxes", "Automate Context Menu", "Automate Drag and Drop", "Automate Dropdown", "Exit" };

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                automateCheckboxes();
                break;
            case 2:
                automateContextMenu();
                break;
            case 3:
                automateDragAndDrop();
                break;
            case 4:
                automateDropdown();
                break;
            case 5:
                driver.Close();
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}

applicationMenu();
