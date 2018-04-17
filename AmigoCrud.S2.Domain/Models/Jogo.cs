using System;

namespace AmigoCrud.S2.Domain.Models
{
    public class Jogo : EntityBase
    {
        public Jogo()
        {

        }

        public Jogo(Guid id, string nome, string descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;            
        }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Amigo Amigo { get; set; }
    }
}
