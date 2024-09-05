using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightDemo.Pages;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightDemo;

[TestFixture]

public class NUnitPWA : PageTest //inherits this class very important from nunit Section 19 unit 114.
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
    public async Task TestUploadDoc()
    {

        //var page = await browser.NewPageAsync();

        //await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");



        var basepage = new BasePage(Page); //common elements page-leftmenu



        //navigate to my info 

        await basepage.NavigateLeftMenuMyInfo();

        //await page.PauseAsync();

        var myInfo = new MyInfoPageNunit(Page);
        


        await myInfo.AddBtn.ClickAsync();

        //await myInfo.BrowseAttachments.ClickAsync();

        await myInfo.FileInput.SetInputFilesAsync("C:\\testing\\PlaywrightCsharp\\attachment.txt");

        var fileName = "attachment.txt";

        await myInfo.SaveAttBtn.ClickAsync(); // saves the attachment 

        //scan the table of attachments to look the one needed and deleted

        //table element class="oxd-table-body"


        for (var i=0; i< await myInfo.tableRows.CountAsync(); ++i)
        {

            var attachmentName = await myInfo.tableRows.Nth(i).Locator(("div:text('attachment.txt')")).TextContentAsync(); ///

            if (attachmentName == fileName)
            {



            }




        }



        await Page.PauseAsync();

        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "personalInfoupdate.png",
            FullPage = true
        });
        /// adding text to test the push



    }
}
