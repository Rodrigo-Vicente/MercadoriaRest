namespace Domain.Entity
{
    public class SaidaMercadoria : Entity
    {
        public int MercadoriaId { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public int QuantidadeRetirada { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
    }
}
