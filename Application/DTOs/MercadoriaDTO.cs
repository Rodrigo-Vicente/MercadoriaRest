using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class MercadoriaDTO
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "O nome é obrigatório preencher")]
        [MaxLength(100)]
        public string Nome { get; set; }

        public string NumeroRegistro { get { return GerarRegistro(); } }
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

        private string GerarRegistro()
        {
            // Lógica para gerar um número de registro
            // Aqui estou usando um exemplo que encontrei na internet usando DateTime + um número aleatório
            return $"{DateTime.Now:yyyyMMddHHmmss}-{new Random().Next(0000, 9999)}";
        }
    }
}
