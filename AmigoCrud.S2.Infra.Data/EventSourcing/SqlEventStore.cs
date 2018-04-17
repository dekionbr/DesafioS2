using AmigoCrud.S2.Domain.Interfaces;
using Newtonsoft.Json;

namespace AmigoCrud.S2.Infra.Data.EventSourcing
{
    //public class SqlEventStore : IEventStore
    //{
    //    private readonly IEventStoreRepository _eventStoreRepository;
    //    private readonly IUser _user;

    //    public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
    //    {
    //        _eventStoreRepository = eventStoreRepository;
    //        _user = user;
    //    }

    //    public void Save<T>(T theEvent) where T : Event
    //    {
    //        var serializedData = JsonConvert.SerializeObject(theEvent);

    //        var storedEvent = new StoredEvent(
    //            theEvent,
    //            serializedData,
    //            _user.Name);

    //        _eventStoreRepository.Store(storedEvent);
    //    }
    //}
}