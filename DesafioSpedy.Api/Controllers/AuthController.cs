using Microsoft.AspNetCore.Mvc;
namespace DesafioSpedy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    //[ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        //[FromBody] CredentialsDto dto
    )
    {
        //var result = await _authenticationService.Login(dto);

        return Ok("teste");
    }
}
