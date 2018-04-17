using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Events
{
    public class AmigoRegisteredEvent : Event
    {
        public AmigoRegisteredEvent(Guid id, string nome, string endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
        }

        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
    }
}
