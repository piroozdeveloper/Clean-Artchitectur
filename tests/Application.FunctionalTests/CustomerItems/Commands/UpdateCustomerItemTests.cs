using CrudWebApi.Application.CustomerItems.Commands.CreateCustomerItem;
using CrudWebApi.Application.CustomerItems.Commands.UpdateCustomerItem;

using CrudWebApi.Domain.Entities;


using static CrudWebApi.Application.FunctionalTests.Testing;

namespace CrudWebApi.Application.FunctionalTests.TodoItems.Commands;
public class UpdateCustomerItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidCustomerItemCustomerId()
    {
        var command = new UpdateCustomerItemCommand {CustomerId= 99 };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateTodoItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var customer = await SendAsync(new CreateCustomerItemCommand
        {
            CustomerId = 0,
            FirstName = "es",

            LastName = "hhh",
            DateOfBirth = DateTime.Now,
            PhoneNumber = "99999",
            Email = "a@gmail.com",
            BankAccountNumber = 123233,
        });

      

        var command = new UpdateCustomerItemCommand
        {
            CustomerId = 0,
            FirstName = "es",

            LastName = "hhh",
            DateOfBirth = DateTime.Now,
            PhoneNumber = "99999",
            Email = "a@gmail.com",
            BankAccountNumber = 123233,
        };

        await SendAsync(command);

        var item = await FindAsync<Customer>(customer);

        item.Should().NotBeNull();
        item!.FirstName.Should().Be(command.FirstName);
        item.LastName.Should().Be(command.LastName);
        item.DateOfBirth.Should().Be(command.DateOfBirth);
        item.PhoneNumber.Should().Be(command.PhoneNumber);
        item.Email.Should().Be(command.Email);
        item.BankAccountNumber.Should().Be(command.BankAccountNumber);
        item.LastModifiedBy.Should().NotBeNull();
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
