using api_filmes_senai.Domains;
using api_filmes_senai.Interface;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        /// <summary>
        /// Endpoint para cadastrar Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>



        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para Buscar por Id de Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return null;

                 }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
      
        }

        //BuscarPorEmailESenha (Login)

        
    }
    
}
