using System;
using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Domain.Entities;

public class Customer : BaseAuditableEntity
{
    [Required]
    public int CustomerId { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int? BankAccountNumber { get; set; }


}
