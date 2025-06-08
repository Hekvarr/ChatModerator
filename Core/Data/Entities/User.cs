namespace Core.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsBanedForever { get; set; }
    public bool IsTemporarilyBaned { get; set; }
    public DateTime? BanedUntil { get; set; }
}