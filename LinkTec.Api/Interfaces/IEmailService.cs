using LinkTec.Api.Entities;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LinkTec.Api.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmail(MailMessage mailMessage);

        Task EmailPropostaAceita(PropostaSolicitacao proposta, Parceiro parceiro);

        Task EmailPropostaRecusada(PropostaSolicitacao proposta, Parceiro parceiro);

        Task EmailSolicitacaoAceita(SolicitacaoDeServico solicitacao, Parceiro parceiro);

        Task EmailSolicitacaoRecusada(SolicitacaoDeServico solicitacao, Parceiro parceiro);
    }
}
