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
    public class JogoCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewJogoCommand>,
        INotificationHandler<UpdateJogoCommand>,
        INotificationHandler<RemoveJogoCommand>
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IAmigoRepository _amigoRepository;
        private readonly IMediatorHandler Bus;

        public JogoCommandHandler(IJogoRepository jogoRepository,
                                  IAmigoRepository amigoRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _jogoRepository = jogoRepository;
            _amigoRepository = amigoRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewJogoCommand message, CancellationToken cancellation)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var jogo = new Jogo(Guid.NewGuid(), message.Nome, message.Descricao);

            if (_jogoRepository.GetById(jogo.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Erro ao tentar inserir a entidade"));
                return Unit.Task;
            }



            if (message.AmigoId != null)
                jogo.Amigo = _amigoRepository.GetById(message.AmigoId);

            _jogoRepository.Add(jogo);

            if (Commit())
            {
                Bus.RaiseEvent(new AmigoRegisteredEvent(jogo.Id, jogo.Nome, jogo.Descricao));
            }

            return Unit.Task;
        }

        public Task Handle(UpdateJogoCommand message, CancellationToken cancellation)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            //var jogo = new Jogo(message.Id, message.Nome, message.Descricao);
            var jogo = _jogoRepository.GetById(message.Id);

            if (jogo == null)
            {
                jogo = new Jogo(message.Id, message.Nome, message.Descricao);
            }

            //if (existingjogo != null && existingjogo.Id != jogo.Id)
            //{
            //    if (!existingjogo.Equals(jogo))
            //    {
            //        Bus.RaiseEvent(new DomainNotification(message.MessageType, "Erro ao realizar o update da entidade"));
            //        return Unit.Task;
            //    }
            //}
            
            if (message.AmigoId != null)
                jogo.Amigo = _amigoRepository.GetById(message.AmigoId);

            jogo.Descricao = message.Descricao;
            jogo.Nome = message.Nome;

            _jogoRepository.Update(jogo);

            if (Commit())
            {
                Bus.RaiseEvent(new AmigoUpdatedEvent(jogo.Id, jogo.Nome, jogo.Descricao));
            }

            return Unit.Task;
        }

        public Task Handle(RemoveJogoCommand message, CancellationToken cancellation)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            _jogoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new AmigoRemovedEvent(message.Id));
            }

            return Unit.Task;
        }

        public void Dispose()
        {
            _jogoRepository.Dispose();
        }
    }
}
