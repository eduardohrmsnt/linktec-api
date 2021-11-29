using LinkTec.Api.Entities;
using LinkTec.Api.Interfaces;
using LinkTec.Api.Models;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LinkTec.Api.Services
{
    public class EmailService : IEmailService
    {
        private INotificador _notificador;
        private IEmailTemplateRepository _emailTemplateRepository;
        private string _usuario;
        private string _senha;

        public EmailService(INotificador notificador, IEmailTemplateRepository emailTemplateRepository, IOptions<Models.EmailTemplate> email)
        {
            _notificador = notificador;
            _emailTemplateRepository = emailTemplateRepository;
            _usuario = email.Value.Username;
            _senha = email.Value.Password;
        }
        public async Task EmailPropostaAceita(PropostaSolicitacao proposta, Parceiro parceiro)
        {
            var email = (await _emailTemplateRepository.Buscar(e => e.TipoEmail == ETipoEmail.PropostaAceita)).FirstOrDefault();

            MailMessage mailMessage = new MailMessage(_usuario, parceiro.Email);

            var str = email.Corpo;

            str.Replace("{PROPOSTAID}", proposta.Id.ToString());
            str.Replace("{NOME}", proposta.SolicitacaoDeServico.Solicitante.Nome);
            str.Replace("{EMAIL}", proposta.SolicitacaoDeServico.Solicitante.Email);

            mailMessage.Subject = $"{email.Assunto}";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"{str}";

            await EnviarEmail(mailMessage);
        }

        public async Task EmailPropostaRecusada(PropostaSolicitacao proposta, Parceiro parceiro)
        {
            var email = (await _emailTemplateRepository.Buscar(e => e.TipoEmail == ETipoEmail.PropostaRecusada)).FirstOrDefault();

            MailMessage mailMessage = new MailMessage(_usuario, parceiro.Email);

            var str = email.Corpo;

            str.Replace("{PROPOSTAID}", proposta.Id.ToString());
            str.Replace("{NOME}", proposta.SolicitacaoDeServico.Solicitante.Nome);

            mailMessage.Subject = $"{email.Assunto}";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"{str}";

            await EnviarEmail(mailMessage);
        }

        public async Task EmailSolicitacaoAceita(SolicitacaoDeServico solicitacao, Parceiro parceiro)
        {
            var email = (await _emailTemplateRepository.Buscar(e => e.TipoEmail == ETipoEmail.SolicitacaoAceita)).FirstOrDefault();

            MailMessage mailMessage = new MailMessage(_usuario, parceiro.Email);

            var str = email.Corpo;

            str.Replace("{SOLICITACAOID}", solicitacao.Id.ToString());
            str.Replace("{NOME}", solicitacao.Ofertante.Nome);
            str.Replace("{EMAIL}", solicitacao.Ofertante.Email);

            mailMessage.Subject = $"{email.Assunto}";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"{str}";

            await EnviarEmail(mailMessage);
        }

        public async Task EmailSolicitacaoRecusada(SolicitacaoDeServico solicitacao, Parceiro parceiro)
        {
            var email = (await _emailTemplateRepository.Buscar(e => e.TipoEmail == ETipoEmail.SolicitacaoRecusada)).FirstOrDefault();

            MailMessage mailMessage = new MailMessage(_usuario, parceiro.Email);

            var str = email.Corpo;

            str.Replace("{SOLICITACAOID}", solicitacao.Id.ToString());
            str.Replace("{NOME}", solicitacao.Ofertante.Nome);
            str.Replace("{EMAIL}", solicitacao.Ofertante.Email);

            mailMessage.Subject = $"{email.Assunto}";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"{str}";

            await EnviarEmail(mailMessage);
        }

        public async Task EnviarEmail(MailMessage mailMessage)
        {
            try
            {

                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_usuario, _senha);

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                _notificador.Handle(new Notificacao("Houve um erro no envio do email :("));
            }
        }
    }
}
