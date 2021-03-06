//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using AppiumSample.helpers;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Android;
//using OpenQA.Selenium.Appium.Enums;
//using OpenQA.Selenium.Appium.MultiTouch;
//using OpenQA.Selenium.Remote;

//namespace AppiumSample
//{
//    [TestFixture()]
//    public class AndroidSaucelabTest
//    {
//        private RemoteWebDriver driver;
//        private bool allPassed = true;

//        [TestFixtureSetUp]
//        public void BeforeAll()
//        {

//            System.Console.WriteLine("Starting Sauce lab appium ...");
            
//            string appURL = "https://adminportal.keynote.com/app/537904.apk";// Environment.GetEnvironmentVariable("APPIUM_APP_URL");//, EnvironmentVariableTarget.Machine);

//            if (string.IsNullOrEmpty(appURL))
//            {
//                System.Console.WriteLine("APPIUM_APP_PATH -->" + Environment.GetEnvironmentVariable("APPIUM_APP_PATH"));
//                appURL = KeynoteHelper.GetApplicationURL("Remainder", "1.1", Environment.GetEnvironmentVariable("APPIUM_APP_PATH"));//, EnvironmentVariableTarget.Machine));
//            }
//            else
//                System.Console.WriteLine("APPIUM_APP_URL -->" + appURL);

//            //set the desired capabilities
//            DesiredCapabilities capabilities = new DesiredCapabilities();
//            capabilities.SetCapability(CapabilityType.BrowserName, "");
//            //capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.4.0.0");
//            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "4.4");
//            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
//            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Google Nexus 7 HD Emulator");

//            //Saucelab capabilities
//            capabilities.SetCapability("username", "moorthisarav"); // supply sauce labs username
//            capabilities.SetCapability("accessKey", "946de7cf-599c-4d3f-8316-2fe5c5da14cf");  // supply sauce labs account key

//            //Application download URI
//            //This can be any public url to download the app, MUST end with file type (*.apk or *.ipa)
//            //Please don not acquire device from website during complete automation mode, because script will acquire the device
//            capabilities.SetCapability(MobileCapabilityType.App, appURL);

//            Uri serverUri = new Uri("http://moorthisarav:946de7cf-599c-4d3f-8316-2fe5c5da14cf@ondemand.saucelabs.com/wd/hub");

//            //User following code for complete automation (acquire device and get appium Uri)
//            //serverUri = KeynoteHelper.GetAppiumUrl(9337);



//            //use following test for manual testing
//            //to use this option
//            // 1. Login to http://dademo112.deviceanywhere.com/
//            // 2. Acquire device
//            // 3. Tools --> Appium --> Start appium 
//            // 4. copy the Uri from the browser and replace following url
//            //serverUri = new Uri("https://dademo112.deviceanywhere.com/appium/592fab14-2292-4353-b9ea-2585b06862ff/wd/hub/");

//            if (serverUri != null)
//            {
//                try
//                {


//                    //driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
//                    driver = new RemoteWebDriver(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
//                    driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
//                }
//                catch (Exception e)
//                {
//                    System.Console.WriteLine(e.Message);
//                }
//            }
//        }

//        [TestFixtureTearDown]
//        public void AfterAll()
//        {
//            try
//            {
                
//            }
//            finally
//            {
//                driver.Quit();
//            }
//        }

//        [TearDown]
//        public void AfterEach()
//        {
//            allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
//        }

//        //private void performTouch(AndroidElement element)
//        //{
//        //    if (element != null)
//        //    {
//        //        TouchAction a1 = new TouchAction(driver);
//        //        a1
//        //          .Press(element, 100, 100)
//        //          .Wait(1000)
//        //          .Release();
//        //        a1.Perform();
//        //    }
//        //}

//        //public void ButtonTouch(String text)
//        //{
//        //    performTouch(driver.FindElementByName(text));
//        //}

//        [Test]
//        public void A_ButtonTouch()
//        {
//            if (driver != null)
//            {
//                Thread.Sleep(2000);
//                //ButtonTouch("Add New Expense");
//                driver.FindElementByName("Add New Expense").Click();
//                Assert.Pass("Passed");
//            }
//            else
//                Assert.Fail("Android driver not Initialized");
//        }

//        [Test]
//        public void B_SendKeys()
//        {
//            if (driver != null)
//            {
//                Thread.Sleep(2000);
//                driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.expensemanager:id/expenseAmountInput']")).SendKeys("80");
//                Thread.Sleep(2000);
//                driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.expensemanager:id/payee']")).SendKeys("BOFA");
//                //driver.Navigate().Back();
//                Assert.Pass("Passed");
//            }
//            else
//                Assert.Fail("Android driver not Initialized");
//        }

//        //[Test]
//        //public void C_Ok()
//        //{
//        //    if (driver != null)
//        //    {
//        //        Thread.Sleep(2000);
//        //        performTouch(driver.FindElement(By.Name("OK")));
//        //        Assert.Pass("Passed");
//        //    }
//        //    else
//        //        Assert.Fail("Android driver not Initialized");
//        //}

//        //[Test]
//        //public void D_Fail()
//        //{
//        //    if (driver != null)
//        //    {
//        //        Thread.Sleep(2000);
//        //        performTouch(driver.FindElement(By.Name("New Report")));
//        //        Assert.Pass("Passed");
//        //    }
//        //    else
//        //        Assert.Fail("Android driver not Initialized");
//        //}


//        //[Test]
//        //public void FindElementTestCase()
//        //{
//        //    if (driver != null)
//        //    {
//        //        try
//        //        {
//        //            for (int i = 0; i < 1; i++)
//        //            {
//        //                Thread.Sleep(2000);
//        //                performTouch(driver.FindElementByName("Add New Expense"));

//        //                          Thread.Sleep(3000);
//        //                          driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.expensemanager:id/expenseAmountInput']")).SendKeys("80");
//        //                          Thread.Sleep(2000);
//        //                /*
//        //                          driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.expensemanager:id/payee']")).SendKeys("BOFA");
//        //                          performTouch(driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.expensemanager:id/editCategory']")));
//        //                          performTouch(driver.FindElement(By.Name("OK")));
//        //                          performTouch(driver.FindElement(By.Name("Loans")));
//        //                          performTouch(driver.FindElement(By.Name("Edit")));
//        //                          performTouch(driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.expensemanager:id/editPaymentMethod']")));
//        //                          performTouch(driver.FindElement(By.Name("Credit Card")));
//        //                          performTouch(driver.FindElement(By.Name("OK")));
//        //                driver.Navigate().Back();
//        //               */
//        //                Assert.Pass("Test Passed");
//        //            }
//        //        }

//        //        catch (Exception e)
//        //        {
//        //            Assert.Fail("Test Failed " + e.ToString());

//        //        }
//        //    }
//        //}
//    }
//}
