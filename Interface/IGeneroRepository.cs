using api_filmes_senai.Domains;

namespace api_filmes_senai.Interface
{
    /// <summary>
    /// Interface para Genero, contrato
    /// Toda classe que herdadar (implementar) essa interface, deverá implementar os métodos definidos aqui dentro
    /// </summary>
    public interface IGeneroRepository
    {
        /// CRUD : Metodos
        /// C - Create : Cadastrar um novo Objeto
        /// R - Read : Listar todos os Objetos
        /// U - Update : Alterarr um Objeto
        /// D - Delete : Deleto ou excluo um Objeto

        /// Método = TipoDeRetorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar (Guid id, Genero novoGenero);

        void Deletar ( Guid id );

        Genero BuscarPorId ( Guid id );



    }
}
