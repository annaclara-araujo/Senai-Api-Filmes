using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filme_Context _context;
        
        public FilmeRepository (Filme_Context contexto)
        {
            _context = contexto;
        }


        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filme.Titulo;
                    filmeBuscado.IdGenero = filme.IdGenero;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            throw new NotImplementedException();
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastar(Filme novoFilme)
        {
            try
            {
                _context.Filme.Add(novoFilme);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null)
                {
                    _context.Filme.Remove(filmeBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> ListaPorGenero(Guid idGenero)
        {
            try
            {
                List<Filme> listaDeFilmes = (List<Filme>)_context.Filme
                    .Include(g => g.Genero)
                    .Where (f => f.IdGenero == idGenero)
                    .ToList();
                return listaDeFilmes;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public List<Filme> listaPorGenero (Guid idGenero)
        {

         
            List<Filme> listaPorGenero = _context.Filme.ToList();
            return listaPorGenero;

        }







    }
}
