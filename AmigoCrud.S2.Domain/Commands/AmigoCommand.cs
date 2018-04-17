using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Commands
{
    public abstract class AmigoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Endereco { get; protected set; }
    }
}
