using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2023.Pages
{
    public class TM_Page
    {

        public void CreateTimeRecord(IWebDriver driver)
        {
     
            //Click on Create New 
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            Thread.Sleep(1500);

            //Select  Time Dropdown Option//
            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            dropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Enter Code
            IWebElement codeText = driver.FindElement(By.Id("Code"));
            codeText.SendKeys("001");

            //Enter Description
            IWebElement descText = driver.FindElement(By.Id("Description"));
            descText.SendKeys("09:00 AM ");

            //Enter Price (Due to Input tag overlapping in Inspecting Element, price text must be clicked first for the driver to be able to be in edit mode)

            IWebElement pricetag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            pricetag.Click();

            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("80");


            //Click Save

            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            saveButton.Click();

            //Check if record entered is saved


            //check from the last record of table to see the recent added data
            Thread.Sleep(1200);

            IWebElement lastrecbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastrecbutton.Click();


            Thread.Sleep(3000);
            //use the last() to get the last transation row for the newly added record
            IWebElement newcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            if (newcode.Text == "001")

            {
                Console.WriteLine("Record succesfully added.");
            }

            else
            {
                Console.WriteLine("Record failed to add.");
            }

        }

        public void CreateMaterialRecord(IWebDriver driver)
        {

            //Click on Create New 
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            Thread.Sleep(1500);
            //Select Material Dropdown Option//
            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            dropdown.Click();
            Thread.Sleep(1500);

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
            materialOption.Click();
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            // Edit time record

            //Go to last record
            IWebElement gotoLastRec = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotoLastRec.Click();

            //Click on Edit on last row
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[5]/td[5]/a[1]"));

            editButton.Click();


            //Select  Time Dropdown Option//
            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            dropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();


            //Enter Code
            IWebElement codeText = driver.FindElement(By.Id("Code"));
            codeText.Clear();
            codeText.SendKeys("001_edited");

            //Enter Description
            IWebElement descText = driver.FindElement(By.Id("Description"));
            descText.Clear();
            descText.SendKeys("Material1_edited ");

            //Enter Price (Due to Input tag overlapping in Inspecting Element, price text must be clicked first for the driver to be able to be in edit mode)

            IWebElement pricetag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            pricetag.Click();

            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys(Keys.Control + "a");
            price.SendKeys("800");


            //Click Save

            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            saveButton.Click();

            //Check if edit record took effect


            //check from the last record of table to see the recent added data
            Thread.Sleep(1200);

            IWebElement lastrecbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastrecbutton.Click();


            Thread.Sleep(3000);

            IWebElement editedcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            if (editedcode.Text == "001_edited")

            {
                Console.WriteLine("Record succesfully modified.");
            }

            else
            {
                Console.WriteLine("Record failed to modify.");
            }
        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            // Delete time record

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[4]/td[last()]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(1500);
            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            //Check if the record  deleted by going  to last record 

            IWebElement gotoLastRec = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotoLastRec.Click();
            Thread.Sleep(1200);


            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (deletedCode.Text == "001_edited")
            {
                
                Console.WriteLine("Deletion did not take effect.");
            }

            else
            {
                Console.WriteLine("Record has been deleted succesfully");

            }


       
           
        }
    }
}
