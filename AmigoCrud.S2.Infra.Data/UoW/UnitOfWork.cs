using AmigoCrud.S2.Domain.Commands;
using AmigoCrud.S2.Domain.Interfaces;
using AmigoCrud.S2.Infra.Data.Context;

namespace AmigoCrud.S2.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AmigoCrudContext _context;

        public UnitOfWork(AmigoCrudContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
