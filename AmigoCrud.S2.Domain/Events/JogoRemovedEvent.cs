using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Events
{
    public class JogoRemovedEvent : Event
    {
        public JogoRemovedEvent(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
