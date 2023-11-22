namespace Seguro.Dominio.Entidades
{
    public class Cliente
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Profissao { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? DataNascimento { get; set; }
        public bool Autonomo { get; set; }
        public bool Clt { get; set; }

        public int Idade { get; set; }
    }
}
