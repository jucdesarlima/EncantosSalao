namespace EncantosSalao.Web.VisaoModelos.Cidades
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class CidadeVisaoModelo : IMapFrom<Cidade>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int ContadorSaloes { get; set; }
    }
}
