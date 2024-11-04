using System.ComponentModel.DataAnnotations;

namespace API.DTO.Request
{
    public class FeedbackRequest
    {
        [Range(1, 5, ErrorMessage = "A Avaliação deve ser de 1 a 5")]
        public int Avaliacao { get; set; }

        public string Comentario { get; set; }
    }
}
