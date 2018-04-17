using AmigoCrud.S2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmigoCrud.S2.Domain.Interfaces
{
    public interface IJogoRepository: IRepository<Jogo>
    {
        Jogo GetByName(string nome);
        IQueryable<Jogo> GetByAmigoId(Guid id);
    }
}
