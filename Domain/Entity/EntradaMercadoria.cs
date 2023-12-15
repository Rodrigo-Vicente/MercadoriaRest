namespace Domain.Entity
{
    public  class EntradaMercadoria : Entity
    {
        public int MercadoriaId { get; set; }
        public int QuantidadeEntrada { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public Mercadoria Mercadoria { get; set; }
    }
}
