using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class BasePage
{
    private readonly ILocator _lnkAdmin;  //to navifate to admin menu
    private readonly ILocator _lnkDashBoard; //to navigate to dashboad
    private readonly ILocator _lnkMyInfo; //to navigate to dashboad



    private readonly IPage _page;
   

    public BasePage(IPage page)  ///here all the locators in the page.
    {
        _page = page;
        //_lnkLogin = _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" });
        //_txtUserName = _page.GetByLabel("UserName");
        _lnkDashBoard = _page.GetByRole(AriaRole.Link, new() { Name = "Dashboard" });
        //_txtPassword = _page.GetByLabel("Password");
        _lnkAdmin = _page.GetByRole(AriaRole.Link, new() { Name = "Admin" });

        _lnkMyInfo = _page.GetByRole(AriaRole.Link, new() { Name = "My Info" });




    }

    public async Task NavigateLeftMenuAdmin() //the login action, pass user and pass.
    {
        await _lnkAdmin.ClickAsync();
        //await _lnkDashBoard.ClickAsync();
    }

    public async Task NavigateLeftMenuMyInfo() //the login action, pass user and pass.
    {
        await _lnkMyInfo.ClickAsync();
        //await _lnkDashBoard.ClickAsync();
    }



    public async Task NavigateLeftMenuDashboard() //the login action, pass user and pass.
    {
        await _lnkDashBoard.ClickAsync();
        //await _lnkDashBoard.ClickAsync();
    }






}