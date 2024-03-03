using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Application.Common.Interfaces;
using CrudWebApi.Domain.Entities;
using CrudWebApi.Domain.Events;

namespace CrudWebApi.Application.CustomerItems.Commands.CreateCustomerItem;
public record CreateCustomerItemCommand : IRequest<int>
{
    public int CustomerId { get; init; }
    public string? FirstName { get; init; }

    public string? LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
    public int? BankAccountNumber { get; init; }
}

public class CreateCustomerItemCommandHandler : IRequestHandler<CreateCustomerItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomerItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCustomerItemCommand request, CancellationToken cancellationToken)
    {
        //check Duplicate Data

        var check = _context.Customers
         .Select(x => x.BankAccountNumber == request.BankAccountNumber &&
         x.FirstName == request.FirstName && x.LastName == request.LastName).FirstOrDefaultAsync(cancellationToken);

        if (check == null)
        {

            var entity = new Customer
            {
                CustomerId = request.CustomerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber,
                PhoneNumber = request.PhoneNumber,

            };

            entity.AddDomainEvent(new CustomerItemCreatedEvent(entity));

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

       else
        {
            return 0;
        }



        
    }
}

