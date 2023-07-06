using June2023.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2023.Pages
{
    public class HomePage
    {

        public void GoToTMpage(IWebDriver driver)
        {
           //Navigate to  Time and Materials
        IWebElement administrationSelect = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationSelect.Click();
        Wait.WaitToBeClickable(driver,"XPath","/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);

        IWebElement time_materialbutton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
         time_materialbutton.Click();
        Thread.Sleep(1500);
        }
    }
}
