using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        // Recebe o Id do cadastro pela View e retorna o valor 
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoRepositorio(BancoContext bancoContent)
        {
            this._bancoContext = bancoContent;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        // Faz a listagem dos cadastros do Banco de Dados
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }


        // Método que atualiza as informações de cadastro no Banco de Dados
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }
    }
}
