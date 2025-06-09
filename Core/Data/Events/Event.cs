namespace Core.Data.Events;

public abstract record class Event<T>(string Type, Guid Id, T Payload, long Timestamp);