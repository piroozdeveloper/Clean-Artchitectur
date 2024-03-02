using CrudWebApi.Application.Common.Exceptions;
using CrudWebApi.Application.CustomerItems.Commands.CreateCustomerItem;

using CrudWebApi.Domain.Entities;

using static CrudWebApi.Application.FunctionalTests.Testing;

namespace CrudWebApi.Application.FunctionalTests.CustomerItems.Commands;
public class CreateCustomerItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateCustomerItemCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateCustomerItem()
    {
        var userId = await RunAsDefaultUserAsync();



        var command = new CreateCustomerItemCommand
        {
            CustomerId = 0,
            FirstName = "es",

            LastName = "hhh",
           // DateOfBirth =DateTime.Now,
            PhoneNumber = "99999",
            Email = "a@gmail.com",
            BankAccountNumber =123233,
};

        var Id = await SendAsync(command);

        var item = await FindAsync<Customer>(Id);

        item.Should().NotBeNull();
       // item!.Id.Should().null;//.BeNull();//(command.CustomerId);
        item!.CustomerId.Should().Be(command.CustomerId);
        item.FirstName.Should().Be(command.FirstName);
        item.LastName.Should().Be(command.LastName);
       // item.DateOfBirth.Should().Be(command.DateOfBirth);
        item.PhoneNumber.Should().Be(command.PhoneNumber);
        item.Email.Should().Be(command.Email);
        item.BankAccountNumber.Should().Be(command.BankAccountNumber);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
