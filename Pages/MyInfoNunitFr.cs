using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Runtime.CompilerServices;

namespace PlaywrightDemo.Pages;

public class MyInfoPageNunit
{
    private readonly ILocator _firstName;
    private readonly ILocator _middleName;
    private readonly ILocator _lastName;

    private readonly ILocator _saveBtn;
    private readonly IPage _page;


    private readonly ILocator _attachmenteBtn;

    private readonly ILocator _browseAttachments;

    private readonly ILocator _fileInput;   
    private readonly ILocator _saveAttBtn;
    private readonly ILocator _tablerows;


    private readonly ILocator _emergencyLink;


    public MyInfoPageNunit(IPage page)  ///here all the locators in the page.
    {
        _page = page;
        //_lnkLogin = _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" });
        //_txtUserName = _page.GetByLabel("UserName");
        //_firstName = _page.GetByPlaceholder("First Name");
        _firstName = _page.Locator("input.orangehrm-firstname");


        //_txtPassword = _page.GetByLabel("Password");
        _middleName = _page.GetByPlaceholder("Middle Name");

        _lastName = _page.GetByPlaceholder("Last Name");

        //_btnLogin = _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Log in" });
        _saveBtn = _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = " Save " }).First;

        //_saveBtn = _page.Locator("form").Filter(new() { HasText = "Employee Full NameEmployee" }).GetByRole(AriaRole.Button);


        //await page.GetByPlaceholder("Username").FillAsync("Admin");
        // await page.GetByPlaceholder("Password").FillAsync("admin123");

        //await page.Locator("form").Filter(new() { HasText = "Employee Full NameEmployee" }).GetByRole(AriaRole.Button).ClickAsync();

        _attachmenteBtn = _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = " Add " });

        _browseAttachments = _page.GetByText("Browse");

        _fileInput = _page.Locator("input[type='file'].oxd-file-input");

        _saveAttBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).Nth(2);

        _tablerows = _page.Locator(".oxd-table-body .oxd-table-card");

        _emergencyLink = _page.Locator("a[href='/web/index.php/pim/viewEmergencyContacts/empNumber/7']");
              
                
        //_emergencyLink = _page.GetByText("EmergencyContacts");






    }



    public async Task UpdatePersonalDetails(string userName, string userMiddleName, string userLastName) //send the personal info details.
    {
        //await _firstName.WaitForAsync();
        await _firstName.ClickAsync();
        await _firstName.FillAsync("");
        await _firstName.FillAsync(userName);

        // await Page.PauseAsync();
        await _middleName.ClearAsync();
        await _middleName.FillAsync(userMiddleName);
        await _lastName.FillAsync(userLastName);
        await _saveBtn.ClickAsync();
        await _firstName.ClickAsync();


    }

    public ILocator FirstNameSendLocator()
    {

        return _firstName;
        //add row

    }
    public ILocator MiddleName => _middleName;
    public ILocator AddBtn => _attachmenteBtn;

    public ILocator BrowseAttachments => _browseAttachments;

    public ILocator FileInput => _fileInput;
    public ILocator SaveAttBtn => _saveAttBtn;
    // table, from parent to child..

    public ILocator tableRows => _tablerows;

    public ILocator EmergencyLink => _emergencyLink;    


}







