using System.Reflection;
using CrudWebApi.Application.Common.Interfaces;
using CrudWebApi.Domain.Entities;
using CrudWebApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

  //  public DbSet<TodoList> TodoLists => Set<TodoList>();

  //  public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "DefaultConnection";

            optionsBuilder.UseSqlite(connectionString, options => options.MigrationsAssembly("CrudWebApi.Infrastructure"));
        }
        base.OnConfiguring(optionsBuilder);
    }
}
