namespace API.DTO.Request
{
    public class UsuarioRequest
    {
        public string NomeCompleto { get; set; }

        public string NomeUsuario { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
