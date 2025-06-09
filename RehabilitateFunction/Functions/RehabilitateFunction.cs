using Core.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace RehabilitateFunction.Functions;

public class RehabilitateFunction(IUserService service, ILogger<RehabilitateFunction> logger)
{
    [Function("RehabilitateFunction")]
    public async Task Run([TimerTrigger("0 * * * *")] TimerInfo timer)
    {
        try
        {
            await service.LiftTemporaryBans();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}