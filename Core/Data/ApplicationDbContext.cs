using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
            entity.Property(e => e.IsBannedForever)
                .HasColumnName("is_banned_forever");
            entity.Property(e => e.IsTemporarilyBanned)
                .HasColumnName("is_temporarily_banned");
            entity.Property(e => e.BannedUntil)
                .HasColumnName("banned_until");
        });
    }

}