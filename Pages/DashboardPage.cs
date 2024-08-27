using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class DashboardPage
{
    private readonly ILocator _timeatWorktitle;  //to navifate to admin menu



    private readonly IPage _page;

    public DashboardPage(IPage page)  ///here all the locators in the page.
    {
        _page = page;
        //_lnkLogin = _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" });
        //_txtUserName = _page.GetByLabel("UserName");
        _timeatWorktitle = _page.GetByText("Time at Work");
        //_txtPassword = _page.GetByLabel("Password");





    }

    public ILocator DashBoardSendLocator()
    {

        return _timeatWorktitle;

    }




}