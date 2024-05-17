using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplifiedPaymentsPlatform.Application.Commands;

namespace SimplifiedPaymentsPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransferController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TransferCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok("Transferência realizada com sucesso!");
        }
        catch (Exception)
        {
            return BadRequest("Algo deu errado.");
        }
    }
}