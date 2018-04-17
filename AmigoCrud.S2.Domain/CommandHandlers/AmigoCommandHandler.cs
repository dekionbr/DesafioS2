using AmigoCrud.S2.Domain.Bus;
using AmigoCrud.S2.Domain.Commands;
using AmigoCrud.S2.Domain.Events;
using AmigoCrud.S2.Domain.Interfaces;
using AmigoCrud.S2.Domain.Models;
using AmigoCrud.S2.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AmigoCrud.S2.Domain.CommandHandlers
{
    public class AmigoCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewAmigoCommand>,
        INotificationHandler<UpdateAmigoCommand>,
        INotificationHandler<RemoveAmigoCommand>
    {
        private readonly IAmigoRepository _amigoRepository;
        private readonly IMediatorHandler Bus;

        public AmigoCommandHandler(IAmigoRepository amigoRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _amigoRepository = amigoRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewAmigoCommand message, CancellationToken cancellation)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var Amigo = new Amigo(Guid.NewGuid(), message.Nome, message.Endereco);

            if (_amigoRepository.GetById(Amigo.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Erro ao tentar inserir a entidade"));
                return Unit.Task;
            }

            _amigoRepository.Add(Amigo);

            if (Commit())
            {
                Bus.RaiseEvent(new AmigoRegisteredEvent(Amigo.Id, Amigo.Nome, Amigo.Endereco));
            }

            return Unit.Task;
        }

        public Task Handle(UpdateAmigoCommand message, CancellationToken cancellation)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            //var Amigo = new Amigo(message.Id, message.Nome, message.Endereco);
            var amigo = _amigoRepository.GetById(message.Id);

            //if (existingAmigo != null && existingAmigo.Id != Amigo.Id)
            //{
            //    if (!existingAmigo.Equals(Amigo))
            //    {
            //        Bus.RaiseEvent(new DomainNotification(message.MessageType, "Erro ao realizar o update da entidade"));
            //        return Unit.Task;
            //    }
            //}

            amigo.Endereco = message.Endereco;
            amigo.Nome = message.Nome;


            _amigoRepository.Update(amigo);

            if (Commit())
            {
                Bus.RaiseEvent(new AmigoUpdatedEvent(amigo.Id, amigo.Nome, amigo.Endereco));
            }

            return Unit.Task;
        }

        public Task Handle(RemoveAmigoCommand message, CancellationToken cancellation)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            _amigoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new AmigoRemovedEvent(message.Id));
            }

            return Unit.Task;
        }

        public void Dispose()
        {
            _amigoRepository.Dispose();
        }
    }
}
