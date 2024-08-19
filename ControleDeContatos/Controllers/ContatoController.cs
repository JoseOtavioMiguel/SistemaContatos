using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]

    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;



            // Define os métodos GET da aplicação

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Contatos()
        {
            return View();
        }


        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }


        public IActionResult CriarContato()
        {
            return View();
        }


        // Seleciona os dados cadastrados por meio do Id e retorna a View contendo os Dados preenchidos

        public IActionResult EditarContato(int id)
        {

            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }


        public IActionResult ApagarContato(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }


        public IActionResult Apagar(int id)
        {

            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Erro ao apagar o contato.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o contato, tente novamente, DETALHE DO ERRO: {erro.Message}";

                    return RedirectToAction("Index");
                }
            }
        }

        //Define os métodos POST da aplicação

        // Aciona o método Adicionar para adicionar o cadastro no Banco de Dados

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                {
                    TempData["MensagemErro"] = $"Não foi possível Cadastrar o contato, tente novamente, DETALHE DO ERRO: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }

        // Aciona o metodo atualizar para alterar os dados no Banco de Dados

        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Falha ao atualizar o contato. DETALHE DO ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}

