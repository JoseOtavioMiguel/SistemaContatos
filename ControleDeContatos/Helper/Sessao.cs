using ControleDeContatos.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            /*
                try
                {
                    return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
                }
                catch (JsonException jsonError)
                {
                    Console.WriteLine($"DETALHES DO ERRO : {jsonError}");
                    return null;
                }
            */
            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
         
        }

        void ISessao.CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonSerializer.Serialize(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        void ISessao.RemoveSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");

        }
    }
}
