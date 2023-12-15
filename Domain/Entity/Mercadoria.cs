namespace Domain.Entity
{
    public class Mercadoria : Entity
    {
        public string Nome { get; set; }
        public string NumeroRegistro { get { return GerarRegistro(); } }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public ICollection<EntradaMercadoria> Entradas { get; set; }
        public ICollection<SaidaMercadoria> Saidas { get; set; }

        private string GerarRegistro()
        {
            // Lógica para gerar a ordem de serviço automaticamente
            // Aqui estou usando um exemplo que encontrei na internet usando DateTime + um número aleatório
            return $"{DateTime.Now:yyyyMMddHHmmss}-{new Random().Next(0000, 9999)}";
        }
    }
}
