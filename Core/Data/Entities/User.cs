namespace Core.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsBannedForever { get; set; }
    public bool IsTemporarilyBanned { get; set; }
    public DateTime? BannedUntil { get; set; }
    public List<Message> Messages { get; set; }
}