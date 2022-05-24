#nullable disable
namespace Ewadul.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Ewadul.Api.Helpers;
using Ewadul.Api.Models;
using Ewadul.Api.Services;
using Ewadul.Api.DTO;

[ApiController]
[Route("api/v1/login")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _authService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}
