using DesafioSpedy.Application.Dtos.Base;
using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DesafioSpedy.Api.Controllers;

[Route("api/ticket")]
[ApiController]
[Authorize]
public class TicketController(TicketService _ticketService) : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(typeof(PagedResult<GetTicketDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll(
     [FromQuery] GetTicketFilterDto filters
    )
    {
        var result = _ticketService.GetAllAsync(filters);

        return Created(string.Empty, result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TicketResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateTicketDto dto
    )
    {
        var result = await _ticketService.Create(dto);

        return Created(string.Empty, result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        Guid Id
    )
    {
        await _ticketService.Delete(Id);

        return NoContent();
    }

}
