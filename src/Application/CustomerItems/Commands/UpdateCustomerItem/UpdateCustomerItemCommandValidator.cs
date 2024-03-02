using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApi.Application.CustomerItems.Commands.UpdateCustomerItem;
public class UpdateCustomerItemCommandValidator : AbstractValidator<UpdateCustomerItemCommand>
{
    public UpdateCustomerItemCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
