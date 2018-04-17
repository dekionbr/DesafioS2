using AmigoCrud.S2.Application.Interfaces;
using AmigoCrud.S2.Application.ViewModels;
using AmigoCrud.S2.Domain.Bus;
using AmigoCrud.S2.Domain.CommandHandlers;
using AmigoCrud.S2.Domain.Commands;
using AmigoCrud.S2.Domain.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;

namespace AmigoCrud.S2.Application.Services
{
    public class JogoAppService : IJogoAppService
    {
        private readonly IMapper _mapper;
        private readonly IJogoRepository _jogoRepository;
        private readonly IMediatorHandler Bus;

        public JogoAppService(IMapper mapper,
                                  IJogoRepository jogoRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _jogoRepository = jogoRepository;
            Bus = bus;
        }

        public IEnumerable<JogoViewModel> GetAll()
        {
            return _jogoRepository.GetAll().ProjectTo<JogoViewModel>();
        }

        public JogoViewModel GetById(Guid id)
        {
            return _mapper.Map<JogoViewModel>(_jogoRepository.GetById(id));
        }

        public void Register(JogoViewModel JogoViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewJogoCommand>(JogoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(JogoViewModel JogoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateJogoCommand>(JogoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveJogoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public object GetByAmigoId(Guid id)
        {
            return _jogoRepository.GetByAmigoId(id).ProjectTo<JogoViewModel>();
        }
    }
}
