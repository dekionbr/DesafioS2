using System;

namespace AmigoCrud.S2.Domain.Commands
{
    public class RegisterNewJogoCommand : JogoCommand
    {
        public RegisterNewJogoCommand(string nome, string descricao, Guid amigoId)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.AmigoId = amigoId;
        }

        public override bool IsValid()
        {
            // add fluent validate
            return true;
        }
    }
}
