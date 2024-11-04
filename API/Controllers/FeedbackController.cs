using API.DTO.Request;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IRepository<Feedback> _feedbackRepository;

        public FeedbackController(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // GET: api/feedback
        [HttpGet]
        public IActionResult GetAll()
        {
            var feedbacks = _feedbackRepository.GetAll();
            return Ok(feedbacks);
        }

        // GET: api/feedback/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var feedback = _feedbackRepository.GetById(id);

            if (feedback == null)
            {
                return NotFound("Feedback não encontrado.");
            }

            return Ok(feedback);
        }

        // POST: api/feedback
        [HttpPost]
        public IActionResult Create([FromBody] FeedbackRequest feedbackRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = new Feedback
            {
                Avaliacao = feedbackRequest.Avaliacao,
                Comentario = feedbackRequest.Comentario,
                DataPublicacao = DateTime.Now
            };

            _feedbackRepository.Add(feedback);

            return CreatedAtAction(nameof(GetById), new { id = feedback.Id }, feedback);
        }

        // PUT: api/feedback/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FeedbackRequest feedbackRequest)
        {
            var feedback = _feedbackRepository.GetById(id);

            if (feedback == null)
            {
                return NotFound("Feedback não encontrado.");
            }

            feedback.Avaliacao = feedbackRequest.Avaliacao;
            feedback.Comentario = feedbackRequest.Comentario;

            _feedbackRepository.Update(feedback);

            return NoContent(); // 204 No Content
        }

        // DELETE: api/feedback/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var feedback = _feedbackRepository.GetById(id);

            if (feedback == null)
            {
                return NotFound("Feedback não encontrado.");
            }

            _feedbackRepository.Delete(feedback);

            return NoContent();
        }
    }
}
