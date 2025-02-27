﻿using api_filmes_senai.Domains;
using api_filmes_senai.Interface;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("appication/json")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

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


        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }


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

        [HttpGet ("{idGenero}")]
        public IActionResult Get(Guid idGenero)
        {
            try
            {
                List<Filme> listaPorGenero = _filmeRepository.Listar();

                return Ok(listaPorGenero);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }

        }







    }
}
