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

                var deleteBtn = myInfo.tableRows.Nth(i).Locator("button").Nth(1);
                await deleteBtn.ClickAsync();
                await Page.PauseAsync();
            }




        }

        await myInfo.EmergencyLink.ClickAsync();

        var pepe =  Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = " Add " }).First;
        await pepe.ClickAsync();

        var input_locator = Page.Locator("xpath=//label[contains(text(), 'Name')]/ancestor::div[contains(@class,'oxd-input-group')]//input");
        await input_locator.FillAsync("Texto que quieres escribir");


        var relationship_locator = Page.Locator("xpath=//label[contains(text(), 'Relationship')]/ancestor::div[contains(@class,'oxd-input-group')]//input");
        await relationship_locator.FillAsync("test");
        var hometelephone_locator = Page.Locator("xpath=//label[contains(text(), 'Home Telephone')]/ancestor::div[contains(@class,'oxd-input-group')]//input");
        await hometelephone_locator.FillAsync("12345");









        //new PageGetByRoleOptions { Name = " Save " })

        await Page.PauseAsync();

        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "personalInfoupdate.png",
            FullPage = true
        });
        /// adding text to test the push

        /*
        await page.Locator("form").GetByRole(AriaRole.Textbox).First.ClickAsync();
        await page.Locator("form").GetByRole(AriaRole.Textbox).First.FillAsync("name");
        await page.Locator("form").GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
        await page.Locator("form").GetByRole(AriaRole.Textbox).Nth(1).FillAsync("relationship");
        await page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

        */
    }
}
