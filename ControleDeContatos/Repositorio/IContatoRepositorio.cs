﻿using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    // Definição dos métodos utilizados na aplicação
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);

    }
}
