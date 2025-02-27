﻿using api_filmes_senai.Domains;

namespace api_filmes_senai.Interface
{
    public interface IFilmeRepository
    {

        void Cadastar(Filme novoFilme);

        List<Filme> Listar();
        void Atualizar(Guid id, Filme filme);
        void Deletar(Guid id);
        Filme BuscarPorId(Guid id);
        
        List<Filme> ListarPorGenero (Guid idGenero);
        List<Filme> ListaPorGenero(Guid idGenero);
    }
}
