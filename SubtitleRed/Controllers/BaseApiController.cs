using System.Data.Entity.Core;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Shared;

namespace SubtitleRed.Controllers;

public class BaseApiController : ControllerBase
{
    protected IActionResult GetResponseFromResult<TSuccess>(Result<TSuccess, Error> result) =>
        result.IsSuccess ? Ok(result.Data) : ErrorToResponse(result.Error!);

    private IActionResult ErrorToResponse(Error error) => error switch
    {
        { Message : not null } => UnprocessableEntity(error.Message),
        { Exception : not null } => CreateProblemResponseByErrorException(error),
        var _ => GetInternalErrorResponse()
    };

    private ObjectResult GetInternalErrorResponse() =>
        Problem("Internal server error.", statusCode: StatusCodes.Status500InternalServerError);

    private IActionResult CreateProblemResponseByErrorException(Error error) => error.Exception switch
    {
        ObjectNotFoundException => Problem("Object was not found", statusCode: StatusCodes.Status404NotFound),
        var _ => GetInternalErrorResponse(),
    };
}