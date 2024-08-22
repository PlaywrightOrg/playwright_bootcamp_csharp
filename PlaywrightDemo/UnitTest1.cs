using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightDemo.Pages;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightDemo;

public class TestDs
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1d()
    {
        //playwright download
        using var playwright = await Playwright.CreateAsync();
        //browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,

        }); //which browser and the mode
        //Page
        var page = await browser.NewPageAsync();

        
        await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        // take snapshot from login page.

      


        await page.GetByPlaceholder("Username").FillAsync("Admin");
        await page.GetByPlaceholder("Password").FillAsync("admin123");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "loginpage.png",
            FullPage = true
        });


        await page.GetByRole(AriaRole.Button, new (){ Name = "Login"}).ClickAsync();

        //await page.GetByLabel("Admin").ClickAsync();

        //navigates to Admin form.
        await page.GetByRole(AriaRole.Link, new() { Name = "Admin"}).ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).WaitForAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "adminpage.png",
            FullPage = true
        });

        // navigates back to Dashboard.

        await page.GetByRole(AriaRole.Link, new() { Name = "Dashboard" }).ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Timesheets" }).IsVisibleAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Timesheets" }).WaitForAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "Dashboard.png",
            FullPage = true
        });



        //made an operation
        //await page.ClickAsync("text=Login"); //"selectortype=whichone"
        //await page.ScreenshotAsync();   //take a snapshot.

        //await page.FillAsync("#UserName", "admin");
        //await page.FillAsync("#UserName", "admin");
        //await page.FillAsync("#Password", "password");

        //await page.ClickAsync("text=Log in");

        //var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync(); //returns a boolean

        //Assert.IsTrue(isExist); //verify the boolean.







    }


    [Test]
    public async Task TestBasico()
    {
        //playwright download
        using var playwright = await Playwright.CreateAsync();
        //browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,

        }); //which browser and the mode
        //Page
        var page = await browser.NewPageAsync();


        await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        // take snapshot from login page.




        await page.GetByPlaceholder("Username").FillAsync("Admin");
        await page.GetByPlaceholder("Password").FillAsync("admin123");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "loginpage.png",
            FullPage = true
        });


        await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

        //await page.GetByLabel("Admin").ClickAsync();

        //navigates to Admin form.
        await page.GetByRole(AriaRole.Link, new() { Name = "Admin" }).ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).WaitForAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "adminpage.png",
            FullPage = true
        });

        // navigates back to Dashboard.

        await page.GetByRole(AriaRole.Link, new() { Name = "Dashboard" }).ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Timesheets" }).IsVisibleAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Timesheets" }).WaitForAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "Dashboard.png",
            FullPage = true
        });



        //made an operation
        //await page.ClickAsync("text=Login"); //"selectortype=whichone"
        //await page.ScreenshotAsync();   //take a snapshot.

        //await page.FillAsync("#UserName", "admin");
        //await page.FillAsync("#UserName", "admin");
        //await page.FillAsync("#Password", "password");

        //await page.ClickAsync("text=Log in");

        //var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync(); //returns a boolean

        //Assert.IsTrue(isExist); //verify the boolean.







    }


    [Test]

    public async Task UpdatePersonalInfo()
    {
        using var playwright = await Playwright.CreateAsync();
        //browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,

        }); //which browser and the mode
        //Page
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        

        LoginPageBootCamp LoginPageBootCamp = new LoginPageBootCamp(page); //login page
        var basepage = new BasePage(page); //common elements page-leftmenu

        await LoginPageBootCamp.SendLocator().WaitForAsync();
                
        await LoginPageBootCamp.Login(userName: "Admin", password: "admin123"); 

        //navigate to my info 

        await basepage.NavigateLeftMenuMyInfo();
        await page.PauseAsync();

        var myInfo = new MyInfoPage(page);

        // enter new values in the personal details section

        await myInfo.UpdatePersonalDetails(userName: "Juan ", userMiddleName: "Roman", userLastName: "Riquelme");

        

        await page.PauseAsync();












    }





    [Test]
    public async Task TestWithPOM()
    {
        //playwright download
        using var playwright = await Playwright.CreateAsync();
        //browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,

        }); //which browser and the mode
        //Page
        var page = await browser.NewPageAsync();


        await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        // take snapshot from login page.

        LoginPageBootCamp LoginPageBootCamp = new LoginPageBootCamp(page);
        var basepage = new BasePage(page);

        await LoginPageBootCamp.SendLocator().WaitForAsync();
        


        //await page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).WaitForAsync();


        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "loginpage.png",
            //Path = "C:\\testing\\PlaywrightCsharp\\clonedProjectLess113\\Playwrightdotnet\\PlaywrightDemo\\Pages\\screenshots\\loginpage.png",
            FullPage = true
        });



       

        await LoginPageBootCamp.Login(userName: "Admin", password: "admin123");

        //new object to create Dashboard page
        
        var DashboardPage = new DashboardPage(page);

        var textToevaluate = "Time at Work";

        //Expect(textToevaluate).toBeVisible();
        

        var textFound = await DashboardPage.DashBoardSendLocator().InnerTextAsync();

        //validation over Dashboardpage 
        Assert.That(textToevaluate, Is.EqualTo(textFound));
        
        
                     
            

        


        //await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

        //await page.GetByLabel("Admin").ClickAsync();

        //navigates to Admin form.

        await basepage.NavigateLeftMenuAdmin(); //to click in admin button.
        
        //await page.GetByRole(AriaRole.Link, new() { Name = "Admin" }).ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).WaitForAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "adminpage.png",
            FullPage = true
        });

        // navigates back to Dashboard.

        //await page.GetByRole(AriaRole.Link, new() { Name = "Dashboard" }).ClickAsync();
        await basepage.NavigateLeftMenuDashboard();


        await page.GetByRole(AriaRole.Button, new() { Name = "Timesheets" }).IsVisibleAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Timesheets" }).WaitForAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "Dashboard.png",
            FullPage = true
        });


    }


}