namespace Database.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string NomeUsuario { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
