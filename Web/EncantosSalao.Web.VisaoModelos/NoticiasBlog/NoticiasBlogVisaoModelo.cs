namespace EncantosSalao.Web.VisaoModelos.NoticiasBlog
{
    using System;

    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class NoticiasBlogVisaoModelo : IMapFrom<NoticiasBlog>
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Conteudo { get; set; }

        public string UrlImagem { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
