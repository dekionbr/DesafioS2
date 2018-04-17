using AmigoCrud.S2.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Application.Interfaces
{
    public interface IJogoAppService : IDisposable
    {
        void Register(JogoViewModel customerViewModel);
        IEnumerable<JogoViewModel> GetAll();
        JogoViewModel GetById(Guid id);
        void Update(JogoViewModel customerViewModel);
        void Remove(Guid id);
        object GetByAmigoId(Guid id);
    }
}
