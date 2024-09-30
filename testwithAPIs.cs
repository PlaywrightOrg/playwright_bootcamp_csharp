using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightDemo.Pages;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace PlaywrightDemo;

public class ApiTests
{
    private IAPIRequestContext _apiRequestContext;

    [SetUp]
    public async Task SetUp()
    {
        var playwright = await Playwright.CreateAsync();
        _apiRequestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            IgnoreHTTPSErrors = true // This will ignore HTTPS errors
        });
    }

    [Test]
    public async Task TestLoginViaApi()
    {
        // Define the login credentials
        var loginPayload = new
        {
            username = "Admin",
            password = "admin123"
        };

        // Serialize the login payload to JSON
        string jsonPayload = JsonSerializer.Serialize(loginPayload);

        // Send the login request to the API endpoint
        var loginResponse = await _apiRequestContext.PostAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/validate",    new APIRequestContextOptions     {
            Headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json"}
            },
            Data = jsonPayload
        });

        // Check the response status code and perform further actions as needed
        Assert.AreEqual(200, loginResponse.Status);

        

        // Optionally, extract the authentication token from the response for further requests
        string responseBody = await loginResponse.TextAsync();
        Console.WriteLine(loginResponse);
        //Console.WriteLine(responseBody);

        // Deserialize the response body to extract the token (assuming the token is in the response)
        //var responseJson = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
        //string authToken = responseJson["token"]; // Adjust the key according to your API response

        // Use the authToken for authenticated requests in further tests

        // Note: This is just an example, adjust the URL, headers, and payload according to your actual API
    }

}