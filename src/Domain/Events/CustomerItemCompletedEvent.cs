using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApi.Domain.Events;
public class CustomerItemCompletedEvent : BaseEvent
{
    public CustomerItemCompletedEvent(Customer item)
    {
        Item = item;
    }

    public Customer Item { get; }
}

