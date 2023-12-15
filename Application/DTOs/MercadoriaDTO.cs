using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class MercadoriaDTO
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "O nome é obrigatório preencher")]
        [MaxLength(100)]
        public string Nome { get; set; }

        public string NumeroRegistro { get;}
        [Required(ErrorMessage = "O Fabricante é obrigatório preencher")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório preencher")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatório preencher")]
        [MinLength(20)]
        public string Descricao { get; set; }
    }
}
