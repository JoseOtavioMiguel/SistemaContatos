using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Usuarios()
        {
            return View();
        }


        public IActionResult CriarUsuario()
        {
            return View();
        }



        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }


        public IActionResult EditarUsuario(int id)
        {

            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }


        public IActionResult ApagarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }


        public IActionResult Apagar(int id)
        {

            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Erro ao apagar o usuário.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o usuário, tente novamente, DETALHE DO ERRO: {erro.Message}";

                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public IActionResult EditarUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Falha ao atualizar o usuário. DETALHE DO ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                {
                    TempData["MensagemErro"] = $"Não foi possível Cadastrar o usuário, tente novamente, DETALHE DO ERRO: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }
    }

}
