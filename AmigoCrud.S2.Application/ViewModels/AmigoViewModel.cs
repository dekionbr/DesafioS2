using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmigoCrud.S2.Application.ViewModels
{
    public class AmigoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatorio")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Endereço Obrigatório")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
    }
}
