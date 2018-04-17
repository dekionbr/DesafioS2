using AmigoCrud.S2.Domain.Bus;
using AmigoCrud.S2.Domain.Commands;
using AmigoCrud.S2.Domain.Events;
using AmigoCrud.S2.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace AmigoCrud.S2.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
      
            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}
