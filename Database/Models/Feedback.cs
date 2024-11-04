namespace Database.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int Avaliacao { get; set; }

        public string Comentario { get; set; }

        public DateTime DataPublicacao { get; set; } = DateTime.Now;
    }
}
