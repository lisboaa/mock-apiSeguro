namespace Seguro.Dominio.Entidades
{
    public class Cartao
    {
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Cpf { get; set; }
        public DateTime? Validade { get; set; }
        public int Codigo { get; set; }
    }
}
