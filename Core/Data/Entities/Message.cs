namespace Core.Data.Entities;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool HasOffensiveContent { get; set; } = false;
    public int UserId { get; set; }
    public User User { get; set; }
}