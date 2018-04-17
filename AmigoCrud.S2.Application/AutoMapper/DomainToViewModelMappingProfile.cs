using AmigoCrud.S2.Application.ViewModels;
using AmigoCrud.S2.Domain.Models;
using AutoMapper;

namespace AmigoCrud.S2.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Jogo, JogoViewModel>();
            CreateMap<Amigo, AmigoViewModel>();
        }
    }
}
