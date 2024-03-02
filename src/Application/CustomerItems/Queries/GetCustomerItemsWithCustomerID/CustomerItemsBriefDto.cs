using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Domain.Entities;

namespace CrudWebApi.Application.CustomerItems.Queries.GetCustomerItemsWithCustomerID;
public class CustomerItemsBriefDto
{
    public int CustomerId { get; init; }
    public string? FirstName { get; init; }

    public string? LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
    public string? BankAccountNumber { get; init; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerItemsBriefDto>();
        }
    }
}
