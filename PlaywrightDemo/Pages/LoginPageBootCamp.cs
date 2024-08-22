using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPageBootCamp
{
    private readonly ILocator _btnLogin;
    private readonly ILocator _lnkEmployeeDetails;
    
    private readonly IPage _page;
    private readonly ILocator _txtPassword;
    private readonly ILocator _txtUserName;

    public LoginPageBootCamp(IPage page)  ///here all the locators in the page.
    {
        _page = page;
        //_lnkLogin = _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" });
        //_txtUserName = _page.GetByLabel("UserName");
        _txtUserName = _page.GetByPlaceholder("UserName");
        //_txtPassword = _page.GetByLabel("Password");
        _txtPassword = _page.GetByPlaceholder("Password");

        _btnLogin = page.GetByRole(AriaRole.Button, new() { Name = "Login" });

        //_btnLogin = _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Log in" });
        _lnkEmployeeDetails = _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Employee List" });


        //await page.GetByPlaceholder("Username").FillAsync("Admin");
        // await page.GetByPlaceholder("Password").FillAsync("admin123");

        


    }
    public ILocator SendLocator()
    {

        return _btnLogin;

    }

    
    public async Task Login(string userName, string password) //the login action, send user and pass.
    {
        await _txtUserName.FillAsync(userName);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }



    



}
    