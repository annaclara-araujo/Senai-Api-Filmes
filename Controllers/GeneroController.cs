using api_filmes_senai.Domains;
using api_filmes_senai.Interface;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        /// <summary>
        /// Endpoint para Listar Genero
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }
        /// <summary>
        /// Endpoint para cadastrar novo Genro
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]

        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }

        }
        /// <summary>
        /// Endpoint para deletar genero cadastrado
        /// </summary>
        /// <param name="id">Id do Genero</param>
        /// <returns>null</returns>

        [Authorize]
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {

            try
            {
                _generoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Endpoint para Atualizar genero cadastrado
        /// </summary>
        /// <param name="id"> Id do Genero</param>
        /// <param name="genero"> Genero cadastrado</param>
        /// <returns> Atualização do Genero </returns>

       
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um Gênero pelo seu id
        /// </summary>
        /// <param name="id"> Id do Genero Buscado</param>
        /// <returns>Genero Buscado<returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
               Genero generoBuscado = _generoRepository.BuscarPorId(id);
                return Ok(generoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }


    }
}
