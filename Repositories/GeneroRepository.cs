using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interface;

namespace api_filmes_senai.Repositories
{

    /// <summary>
    /// Classe que vai implementar a interfaxe IGeneroRepository
    /// Ou seja, vamos implementar as metodos, toda a logica dos metodos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// Variavél privada é somente leitura que guarda 
        /// </summary>



        private readonly Filme_Context _context;
       

        /// <summary>
        /// Construtor de repositório4
        /// Aqui, toda vez que o contrutor for chamado, os dados do contexto estaram diponíveis
        /// </summary>
        /// <param name="contexto"></param>
        public GeneroRepository(Filme_Context contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Guid id, Genero novoGenero)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    generoBuscado.Nome = novoGenero.Nome;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Genero BuscarPorId(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;
                return generoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">objeto genero a ser cadastrado</param>
        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                //adiciona um novo genero na tabela Generos (BD)
                _context.Genero.Add(novoGenero);

                //Apos o cadastro, salva as alteracoes (BD)
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // ctrl + k + D = organizar codigo
        //

        public void Deletar(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    _context.Genero.Remove(generoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Genero> Listar()
        {
            try
            {
                List<Genero> ListaGeneros = _context.Genero.ToList();
                return ListaGeneros;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
