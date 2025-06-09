using System.Text.Json;
using Core.Data.Events;
using Core.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ModerationFunction.Functions;

public class ModerationFunction(IUserModerationService service, ILogger<ModerationFunction> logger)
{
    [Function("ModerationFunction")]
    public async Task Run(
        [RabbitMQTrigger("chat-messages", ConnectionStringSetting = "RabbitMQConnection")]
        string item)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var messageEvent = JsonSerializer.Deserialize<MessageCreatedEvent>(item, options);

            if (messageEvent is not null)
            {
                logger.LogInformation($"Processing Event ID: {messageEvent.Id}");
                await service.ProcessMessage(messageEvent.Payload);
            }
            else
            {
                logger.LogWarning("Received null after deserialization.");
            }
        }
        catch (JsonException ex)
        {
            logger.LogError(ex, "Failed to deserialize the message.");
        }
    }
}