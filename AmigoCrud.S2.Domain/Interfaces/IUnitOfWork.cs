using AmigoCrud.S2.Domain.Commands;
using System;

namespace AmigoCrud.S2.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
