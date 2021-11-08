namespace EncantosSalao.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Servicos.Dado.NoticiasBlog;
    using EncantosSalao.Web.VisaoModelos;
    using EncantosSalao.Web.VisaoModelos.Principal;
    using Microsoft.AspNetCore.Mvc;

    public class PrincipalController : BaseController
    {
        private readonly ICategoriasServico servicoCategorias;
        private readonly INoticiasBlogServico servicoNoticiasBlog;

        public PrincipalController(
            ICategoriasServico servicoCategorias,
            INoticiasBlogServico servicoNoticiasBlog)
        {
            this.servicoCategorias = servicoCategorias;
            this.servicoNoticiasBlog = servicoNoticiasBlog;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndiceVisaoModelo
            {
                Categories =
                    await this.servicoCategorias.PegaTodosAsync<IndiceCategoriaVisaoModelo>(
                        ConstantesGlobais.ContadoresDadosSemeados.Categorias),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [Route("/Principal/Error/404")]
        public IActionResult Error404()
        {
            return this.View();
        }

        [Route("/Principal/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            // Could handle different codes here
            // or just return the default error view
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErroVisaoModelo { IdRequisicao = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
