using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo;

public class NUnitPlaywright : PageTest //inherits this class very important from nunit Section 19 unit 114.
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {

        //
        //Using Locators
        var lnkLogin = Page.Locator("text=Login"); //it has autowaiting no need await
        await lnkLogin.ClickAsync();
        await Page.ClickAsync("text=Login");
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        //Using Locator with Page Locator Options
        var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" });
        await btnLogin.ClickAsync();
        //await Page.ClickAsync("text=Log in");
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();//replace this from the locator from the test file
    }
}