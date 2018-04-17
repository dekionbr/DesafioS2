using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Commands
{
    public class UpdateJogoCommand : JogoCommand
    {
        public UpdateJogoCommand(Guid id, string nome, string descricao, Guid AmigoId)
        {
            Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.AmigoId = AmigoId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
