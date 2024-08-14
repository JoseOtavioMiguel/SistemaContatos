using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
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


        public IActionResult ApagarContato()
        {
            return View();
        }


            //Define os métodos POST da aplicação
        
        // Aciona o método Adicionar para adicionar o cadastro no Banco de Dados
        
        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }


        // Aciona o metodo atualizar para alterar os dados no Banco de Dados

        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

    }
}
