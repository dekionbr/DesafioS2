using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Commands
{
    public abstract class JogoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid AmigoId { get; protected set; }
    }
}
