using AmigoCrud.S2.Domain.Interfaces;
using AmigoCrud.S2.Domain.Models;
using AmigoCrud.S2.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Infra.Data.Repository
{
    public class AmigoRepository : Repository<Amigo>, IAmigoRepository
    {
        public AmigoRepository(AmigoCrudContext context)
            : base(context)
        {
        }
    }
}
