using DesafioSpedy.Application.Dtos.Auth;
using DesafioSpedy.Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace DesafioSpedy.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(AuthenticationService authenticationService) : ControllerBase
{
    private readonly AuthenticationService _authenticationService = authenticationService;

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Login(
        [FromBody] CredentialsDto dto
    )
    {
        var result = await _authenticationService.Login(dto);

        return Ok(result);
    }
}
