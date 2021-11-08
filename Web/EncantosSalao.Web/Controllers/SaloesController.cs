namespace EncantosSalao.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Web.VisaoModelos.Categorias;
    using EncantosSalao.Web.VisaoModelos.Comum.Paginacao;
    using EncantosSalao.Web.VisaoModelos.Saloes;
    using Microsoft.AspNetCore.Mvc;

    public class SaloesController : BaseController
    {
        private readonly ISaloesServico servicoSaloes;
        private readonly ICategoriasServico servicoCategorias;

        public SaloesController(
            ISaloesServico servicoSaloes,
            ICategoriasServico servicoCategorias)
        {
            this.servicoSaloes = servicoSaloes;
            this.servicoCategorias = servicoCategorias;
        }

        public async Task<IActionResult> Index(
            int? sortId, // categoryId
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            if (sortId != null)
            {
                var categoria = await this.servicoCategorias
                    .PegaPorIdAsync<CategoriaSimplesVisaoModelo>(sortId.Value);
                if (categoria == null)
                {
                    return new StatusCodeResult(404);
                }

                this.ViewData["NomeCategoria"] = categoria.Nome;
            }

            this.ViewData["CurrentSort"] = sortId;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.ViewData["CurrentFilter"] = searchString;

            int pageSize = ConstantesTamanhosPagina.Saloes;
            var pageIndex = pageNumber ?? 1;

            var salons = await this.servicoSaloes
                .PegaTodosOrdenandoFiltrandoPaginandoAsync<SalaoVisaoModelo>(
                    searchString, sortId, pageSize, pageIndex);
            var salonsList = salons.ToList();

            var count = await this.servicoSaloes
                .PegaContadorPorPaginacaoAsync(searchString, sortId);

            var viewModel = new SaloesListaPaginadaVisaoModelo
            {
                Saloes = new ListaPaginada<SalaoVisaoModelo>(salonsList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.servicoSaloes.PegaPorIdAsync<SalaoComServicosVisaoModelo>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }
    }
}
