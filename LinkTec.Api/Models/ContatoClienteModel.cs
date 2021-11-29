using LinkTec.Api.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LinkTec.Api.Models
{
    public class ContatoClienteModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Mensagem { get; set; }

        internal static ContatoCliente ToContatoClienteEntity(ContatoClienteModel contatoCliente)
        {
            return new ContatoCliente
            {
                Email = contatoCliente.Email,
                Mensagem = contatoCliente.Mensagem,
                Telefone = contatoCliente.Telefone
            };
        }
    }
}
