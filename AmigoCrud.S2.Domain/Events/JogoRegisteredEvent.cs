using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Domain.Events
{
    public class JogoRegisteredEvent : Event
    {
        public JogoRegisteredEvent(Guid id, string nome, string descricao, string amigoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.amigoId = amigoId;

        }

        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string amigoId { get; private set; }
    }
}
