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

        static string currentDirectory = Directory.GetCurrentDirectory();

        // NOTE - CONFIGURE BEFORE USE!! MAC = 1, PC = 2
        static int userNum = 1;

        //  return current date/time in readable format
        public static string getTime()
        {
            return DateTime.Now.ToString("yyyyMMdd hh:mm:ss");
        }

        public static string nameByDate()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        //  append string to log
        public static void writeToLog(string data)
        {
            dataLog = (dataLog + ("\n" + data));
        }

        public static void main(string[] args)
        {
            Console.WriteLine("++ Test initialized at " + getTime());
            //  configure driver executable, initialize
            if ((userNum == 1))
            {
                System.setProperty("webdriver.chrome.driver", "/Users/fahdksara/Desktop/SeleniumTest/Installers/Drivers/chromedriver");
            }

            if ((userNum == 2))
            {
                System.setProperty("webdriver.chrome.driver", (currentDirectory + "\\\\src\\\\chromedriver.exe"));
            }

            WebDriver driver = new ChromeDriver();
            // add 30 sec implicit wait for variable connection speeds
            // driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
            //  execute test methods in sequence
            searchGoogle(driver);
            loginTestArea(driver);
            //  testHomeModule(driver);
            // Thread.Sleep(3000);
            testChallenges(driver);
            // testPublish(driver);
            testFeed(driver);
            testReporting(driver);
            //  close the browser
            // Thread.Sleep(5000);
            driver.close();
            writeToLog("++ Test completed at " + getTime());
            Console.WriteLine(dataLog);
        }

        //  initialize a browser to google.com and search for "socialladder". click the
        //  link to our website
        public static void searchGoogle(WebDriver wd)
        {
            //  open browser with google
            wd.get("https://www.google.com");
            writeToLog("Browser loaded to www.google.com.");
            try
            {
                Thread.Sleep(3000);
                IWebElement searchField = wd.findElement(By.XPath("//*[@id=\\\"tsf\\\"]/div[2]/div[1]/div[1]/div/div[2]/input"));
                WebElement searchButton = wd.findElement(By.XPath("//*[@id=\\\"tsf\\\"]/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]"));
                searchField.click();
                searchField.sendKeys("socialladder");
                searchButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            writeToLog("Searching Google for \\\"socialladder\\\".");
            try
            {
                Thread.Sleep(3000);
                WebElement slSiteGoogle = wd.findElement(By.partialLinkText("SocialLadder |"));
                slSiteGoogle.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            writeToLog(">> Site located on Google - PASS");
        }

        //  starting from socialladder.rkiapps.com, click login button and use test
        //  credentials to access area
        public static void loginTestArea(WebDriver wd)
        {
            writeToLog(">> SL website loaded - PASS");
            WebElement slSiteLogin = wd.findElement(By.XPath("/html/body/div[1]/nav/div[1]/div[2]/ul/li[6]/a"));
            slSiteLogin.click();
            writeToLog(">> SL login page loaded - PASS");
            Thread.Sleep(2000);
            WebElement emailInput = wd.findElement(By.id("input_0"));
            emailInput.click();
            // manually input username
            emailInput.sendKeys("onebulletboy@socialladdercom");
            WebElement passwordInput = wd.findElement(By.id("input_1"));
            passwordInput.click();
            // manually input password
            passwordInput.sendKeys("social33!");
            writeToLog("Credentials entered.");
            WebElement loginButton = wd.findElement(By.XPath("/html/body/div/md-content[1]/button"));
            loginButton.click();
        }

        //  run predetermined regression tests on the home module
        public static void testHomeModule(WebDriver wd)
        {
            //  insert code to verify certain expected values on home tab
        }

        public static void testChallenges(WebDriver wd)
        {
            try
            {
                Thread.Sleep(3000);
                WebElement challengeBtn = wd.findElement(By.XPath("/html/body/main-component/div/menu-component/md-sidenav/nav/a[2]/span"));
                challengeBtn.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement createButton = wd.findElement(By.XPath("//button[@class=\\\"md-primary md-raised md-button md-ink-ripple\\\"]"));
                createButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement surveyButton = wd.findElement(By.XPath(("/html/body/div[3]/md-dialog/div/div/section[2]/" + "section[2]/div[1]/section[1]/div/section[2]/section/div[2]")));
                surveyButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                WebElement surveyName = wd.findElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[2]/section/div[3]" + "/md-input-container/div[1]/textarea"))));
                surveyName.click();
                surveyName.sendKeys(("Regression Test " + nameByDate()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WebElement option1Input = wd.findElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[5]/section[6]/div[2]" + "/div/div/div/ul[1]/li/ul/li/md-input-container/div[1]/textarea"))));
            option1Input.click();
            option1Input.sendKeys(nameByDate());
            WebElement option2Input = wd.findElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[5]/section[6]/div[2]/div/div/div/ul[2]/li/ul/li" + "/md-input-container/div[1]/textarea"))));
            option2Input.click();
            option2Input.sendKeys("Incorrect");
            try
            {
                Thread.Sleep(3000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(2000);
                WebElement challengeDescription = wd.findElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[6]" + "/section/div[3]/div/md-input-container/div[1]/textarea"))));
                challengeDescription.click();
                challengeDescription.sendKeys(("AUTO GENERATED CHALLENGE FOR REGRESSION TEST " + nameByDate()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WebElement dropDown = wd.findElement(By.XPath(("/html/body/div[3]" + ("/md-dialog/div/div/section[2]/section[2]/div[7]/div[2]/div[1]/div[2]" + "/md-input-container/md-select/md-select-value/span[1]/div"))));
            dropDown.click();
            WebElement allUsers = wd.findElement(By.XPath("/html/body/div[8]/md-select-menu/md-content/md-option[2]"));
            allUsers.click();
            try
            {
                Thread.Sleep(1000);
                WebElement nextButton = wd.findElement(By.XPath(("/html/body/div[3]" + "/md-dialog/div/div/section[3]/div[2]/button")));
                nextButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(1000);
                WebElement savePublish = wd.findElement(By.XPath("/html/body/div[3]/md-dialog/div/div/section[2]/section[2]/div[8]/section[2]/div[1]"));
                savePublish.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement submitBtn = wd.findElement(By.XPath("/html/body/div[3]/md-dialog/div/div/section[3]/div[3]/button/span"));
                submitBtn.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //         WebElement exitChallenge = wd.findElement(By.XPath("/html/body/div[3]/md-dialog/div/div/section[1]/span/i"));
            //         exitChallenge.click();
            //         
            //         try{
            //             //Thread.Sleep(3000);     
            //             WebElement exitYes = wd.findElement(By.XPath("/html/body/div[9]/md-dialog/md-dialog-actions/button[2]"));
            //             exitYes.click();
            //             } catch(Exception e){
            //             Console.WriteLine("Exception caught: \n"); e.printStackTrace();}
        }

        public static void testFeed(WebDriver wd)
        {
            try
            {
                Thread.Sleep(3000);
                WebElement feed = wd.findElement(By.XPath("/html/body/main-component/div/menu-component/md-sidenav/nav/a[7]"));
                feed.click();
                WebElement createButton = wd.findElement(By.XPath("/html/body/main-component/div/div/div/div/div[1]/div[1]/button"));
                createButton.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement feedName = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[1]/input"));
                feedName.click();
                feedName.sendKeys(("Regression Test " + nameByDate()));
                WebElement textOverlay = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[2]/input"));
                textOverlay.click();
                textOverlay.sendKeys(nameByDate());
                WebElement notificationText = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[3]/input"));
                notificationText.click();
                notificationText.sendKeys(nameByDate());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WebElement dropDown = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[7]/div/md-select"));
            dropDown.click();
            try
            {
                Thread.Sleep(3000);
                WebElement challengeOption = wd.findElement(By.XPath("/html/body/div[8]/md-select-menu/md-content/md-option[3]"));
                challengeOption.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WebElement dropDown2 = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[8]/md-select"));
            dropDown2.click();
            try
            {
                Thread.Sleep(3000);
                WebElement allUsers = wd.findElement(By.XPath("/html/body/div[9]/md-select-menu/md-content/md-option[2]"));
                allUsers.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WebElement directChallenge = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[7]/div/md-select[2]"));
            directChallenge.click();
            try
            {
                Thread.Sleep(3000);
                WebElement releaseTest = wd.findElement(By.XPath("/html/body/div[10]/md-select-menu/md-content/md-option[1]"));
                releaseTest.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //         WebElement link = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[2]/div[7]/div/input"));
            //         link.click();
            //         link.sendKeys("https://socialladder.rkiapps.com/portal/#/challenges");
            WebElement save = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[3]/button[1]"));
            save.click();
            try
            {
                Thread.Sleep(3000);
                WebElement savePublish = wd.findElement(By.XPath("/html/body/div[7]/md-dialog/section/div[3]/button[2]"));
                savePublish.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void testReporting(WebDriver wd)
        {
            try
            {
                Thread.Sleep(3000);
                WebElement testReport = wd.findElement(By.XPath("/html/body/main-component/div/menu-component/md-sidenav/nav/a[4]"));
                testReport.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement selectReport = wd.findElement(By.XPath("/html/body/main-component/div/div/div/div/div[1]/div[1]/md-input-container/md-select"));
                selectReport.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement option1 = wd.findElement(By.XPath("/html/body/div[7]/md-select-menu/md-content/md-option[1]"));
                option1.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement save = wd.findElement(By.XPath(("/html/body/main-component/div/div/div/div/div[1]/div[2]" + "/section[1]/button")));
                save.click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Thread.Sleep(3000);
                WebElement reportName = wd.findElement(By.XPath(("/html/body/div[8]/md-dialog/div/" + "md-content/md-input-container[1]/div[1]/textarea")));
                reportName.click();
                reportName.sendKeys(("Regression Test " + nameByDate()));
                WebElement reportDesc = wd.findElement(By.XPath(("/html/body/div[8]/md-dialog/div/" + "md-content/md-input-container[2]/div[1]/textarea")));
                reportDesc.click();
                reportDesc.sendKeys(("Regression Test " + nameByDate()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WebElement saveBtn = wd.findElement(By.XPath(("/html/body/div[8]" + "/md-dialog/div/md-dialog-actions/button[1]")));
            saveBtn.click();
        }
    }
}
