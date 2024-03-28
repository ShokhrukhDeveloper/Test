using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;
namespace Test.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Entities.Test> Tests { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Password> Passwords { get; set; }
    
}