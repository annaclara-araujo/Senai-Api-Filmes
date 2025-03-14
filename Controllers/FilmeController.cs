﻿using api_filmes_senai.Domains;
using api_filmes_senai.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {

        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        /// <summary>
        /// Endpoint para lisra filmes 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilme = _filmeRepository.Listar();

                return Ok(listaDeFilme);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }

        }

        /// <summary>
        /// Endpoint para cadastrar novo Filme
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }

        /// <summary>
        /// Endpoint para deletar filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [Authorize]
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {

            try
            {
                _filmeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Endpoint para Atualizar filme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filme"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para bucar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);
                return Ok(filmeBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }

        /// <summary>
        /// Endpoint para Bucar por Genero
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("ListarPorGenero/{Id}")]
        public IActionResult GetByGenero(Guid Id)
        {
            try
            {
                List<Filme> ListarPorGenero = _filmeRepository.ListarPorGenero(Id);
                return Ok(ListarPorGenero);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }

        }
    }
}
