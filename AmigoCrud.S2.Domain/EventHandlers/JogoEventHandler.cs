using AmigoCrud.S2.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AmigoCrud.S2.Domain.EventHandlers
{
    public class JogoEventHandler :
        INotificationHandler<JogoRegisteredEvent>,
        INotificationHandler<JogoUpdatedEvent>,
        INotificationHandler<JogoRemovedEvent>
    {
        public Task Handle(JogoUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Unit.Task;
        }

        public Task Handle(JogoRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            return Unit.Task;
        }

        public Task Handle(JogoRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            return Unit.Task;
        }
    }
}
