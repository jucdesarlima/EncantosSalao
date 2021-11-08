namespace EncantosSalao.Dado.Configuracoes
{
    using EncantosSalao.Dado.Modelos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConfiguracaoServicoSalao : IEntityTypeConfiguration<ServicoSalao>
    {
        public void Configure(EntityTypeBuilder<ServicoSalao> salonService)
        {
            salonService.HasKey(ss => new { ss.IdSalao, ss.IdServico });
        }
    }
}
