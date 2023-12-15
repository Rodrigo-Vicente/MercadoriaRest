using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class EntradaMercadoriaDTO
    {
        public int id { get; set; }
        public int MercadoriaId { get; set; }
        [Required(ErrorMessage = "A Quantida de Entrada é obrigatório preencher")]
        public int QuantidadeEntrada { get; set; }
        [Required(ErrorMessage = "A Data Hora é obrigatório preencher")]
        public DateTime DataHora { get; set; }
        [Required(ErrorMessage = "O local é obrigatório preencher")]
        [MaxLength(255)]
        public string Local { get; set; }
    }
}
