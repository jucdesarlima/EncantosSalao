namespace EncantosSalao.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.NoticiasBlog;
    using EncantosSalao.Web.VisaoModelos.Comum.Paginacao;
    using EncantosSalao.Web.VisaoModelos.NoticiasBlog;
    using Microsoft.AspNetCore.Mvc;

    public class NoticiasBlogController : BaseController
    {
        private readonly INoticiasBlogServico servicoNoticiasBlog;

        public NoticiasBlogController(INoticiasBlogServico servicoNoticiasBlog)
        {
            this.servicoNoticiasBlog = servicoNoticiasBlog;
        }

        public async Task<IActionResult> Index(
            int? sortId,
            int? pageNumber) // NoticiasblogId
        {
            if (sortId != null)
            {
                var blogPost = await this.servicoNoticiasBlog
                    .PegaPorIdAsync<NoticiasBlogVisaoModelo>(sortId.Value);
                if (blogPost == null)
                {
                    return new StatusCodeResult(404);
                }
            }

            this.ViewData["CurrentSort"] = sortId;

            int pageSize = ConstantesTamanhosPagina.NoticiasBlog;
            var pageIndex = pageNumber ?? 1;

            var blogPosts = await this.servicoNoticiasBlog
                .PegaTodosComPaginacaoAsync<NoticiasBlogVisaoModelo>(sortId, pageSize, pageIndex);
            var blogPostsList = blogPosts.ToList();

            var count = await this.servicoNoticiasBlog.PegaContadorPorPaginacaoAsync();

            var viewModel = new NoticiasBlogListaPaginadaVisaoModelo
            {
                NoticiasBlog = new ListaPaginada<NoticiasBlogVisaoModelo>(blogPostsList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }
    }
}
