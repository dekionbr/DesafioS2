using System;
using System.Linq;
using AmigoCrud.S2.Domain.Interfaces;
using AmigoCrud.S2.Domain.Models;
using AmigoCrud.S2.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AmigoCrud.S2.Infra.Data.Repository
{
    public class JogoRepository : Repository<Jogo>, IJogoRepository
    {
        public JogoRepository(AmigoCrudContext context)
            : base(context)
        {

        }

        public IQueryable<Jogo> GetByAmigoId(Guid id)
        {
            return DbSet.AsNoTracking().Where(c => c.Amigo.Id == id);
        }

        public Jogo GetByName(string nome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Nome.StartsWith(nome));
        }
    }
}
