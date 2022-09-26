using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Shared;

namespace SubtitleRed.Controllers;

public class BaseApiController : ControllerBase
{
    protected IActionResult GetResponseFromResult<TSuccess>(Result<TSuccess, Error> result) => 
        result.IsSuccess ? Ok(result.Data) : ErrorToResponse(result.Error!);

    private IActionResult ErrorToResponse(Error error) => 
        error.Message is not null ? UnprocessableEntity(error.Message) : Problem("Internal error!");
}