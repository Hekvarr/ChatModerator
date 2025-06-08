using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}