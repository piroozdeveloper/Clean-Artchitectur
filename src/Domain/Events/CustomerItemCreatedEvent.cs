using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApi.Domain.Events;
public class CustomerItemCreatedEvent : BaseEvent
{
    public CustomerItemCreatedEvent(Customer item)
    {
        Item = item;
    }

    public Customer Item { get; }
}

