namespace EncantosSalao.Web.Infraestrutura.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.NoticiasBlog;
    using EncantosSalao.Web.VisaoModelos.NoticiasBlog;
    using Microsoft.AspNetCore.Mvc;

    public class UltimasNoticiasBlogViewComponent : ViewComponent
    {
        private readonly INoticiasBlogServico servicoNoticiasBlog;

        public UltimasNoticiasBlogViewComponent(INoticiasBlogServico servicoNoticiasBlog)
        {
            this.servicoNoticiasBlog = servicoNoticiasBlog;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? count)
        {
            var viewModel = new NoticiasBlogListaVisaoModelo
            {
                NoticiasBlog = await this.servicoNoticiasBlog.PegaTodosAsync<NoticiasBlogVisaoModelo>(count),
            };

            return this.View(viewModel);
        }
    }
}
