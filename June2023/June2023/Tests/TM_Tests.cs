using June2023.Pages;
using June2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace June2023.Tests
{
    [TestFixture]

    public class TM_Tests : CommonDriver
    {

        [SetUp]

        public void TM_Setup()
        {
            //Open Chrome
            driver = new ChromeDriver();
            Thread.Sleep(1000);

            //Intiliaze and define Login
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            //Initialize and define Home page
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMpage(driver);
        }

        [Test]


        public void CreateTimeRecord()
        {
            //Initialize and define Create Time Obj
            TM_Page createTimeObj = new TM_Page();
            createTimeObj.CreateTimeRecord(driver);

        }


        [Test]

        public void EditTimeRecord()
        {
            //Initialize and define  Edit Time Obj 
            TM_Page editTimeObj = new TM_Page();
            editTimeObj.EditTimeRecord(driver);
        }

        [Test]

        public void DeleteTimeRecord()
        {
            //Initialize and define Delete Time Obj
            TM_Page deleteTimeObj = new TM_Page();
            deleteTimeObj.DeleteTimeRecord(driver);
        }


        [TearDown]

        public void CloseAll()
        {

            driver.Quit();
        }

    }

}