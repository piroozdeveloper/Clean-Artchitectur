using CrudWebApi.Domain.Entities;

namespace CrudWebApi.Application.Common.Interfaces;
public interface IApplicationDbContext
{
   // DbSet<TodoList> TodoLists { get; }

   // DbSet<TodoItem> TodoItems { get; }

    DbSet<Customer> Customers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
