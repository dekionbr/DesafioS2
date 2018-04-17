using AmigoCrud.S2.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Application.Interfaces
{
    public interface IAmigoAppService : IDisposable
    {
        void Register(AmigoViewModel customerViewModel);
        IEnumerable<AmigoViewModel> GetAll();
        AmigoViewModel GetById(Guid id);
        void Update(AmigoViewModel customerViewModel);
        void Remove(Guid id);
    }
}
