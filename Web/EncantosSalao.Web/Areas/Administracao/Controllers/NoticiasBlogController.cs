namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Servicos.Dado.NoticiasBlog;
    using EncantosSalao.Web.VisaoModelos.NoticiasBlog;
    using Microsoft.AspNetCore.Mvc;

    public class NoticiasBlogController : AdministracaoController
    {
        private readonly INoticiasBlogServico servicoNoticiasBlog;

        public NoticiasBlogController(
            INoticiasBlogServico servicoNoticiasBlog)
        {
            this.servicoNoticiasBlog = servicoNoticiasBlog;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new NoticiasBlogListaVisaoModelo
            {
                NoticiasBlog = await this.servicoNoticiasBlog.PegaTodosAsync<NoticiasBlogVisaoModelo>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AdicionaNoticiasBlog()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaNoticiasBlog(NoticiasBlogEntradaModelo input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string urlImagem;
            urlImagem = " "; //await this.cloudinaryService.UploadPictureAsync(input.Image, input.Title);

            await this.servicoNoticiasBlog.AdicionaAsync(input.Titulo, input.Conteudo, input.Autor, urlImagem);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ExcluiNoticiasBlog(int id)
        {
            if (id <= ConstantesGlobais.ContadoresDadosSemeados.NoticiaBlog)
            {
                return this.RedirectToAction("Index");
            }

            await this.servicoNoticiasBlog.ExcluiAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
