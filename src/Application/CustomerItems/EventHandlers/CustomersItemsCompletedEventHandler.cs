using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CrudWebApi.Application.CustomerItems.EventHandlers;
public class CustomersItemsCompletedEventHandler : INotificationHandler<CustomerItemCompletedEvent>
{
    private readonly ILogger<CustomersItemsCompletedEventHandler> _logger;

    public CustomersItemsCompletedEventHandler(ILogger<CustomersItemsCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CrudWebApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
