
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
       //Open Chrome Browser
       IWebDriver driver = new ChromeDriver();
        Thread.Sleep(1000);
        driver.Manage().Window.Maximize();

        //launch turnup portal

        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        Thread.Sleep(1500);


        //identify username and enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        //identify passsword and enter valid password
        IWebElement passwordtext = driver.FindElement(By.Id("Password"));
        passwordtext.SendKeys("123123");

        //Identify LogIn Button and Click on it

        IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginbutton.Click();
        Thread.Sleep(2000);

        //Check that user loggin to homepage successfully

        // ******LOGIN HAPPY PATH *******//
        IWebElement helloharitext = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));


        if (helloharitext.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in succesfully");
        }

        else
        {
            Console.WriteLine("User log-in failed.");
        }


        //******LOGIN NEGATIVE PATH****//

        //IWebElement invalidlogintext = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[1]/ul/li"));

        //if (invalidlogintext.Text == "Invalid username or password.")
        //{
        //    Console.WriteLine("Log in unsuccesful due to invalid username or password");
        //}

        //else

        //{
        //    Console.WriteLine("Login Test result invalid ");
        //}



        //******CREATE NEW RECORD FOR TIME AND MATERIAL ******//

        //Navigate to  Time and Materials

        IWebElement Administrationselect = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        Administrationselect.Click();
        Thread.Sleep(1500);

        IWebElement TimeandMaterials = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        TimeandMaterials.Click();
        Thread.Sleep(1500);
        //Click on Create New 

        IWebElement CreateNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        CreateNewButton.Click();
        Thread.Sleep(1500);
        //Select  Time Record

        IWebElement Dropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
        Dropdown.Click();

        IWebElement TimeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        TimeOption.Click();

        //Enter Code
        IWebElement CodeText = driver.FindElement(By.Id("Code"));
        CodeText.SendKeys("001");

        //Enter Description
        IWebElement DescText = driver.FindElement(By.Id("Description"));
        DescText.SendKeys("09:00 AM ");

        //Enter Price (Due to Input tag overlapping in Inspecting Element, price text must be clicked first for the driver to be able to be in edit mode)

        IWebElement Pricetag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        Pricetag.Click();

        IWebElement Price = driver.FindElement(By.Id("Price"));
        Price.SendKeys("80");


        //Click Save

        IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
        SaveButton.Click();

        //Check if record entered is saved


        //check from the last record of table to see the recent added data
        Thread.Sleep(1200);

        IWebElement lastrecbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastrecbutton.Click();


        Thread.Sleep(3000);
        //use the last() to get the last transation row for the newly added record
        IWebElement newcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


        if (newcode.Text =="001")

        {
            Console.WriteLine("Record succesfully added."); 
        }

        else
        {
            Console.WriteLine("Record failed to add.");
        }





    }
}