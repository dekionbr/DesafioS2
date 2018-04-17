using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Commands
{
    public class RemoveJogoCommand : JogoCommand
    {
        public RemoveJogoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
