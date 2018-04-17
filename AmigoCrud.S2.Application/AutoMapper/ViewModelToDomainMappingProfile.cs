using AmigoCrud.S2.Application.ViewModels;
using AmigoCrud.S2.Domain.Commands;
using AutoMapper;

namespace AmigoCrud.S2.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<JogoViewModel, RegisterNewJogoCommand>()
                .ConstructUsing(c => new RegisterNewJogoCommand(c.Nome, c.Descricao, c.AmigoId));
            CreateMap<JogoViewModel, UpdateJogoCommand>()
                .ConstructUsing(c => new UpdateJogoCommand(c.Id, c.Nome, c.Descricao, c.AmigoId));

            CreateMap<AmigoViewModel, RegisterNewAmigoCommand>()
                .ConstructUsing(c => new RegisterNewAmigoCommand(c.Nome, c.Endereco));
            CreateMap<AmigoViewModel, UpdateAmigoCommand>()
                .ConstructUsing(c => new UpdateAmigoCommand(c.Id, c.Nome, c.Endereco));
        }
    }
}
