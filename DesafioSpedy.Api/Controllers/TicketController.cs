using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace DesafioSpedy.Api.Controllers;

[Route("api/auth")]
[ApiController]
//[Authorize]
public class TicketController(TicketService _ticketService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTicketDto dto
    )
    {
        var result = await _ticketService.Create(dto);

        return Created(string.Empty, result);
    }

}
