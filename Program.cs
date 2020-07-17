using System;
using OpenQA.Selenium.Chrome;
using System.IO;
using OpenQA.Selenium;
using System.Threading;


//resolved all non-selenium syntax errors for Java > C#

namespace SeleniumSL_CS
{
    class Program
    {
        static string dataLog = "";

        //  return current date/time in readable format
        public static string GetTime()
        {
            return DateTime.Now.ToString("MMddyyyy hh:mm:ss");
        }

        public static string NameByDate()
        {
            return DateTime.Now.ToString("MMddyyyy");
        }

        //  append string to log
        public static void WriteToLog(string data)
        {
            dataLog += ("\n" + data);
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("++ Test initialized at " + GetTime());

            //NOTE - MUST INPUT LOCAL LOCATION OF CHROMEDRIVER DIRECTORY
            IWebDriver driver = new ChromeDriver("C:\\Users\\Patrick\\source\\repos\\SeleniumSL_CS\\SeleniumSL_CS");

            // add 30 sec implicit wait for variable connection speeds
            // driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
            //  execute test methods in sequence
            SearchGoogle(driver);
            LoginTestArea(driver);
            //  testHomeModule(driver);
            // Thread.Sleep(3000);
            TestChallenges(driver);
            // testPublish(driver);
            TestFeed(driver);
            TestReporting(driver);
            //  close the browser
            // Thread.Sleep(5000);
            driver.Close();
            WriteToLog("++ Test completed at " + GetTime());
            Console.WriteLine(dataLog);
        }

        //  initialize a browser to google.com and search for "socialladder". click the
        //  link to our website
        public static void SearchGoogle(IWebDriver wd)
        {
            //  open browser with google
            wd.Navigate().GoToUrl(@"http://google.com");
            WriteToLog("Browser loaded to www.google.com.");
            try
            {                
                IWebElement searchField = wd.FindElement(By.XPath("/html/body/div/div[3]/form/div[2]/div[1]/div[1]/div/div[2]/input"));
                searchField.Click();
                searchField.SendKeys("socialladder");
                Thread.Sleep(2000);
                searchField.SendKeys(Keys.Enter);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WriteToLog("Searching Google for \\\"socialladder\\\".");
            try
            {
                Thread.Sleep(1000);
                IWebElement slSiteGoogle = wd.FindElement(By.PartialLinkText("SocialLadder |"));
                slSiteGoogle.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WriteToLog(">> Site located on Google - PASS");
        }

        //  starting from socialladder.rkiapps.com, click login button and use test
        //  credentials to access area
        public static void LoginTestArea(IWebDriver wd)
        {
            WriteToLog(">> SL website loaded - PASS");
            IWebElement slSiteLogin = wd.FindElement(By.XPath("/html/body/div[1]/nav/div[1]/div[2]/ul/li[6]/a"));
            slSiteLogin.Click();
            WriteToLog(">> SL login page loaded - PASS");
            Thread.Sleep(2000);
            IWebElement emailInput = wd.FindElement(By.Id("input_0"));
            emailInput.Click();
            // manually input username
            emailInput.SendKeys("onebulletboy@socialladderapp.com");
            Thread.Sleep(500);
            IWebElement passwordInput = wd.FindElement(By.Id("input_1"));
            Thread.Sleep(500);
            passwordInput.Click();
            // manually input password
            passwordInput.SendKeys("social33!");
            WriteToLog("Credentials entered.");
            IWebElement loginButton = wd.FindElement(By.XPath("/html/body/div/md-content[1]/button"));
            loginButton.Click();
        }

        //  run predetermined regression tests on the home module
        public static void TestHomeModule(IWebDriver wd)
        {
            //  insert code to verify certain expected values on home tab
        }

        public static void TestChallenges(IWebDriver wd)
        {
            try
            {
                Thread.Sleep(3000);
                IWebElement challengeBtn = wd.FindElement(By.XPath("/html/body/main-component/div/menu-component/md-sidenav/nav/a[2]/span"));
                challengeBtn.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement createButton = wd.FindElement(By.XPath("/html/body/main-component/div/div/div/div/section/div[1]/button"));
                createButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement surveyButton = wd.FindElement(By.XPath(("/html/body/div[3]/md-dialog/div/div/section[2]/" + "section[2]/div[1]/section[1]/div/section[2]/section/div[2]")));
                surveyButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                IWebElement surveyName = wd.FindElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[2]/section/div[3]" + "/md-input-container/div[1]/textarea"))));
                surveyName.Click();
                surveyName.SendKeys(("Regression Test " + NameByDate()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IWebElement option1Input = wd.FindElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[5]/section[6]/div[2]" + "/div/div/div/ul[1]/li/ul/li/md-input-container/div[1]/textarea"))));
            option1Input.Click();
            option1Input.SendKeys(NameByDate());
            IWebElement option2Input = wd.FindElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[5]/section[6]/div[2]/div/div/div/ul[2]/li/ul/li" + "/md-input-container/div[1]/textarea"))));
            option2Input.Click();
            option2Input.SendKeys("Incorrect");
            try
            {
                Thread.Sleep(3000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(2000);
                IWebElement challengeDescription = wd.FindElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[6]" + "/section/div[3]/div/md-input-container/div[1]/textarea"))));
                challengeDescription.Click();
                challengeDescription.SendKeys(("AUTO GENERATED CHALLENGE FOR REGRESSION TEST " + NameByDate()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IWebElement dropDown = wd.FindElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[7]/div[2]/div[1]/div[2]" + "/md-input-container/md-select/md-select-value/span[1]/div"))));
            dropDown.Click();
            IWebElement allUsers = wd.FindElement(By.XPath("/html/body/div[8]/md-select-menu/md-content/md-option[2]"));
            allUsers.Click();
            try
            {
                Thread.Sleep(1000);
                IWebElement nextButton = wd.FindElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                IWebElement savePublish = wd.FindElement(By.XPath("/html/body/div[3]/md-dialog/div/div/section[2]/section[2]/div[8]/section[2]/div[1]"));
                savePublish.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement submitBtn = wd.FindElement(By.XPath("/html/body/div[3]/md-dialog/div/div/section[3]/div[3]/button/span"));
                submitBtn.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //         IWebElement exitChallenge = wd.FindElement(By.XPath("/html/body/div[3]/md-dialog/div/div/section[1]/span/i"));
            //         exitChallenge.Click();
            //         
            //         try{
            //             //Thread.Sleep(3000);     
            //             IWebElement exitYes = wd.FindElement(By.XPath("/html/body/div[9]/md-dialog/md-dialog-actions/button[2]"));
            //             exitYes.Click();
            //             } catch(Exception e){
            //             Console.WriteLine("Exception caught: \n"); e.printStackTrace();}
        }

        public static void TestFeed(IWebDriver wd)
        {
            try
            {
                Thread.Sleep(3000);
                IWebElement feed = wd.FindElement(By.XPath("/html/body/main-component/div/menu-component/md-sidenav/nav/a[7]"));
                feed.Click();
                IWebElement createButton = wd.FindElement(By.XPath("/html/body/main-component/div/div/div/div/div[1]/div[1]/button"));
                createButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement feedName = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[1]/input"));
                feedName.Click();
                feedName.SendKeys(("Regression Test " + NameByDate()));
                IWebElement textOverlay = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[2]/input"));
                textOverlay.Click();
                textOverlay.SendKeys(NameByDate());
                IWebElement notificationText = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[3]/input"));
                notificationText.Click();
                notificationText.SendKeys(NameByDate());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IWebElement dropDown = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[7]/div/md-select"));
            dropDown.Click();
            try
            {
                Thread.Sleep(3000);
                IWebElement challengeOption = wd.FindElement(By.XPath("/html/body/div[8]/md-select-menu/md-content/md-option[3]"));
                challengeOption.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IWebElement dropDown2 = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[8]/md-select"));
            dropDown2.Click();
            try
            {
                Thread.Sleep(3000);
                IWebElement allUsers = wd.FindElement(By.XPath("/html/body/div[9]/md-select-menu/md-content/md-option[2]"));
                allUsers.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IWebElement directChallenge = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[7]/div/md-select[2]"));
            directChallenge.Click();
            try
            {
                Thread.Sleep(3000);
                IWebElement releaseTest = wd.FindElement(By.XPath("/html/body/div[10]/md-select-menu/md-content/md-option[1]"));
                releaseTest.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //         IWebElement link = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[7]/div/input"));
            //         link.Click();
            //         link.SendKeys("https://socialladder.rkiapps.com/portal/#/challenges");
            IWebElement save = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[3]/button[1]"));
            save.Click();
            try
            {
                Thread.Sleep(3000);
                IWebElement savePublish = wd.FindElement(By.XPath("/html/body/div[7]/md-dialog/section/div[3]/button[2]"));
                savePublish.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void TestReporting(IWebDriver wd)
        {
            try
            {
                Thread.Sleep(3000);
                IWebElement testReport = wd.FindElement(By.XPath("/html/body/main-component/div/menu-component/md-sidenav/nav/a[4]"));
                testReport.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement selectReport = wd.FindElement(By.XPath("/html/body/main-component/div/div/div/div/div[1]/div[1]/md-input-container/md-select"));
                selectReport.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement option1 = wd.FindElement(By.XPath("/html/body/div[7]/md-select-menu/md-content/md-option[1]"));
                option1.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement save = wd.FindElement(By.XPath(("/html/body/main-component/div/div/div/div/div[1]/div[2]" + "/section[1]/button")));
                save.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                IWebElement reportName = wd.FindElement(By.XPath(("/html/body/div[8]/md-dialog/div/" + "md-content/md-input-container[1]/div[1]/textarea")));
                reportName.Click();
                reportName.SendKeys(("Regression Test " + NameByDate()));
                IWebElement reportDesc = wd.FindElement(By.XPath(("/html/body/div[8]/md-dialog/div/" + "md-content/md-input-container[2]/div[1]/textarea")));
                reportDesc.Click();
                reportDesc.SendKeys(("Regression Test " + NameByDate()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            IWebElement saveBtn = wd.FindElement(By.XPath(("/html/body/div[8]" + "/md-dialog/div/md-dialog-actions/button[1]")));
            saveBtn.Click();
        }
    }
}
