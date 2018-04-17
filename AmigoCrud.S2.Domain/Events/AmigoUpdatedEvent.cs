using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Events
{
    public class AmigoUpdatedEvent : Event
    {
        public AmigoUpdatedEvent(Guid id, string nome, string endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }
    }
}
