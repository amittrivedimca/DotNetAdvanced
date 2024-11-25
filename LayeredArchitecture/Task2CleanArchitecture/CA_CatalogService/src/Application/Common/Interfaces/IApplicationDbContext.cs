using CA_CatalogService.Domain.Entities;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<ItemCategory> Categories { get; }
    DbSet<Product> Products { get; }    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
