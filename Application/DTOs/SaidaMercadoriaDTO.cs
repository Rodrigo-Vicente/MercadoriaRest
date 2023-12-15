using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class SaidaMercadoriaDTO
    {
        public int id { get; set; }
        public int MercadoriaId { get; set; }
        [Required(ErrorMessage = "A Quantida de retirada é obrigatório preencher")]
        public int QuantidadeRetirada { get; set; }

        [Required(ErrorMessage = "A Data é obrigatório preencher")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O local é obrigatório preencher")]
        [MaxLength(255)]
        public string Local { get; set; }
    }
}
