
using June2023.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
       //Open Chrome Browser
       IWebDriver driver = new ChromeDriver();
        Thread.Sleep(1000);
        driver.Manage().Window.Maximize();

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginSteps(driver);

        // Home page object intialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMpage(driver);

        // TM page object initialization and definition
        TM_Page tmPageObj = new TM_Page();
        tmPageObj.CreateTimeRecord(driver);

        // Edit Time record
        tmPageObj.EditTimeRecord(driver);

        // Delete Time record
        tmPageObj.DeleteTimeRecord(driver);



    }
}