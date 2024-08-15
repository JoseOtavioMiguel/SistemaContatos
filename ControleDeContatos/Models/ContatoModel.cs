using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        // Define os atributos do Contato

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }

        // Solicita ao usuario o preenchimento dos dados, caso o submit esteja vazio
        [Required(ErrorMessage = "Digite o Email do contato")]       
        [EmailAddress(ErrorMessage = "O e-mail informado n�o � v�lido!")]
        public string Email { get; set; }

        // Emite uma mensagem abaixo do text-box, informando ao usu�rio que o n�mero n�o � valido
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage ="O celular informado n�o � v�lido!")]   
        public string Celular { get; set; }

    }
}