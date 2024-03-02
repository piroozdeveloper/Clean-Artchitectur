using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApi.Domain.Events;

public class CustomerItemDeletedEvent : BaseEvent
{
    public CustomerItemDeletedEvent(Customer item)
    {
        Item = item;
    }

    public Customer Item { get; }
}
