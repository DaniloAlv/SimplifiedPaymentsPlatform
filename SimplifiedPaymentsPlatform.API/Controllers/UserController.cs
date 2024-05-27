using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimplifiedPaymentsPlatform.Application.Commands;

namespace SimplifiedPaymentsPlatform.API.Controllers;

public class UserController : BaseController
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
            return OkResponse(userResponse);
        }
        catch(Exception ex)
        {
            return NotFoundResponse(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        try
        {
            var userResponse = await _mediatr.Send(command);
            return CreatedObjectResponse(nameof(GetById), userResponse);
        }
        catch(Exception ex)
        {
            return BadRequestResponse(ex.Message);
        }
    }
}