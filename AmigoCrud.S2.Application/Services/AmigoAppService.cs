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
    public class AmigoAppService : IAmigoAppService
    {
        private readonly IMapper _mapper;
        private readonly IAmigoRepository _amigoRepository;
        private readonly IMediatorHandler Bus;

        public AmigoAppService(IMapper mapper,
                                  IAmigoRepository amigoRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _amigoRepository = amigoRepository;
            Bus = bus;            
        }

        public IEnumerable<AmigoViewModel> GetAll()
        {
            return _amigoRepository.GetAll().ProjectTo<AmigoViewModel>();
        }

        public AmigoViewModel GetById(Guid id)
        {
            return _mapper.Map<AmigoViewModel>(_amigoRepository.GetById(id));
        }

        public void Register(AmigoViewModel AmigoViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewAmigoCommand>(AmigoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(AmigoViewModel AmigoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAmigoCommand>(AmigoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveAmigoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
