using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApi.Application.CustomerItems.Commands.CreateCustomerItem;
public class CreateCustomerItemCommandValidator:AbstractValidator<CreateCustomerItemCommand>
{
    public CreateCustomerItemCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(20)
            .NotEmpty();
        RuleFor(v => v.LastName)
          .MaximumLength(20)
          .NotEmpty();

        RuleFor(v => v.DateOfBirth)
        .LessThanOrEqualTo(DateTime.Now)
        .NotEmpty();

        RuleFor(v => v.PhoneNumber)
         .MaximumLength(15)
         .NotEmpty();

        RuleFor(V => V.Email).EmailAddress();

        RuleFor(v => v.BankAccountNumber)
          
          .NotEmpty();
    }

}
