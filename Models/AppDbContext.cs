using Microsoft.EntityFrameworkCore;
using thesis_exercise.Models;
public class AppDbContext : DbContext
{
    // Constructor
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
    {

    }

    // override OnModelCreating
    // This method is executed when a model create
    // For instance, Seed method can call inside it and insert data inside the database when model wants to be created.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Computer> Computers { get; set; }
}