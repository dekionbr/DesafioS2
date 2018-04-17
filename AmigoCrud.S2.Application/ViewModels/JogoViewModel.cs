using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmigoCrud.S2.Application.ViewModels
{
    public class JogoViewModel
    {
        public JogoViewModel()
        {
            this.Amigos = new List<AmigoViewModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatória")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Amigo")]
        public Guid AmigoId { get; set; }

        public IEnumerable<AmigoViewModel> Amigos { get; set; }
    }
}
