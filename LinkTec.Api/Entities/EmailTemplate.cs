namespace LinkTec.Api.Entities
{
    public enum ETipoEmail { PropostaAceita, PropostaRecusada, SolicitacaoAceita, SolicitacaoRecusada }
    public class EmailTemplate : Entity
    {
        public ETipoEmail TipoEmail { get; set; }

        public string Assunto { get; set; }

        public string Corpo { get; set; }
    }
}
