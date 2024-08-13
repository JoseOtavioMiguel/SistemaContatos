using System;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        // Define os atributos do Contato
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}