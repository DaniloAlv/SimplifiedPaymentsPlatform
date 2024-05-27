using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplifiedPaymentsPlatform.Application.Commands;

namespace SimplifiedPaymentsPlatform.API.Controllers;

public class TransferController : BaseController
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
            return Ok(new { message = "Transferência realizada com sucesso!"});
        }
        catch (Exception ex)
        {
            return BadRequestResponse(ex.Message);
        }
    }
}