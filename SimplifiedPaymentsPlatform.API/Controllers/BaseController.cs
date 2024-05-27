using Microsoft.AspNetCore.Mvc;
using SimplifiedPaymentsPlatform.API.ViewModels;

namespace SimplifiedPaymentsPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected BaseController(){}

    public OkObjectResult OkResponse<T>(T data)
    {
        return base.Ok(Result.Success(data));
    }

    public BadRequestObjectResult BadRequestResponse(string errorDescription)
    {
        return base.BadRequest(Result.Failure(new Error(errorDescription)));
    }

    public CreatedResult CreatedObjectResponse<T>(string redirectUrl, T data)
    {
        return base.Created(redirectUrl, Result.Success(data));
    }

    public NotFoundObjectResult NotFoundResponse(string errorDescription)
    {
        return base.NotFound(Result.Failure(new Error(errorDescription)));
    }
}