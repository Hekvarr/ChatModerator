using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BanUserFunction.Functions;

public class BanUserFunction(IUserService service, ILogger<BanUserFunction> logger)
{
    [Function("BanUserFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users/{userId}")]
        HttpRequest req, int userId)
    {
        try
        {
            await service.BanForever(userId);
            return new OkObjectResult(new { Success = true });
        }
        catch (UserNotFoundException e)
        {
            return new NotFoundObjectResult(new { Error = "User with given id not found." });
        }
        catch (UserAlreadyBannedException)
        {
            return new BadRequestObjectResult(new { Error = "User is already banned." });
        }
        catch (Exception e)
        {
            return new ObjectResult(new { Error = $"Unhandled error: {e.Message}" }) { StatusCode = 500 };
        }
    }
}