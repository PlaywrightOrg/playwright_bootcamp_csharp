using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightDemo.Pages;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightDemo;

[TestFixture]

public class NUnitPW : PageTest //inherits this class very important from nunit Section 19 unit 114.
{
    

    [SetUp]
    public async Task Setup()
    {

        await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        // log in actions.
        LoginPageBootCamp LoginPageBootCamp = new LoginPageBootCamp(Page); //login page


        await LoginPageBootCamp.SendLocator().WaitForAsync();

        await LoginPageBootCamp.Login(userName: "Admin", password: "admin123");

        //log in actions
    }

    [Test]
    public async Task TestInfo()
    {

        //var page = await browser.NewPageAsync();

        //await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");



        var basepage = new BasePage(Page); //common elements page-leftmenu



        //navigate to my info 

        await basepage.NavigateLeftMenuMyInfo();

        //await page.PauseAsync();

        var myInfo = new MyInfoPageNunit(Page);
        string firstName = "Juanito";
        // enter new values in the personal details section

        await myInfo.UpdatePersonalDetails(firstName, userMiddleName: "Roman", userLastName: "Riquelme");

        await Expect(myInfo.FirstNameSendLocator()).ToHaveValueAsync(firstName); 



        
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "personalInfoupdate.png",
            FullPage = true
        });
        /// adding text to test the push

        

    }
}


