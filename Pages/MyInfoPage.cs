using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class MyInfoPage
{
    private readonly ILocator _firstName;
    private readonly ILocator _middleName;
    private readonly ILocator _lastName;
    
    private readonly ILocator _saveBtn;
    private readonly IPage _page;

  
    

    public MyInfoPage(IPage page)  ///here all the locators in the page.
    {
        _page = page;
        //_lnkLogin = _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" });
        //_txtUserName = _page.GetByLabel("UserName");
        _firstName = _page.GetByPlaceholder("First Name");
        //_txtPassword = _page.GetByLabel("Password");
        _middleName = _page.GetByPlaceholder("Middle Name");

        _lastName = _page.GetByPlaceholder("Last Name");

        //_btnLogin = _page.GetByRole   (AriaRole.Button, new PageGetByRoleOptions { Name = "Log in" });
        _saveBtn = _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = " Save " }).First;


        


        //await page.GetByPlaceholder("Username").FillAsync("Admin");
        // await page.GetByPlaceholder("Password").FillAsync("admin123");




    }
    


    public async Task UpdatePersonalDetails(string userName, string userMiddleName, string userLastName) //send the personal info details.
    {
        await _firstName.WaitForAsync();
       
        await _firstName.FillAsync(userName);
        await _middleName.FillAsync(userMiddleName);
        await _lastName.FillAsync(userLastName);
        await _saveBtn.ClickAsync();


    }







}