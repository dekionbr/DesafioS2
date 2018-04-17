using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Commands
{
    public class UpdateAmigoCommand : AmigoCommand
    {
        public UpdateAmigoCommand(Guid id, string nome, string endereco)
        {
            Id = id;
            this.Nome = nome;
            this.Endereco = endereco;            
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
