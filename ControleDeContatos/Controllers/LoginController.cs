using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {

        private IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public IActionResult Index()
        {
            // Se usuário estiver logado redirecionar para a home

            if(_sessao.BuscarSessaoDoUsuario() !=  null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoDoUsuario();
            return RedirectToAction("Index", "Login");

        }

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao; 
        }



        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Contato");
                        }
                        
                        TempData["MensagemErro"] = $"Senha do usuário inválida, tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usuario e/ou senha inválido(s). Por favor, tente novamente.";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o Login, tente novamente. DETALHES DO ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
