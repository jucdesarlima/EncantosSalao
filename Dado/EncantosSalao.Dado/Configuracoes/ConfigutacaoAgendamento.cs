namespace EncantosSalao.Dado.Configuracoes
{
    using EncantosSalao.Dado.Modelos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConfigutacaoAgendamento : IEntityTypeConfiguration<Agendamentos>
    {
        public void Configure(EntityTypeBuilder<Agendamentos> agendamento)
        {
            agendamento
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Agendamentos)
                .HasForeignKey(a => a.IdUsuario);

            agendamento
                .HasOne(a => a.Salao)
                .WithMany(s => s.Agendamentos)
                .HasForeignKey(a => a.IdSalao);

            agendamento
                .HasOne(a => a.Servico)
                .WithMany(s => s.Agendamentos)
                .HasForeignKey(a => a.IdServico);

            agendamento
                .HasOne(a => a.ServicoSalao)
                .WithMany(ss => ss.Agendamentos)
                .HasForeignKey(a => new { a.IdSalao, a.IdServico });
        }
    }
}
