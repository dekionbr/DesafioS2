namespace AmigoCrud.S2.Domain.Commands
{
    public class RegisterNewAmigoCommand : AmigoCommand
    {
        public RegisterNewAmigoCommand(string nome, string endereco)
        {
            this.Nome = nome;
            this.Endereco = endereco;            
        }

        public override bool IsValid()
        {
            //Add fluent Validate
            return true;
        }
    }
}
