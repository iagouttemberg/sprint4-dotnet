using API.DTO.Request;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services.Email;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IEmailService _emailService;

        public UsuarioController(IRepository<Usuario> usuarioRepository, IEmailService emailService)
        {
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioRequest usuarioRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                NomeCompleto = usuarioRequest.NomeCompleto,
                NomeUsuario = usuarioRequest.NomeUsuario,
                DataNascimento = usuarioRequest.DataNascimento,
                Email = usuarioRequest.Email,
                Senha = usuarioRequest.Senha
            };

            _usuarioRepository.Add(usuario);

            // Envia o e-mail de boas-vindas após a criação do usuário
            var subject = "Bem-vindo(a)!";
            var body = $"Olá {usuario.NomeCompleto}, bem-vindo(a) ao nosso Projeto!";
            await _emailService.SendEmailAsync(usuario.Email, subject, body);

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UsuarioRequest usuarioRequest)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            usuario.NomeCompleto = usuarioRequest.NomeCompleto;
            usuario.NomeUsuario = usuarioRequest.NomeUsuario;
            usuario.DataNascimento = usuarioRequest.DataNascimento;
            usuario.Email = usuarioRequest.Email;
            usuario.Senha = usuarioRequest.Senha;

            _usuarioRepository.Update(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            _usuarioRepository.Delete(usuario);
            return NoContent();
        }
    }
}