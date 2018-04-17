using AmigoCrud.S2.Domain.Events;

namespace AmigoCrud.S2.Domain.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
