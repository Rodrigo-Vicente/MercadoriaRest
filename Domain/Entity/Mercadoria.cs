namespace Domain.Entity
{
    public class Mercadoria : Entity
    {
        public string Nome { get; set; }
        public string NumeroRegistro { get; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public ICollection<EntradaMercadoria> Entradas { get; set; }
        public ICollection<SaidaMercadoria> Saidas { get; set; }
    }
}
