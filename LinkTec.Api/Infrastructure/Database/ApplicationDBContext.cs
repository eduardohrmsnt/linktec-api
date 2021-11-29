
using LinkTec.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace LinkTec.Api.Infrastructure.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Parceiro> Parceiros { get; set; }

        public DbSet<PropostaSolicitacao> PropostasSolicitacoes { get; set; }

        public DbSet<OfertanteCertificado> OfertanteCertificados { get; set; }

        public DbSet<SolicitacaoDeServico> SolicitacoesDeServico { get; set; }

        public DbSet<ContatoCliente> ContatoCliente { get; set; }

        public DbSet<EmailTemplate> EmailsTemplate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parceiro>().Property(p => p.Nome).HasMaxLength(80);
            modelBuilder.Entity<Parceiro>().Property(p => p.Documento).HasMaxLength(14);
            modelBuilder.Entity<EmailTemplate>();
            modelBuilder.Entity<PropostaSolicitacao>();
            modelBuilder.Entity<SolicitacaoDeServico>();
            modelBuilder.Entity<OfertanteCertificado>();
            modelBuilder.Entity<ContatoCliente>();
        }
    }
}
