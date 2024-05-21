using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplifiedPaymentsPlatform.Application.Commands;

namespace SimplifiedPaymentsPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediatr;

    public UserController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var command = new UserByIdCommand(id);
            var userResponse = await _mediatr.Send(command);
            return Ok(userResponse);
        }
        catch(Exception ex)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        try
        {
            var userResponse = await _mediatr.Send(command);
            return Created(nameof(GetById), userResponse);
        }
        catch(Exception ex)
        {
            return BadRequest(new {Error = ex.Message});
        }
    }
}