using System;

namespace AmigoCrud.S2.Domain.Models
{
    public class Amigo: EntityBase
    {
        public Amigo()
        {}

        public Amigo(Guid id, string nome, string endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;

        }
        public string Nome { get; set; }

        public string Endereco { get; set; }
    }
}
