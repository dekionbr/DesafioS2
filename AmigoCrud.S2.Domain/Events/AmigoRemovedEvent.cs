using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Events
{
    public class AmigoRemovedEvent : Event
    {
        public AmigoRemovedEvent(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
