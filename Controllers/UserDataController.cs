namespace MyMvcReactApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using MyMvcReactApp.Core.UserData.Objects;
using MyMvcReactApp.Core.UserData.Services;

[Route("user")]
public class UserDataController : Controller
{
    private readonly IUserDataService userDataService;
    public UserDataController(IUserDataService userService)
    {
        userDataService = userService;
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = new List<User>();

        result = await userDataService.GetAllUsers().ConfigureAwait(false);

        return Ok(result);

    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = new List<User>();

        result = await userDataService.GetAllUsers().ConfigureAwait(false);

        return Ok(result);

    }

    [HttpGet("email")]
    public async Task<IActionResult> GetUserByemail(int id)
    {
        var result = new List<User>();

        result = await userDataService.GetAllUsers().ConfigureAwait(false);

        return Ok(result);

    }

    [HttpPost("adduser")]
    public async Task<IActionResult>AddUser(string name, string email)
    {
        bool result = false;

        result =  await userDataService.AddUserAsync(name, email).ConfigureAwait(false);

        return Ok(result);
    }
}
