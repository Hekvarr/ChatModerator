using Core.Data.Entities;

namespace Core.Data.Events;

public record MessageCreatedEvent(Guid Id, Message Payload, long Timestamp)
    : Event<Message>(nameof(MessageCreatedEvent), Id, Payload, Timestamp);