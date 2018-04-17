using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Events
{
    public class JogoUpdatedEvent : Event
    {
        public JogoUpdatedEvent(Guid id, string nome, string descricao, string amigoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.AmigoId = amigoId;
        }

        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string AmigoId { get; private set; }
    }
}
