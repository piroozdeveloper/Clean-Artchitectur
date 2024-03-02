using CrudWebApi.Application.Common.Models;
using CrudWebApi.Application.CustomerItems.Commands.CreateCustomerItem;
using CrudWebApi.Application.CustomerItems.Commands.DeleteCustomerItem;
using CrudWebApi.Application.CustomerItems.Commands.UpdateCustomerItem;
using CrudWebApi.Application.CustomerItems.Commands.UpdateCustomerItemDetail;
using CrudWebApi.Application.CustomerItems.Queries.GetCustomerItemsWithCustomerID;

namespace CrudWebApi.Web.Endpoints;

public class CustomerItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapGet(GetCustomerItemsWithCustomerID)
            .MapPost(CreateCustomerItem)
            .MapPut(UpdateCustomerItem, "{Customerid}")
            .MapPut(UpdateCustomerItemDetail, "UpdateDetail/{Customerid}")
            .MapDelete(DeleteCustomerItem, "{Customerid}");
    }

    public Task<PaginatedList<CustomerItemsBriefDto>> GetCustomerItemsWithCustomerID(ISender sender, [AsParameters] GetCustomerItemsWithCustomerIDQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateCustomerItem(ISender sender, CreateCustomerItemCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateCustomerItem(ISender sender, int CustomerId, UpdateCustomerItemCommand command)
    {
        if (CustomerId != command.CustomerId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateCustomerItemDetail(ISender sender, int CustomerId, UpdateCustomerItemDetailCommand command)
    {
        if (CustomerId != command.CustomerId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteCustomerItem(ISender sender, int customerId)
    {
        await sender.Send(new DeleteCustomerItemCommand(customerId));
        return Results.NoContent();
    }
}

