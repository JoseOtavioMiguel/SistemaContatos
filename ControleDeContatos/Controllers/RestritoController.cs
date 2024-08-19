using ControleDeContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaParaUsuarioLogado]

        public IActionResult Index()
        {
            return View();
        }
    }
}
