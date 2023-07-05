using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2023.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
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

            // ********************LOGIN HAPPY PATH ********************//
            IWebElement helloHariText = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));


            if (helloHariText.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in succesfully");
            }

            else
            {
                Console.WriteLine("User log-in failed.");
            }


            //********************LOGIN NEGATIVE PATH********************//

            //IWebElement invalidlogintext = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[1]/ul/li"));

            //if (invalidlogintext.Text == "Invalid username or password.")
            //{
            //    Console.WriteLine("Log in unsuccesful due to invalid username or password");
            //}

            //else

            //{
            //    Console.WriteLine("Login Test succesful ");
            //}

        }
    }
}
