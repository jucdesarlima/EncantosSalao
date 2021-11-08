namespace EncantosSalao.Web.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Web.VisaoModelos.Categorias;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriasController : BaseController
    {
        private readonly ICategoriasServico servicoCategorias;

        public CategoriasController(ICategoriasServico servicoCategorias)
        {
            this.servicoCategorias = servicoCategorias;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoriasListaVisaoModelo
            {
                Categorias = await this.servicoCategorias.PegaTodosAsync<CategoriaVisaoModelo>(),
            };
            return this.View(viewModel);
        }
    }
}
