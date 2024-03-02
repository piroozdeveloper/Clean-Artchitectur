using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CrudWebApi.Application.CustomerItems.EventHandlers;
public class CustomersItemCreatedEventHandler : INotificationHandler<CustomerItemCreatedEvent>
{
    private readonly ILogger<CustomersItemCreatedEventHandler> _logger;

    public CustomersItemCreatedEventHandler(ILogger<CustomersItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("crudWebApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
