using CrudWebApi.Application.CustomerItems.Commands.CreateCustomerItem;
using CrudWebApi.Application.CustomerItems.Commands.DeleteCustomerItem;

using CrudWebApi.Domain.Entities;
using CrudWebApi.Application.FunctionalTests;


using static CrudWebApi.Application.FunctionalTests.Testing;

namespace CrudWebApi.Application.FunctionalTests.CustomerItems.Commands;
public class DeleteCustomerItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteCustomerItemCommand(0);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var itemId = await SendAsync(new CreateCustomerItemCommand
        {
            CustomerId = 0
        });

      

        await SendAsync(new DeleteCustomerItemCommand(itemId));

        var item = await FindAsync<Customer>(itemId);

        item.Should().BeNull();
    }
}
