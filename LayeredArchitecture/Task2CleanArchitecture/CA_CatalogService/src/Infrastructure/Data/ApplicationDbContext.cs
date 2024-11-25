using System.Reflection;
using CA_CatalogService.Application.Common.Interfaces;
using CA_CatalogService.Domain.Entities;
using CA_CatalogService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA_CatalogService.Infrastructure.Data;

//public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<ItemCategory> Categories => Set<ItemCategory>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
