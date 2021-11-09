namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Servicos.Dado.Cidades;
    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Servicos.Dado.Servicos;
    using EncantosSalao.Servicos.Dado.ServicosSalaoServico;
    using EncantosSalao.Web.VisaoModelos.Comum.ListasSelecionadas;
    using EncantosSalao.Web.VisaoModelos.Saloes;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SaloesController : AdministracaoController
    {
        private readonly ISaloesServico servicoSaloes;
        private readonly ICategoriasServico servicoCategorias;
        private readonly ICidadesServico servicoCidades;
        private readonly IServicosServico servicoServicos;
        private readonly ISalaoServicosServico servicoSaloeServicos;

        public SaloesController(
            ISaloesServico servicoSaloes,
            ICategoriasServico servicoCategorias,
            ICidadesServico servicoCidades,
            IServicosServico servicoServicos,
            ISalaoServicosServico servicoSaloeServicos)
        {
            this.servicoSaloes = servicoSaloes;
            this.servicoCategorias = servicoCategorias;
            this.servicoCidades = servicoCidades;
            this.servicoServicos = servicoServicos;
            this.servicoSaloeServicos = servicoSaloeServicos;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new SaloesListaVisaoModelo
            {
                Saloes = await this.servicoSaloes.PegaTodosAsync<SalaoVisaoModelo>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AdicionaSalao()
        {
            var categorias = await this.servicoCategorias.PegaTodosAsync<CategoriaSelecionadaListaVisaoModelo>();
            var cidades = await this.servicoCidades.PegaTodosAsync<CidadeSelecionadaListaVisaoModelo>();

            this.ViewData["Categorias"] = new SelectList(categorias, "Id", "Nome");
            this.ViewData["Cidades"] = new SelectList(cidades, "Id", "Nome");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaSalao(SalaoEntradaModelo input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string urlImagem;
            urlImagem = " "; // await this.cloudinaryService.UploadPictureAsync(input.Image, input.Name);

            // Adiciona Salao
            var idSalao = await this.servicoSaloes.AdicionaAsync(input.Nome, input.IdCategoria, input.IdCidade, input.Endereco, urlImagem);

            // Adicione ao salão todos os serviços de sua categoria
            var idsServicos = await this.servicoServicos.PegaTodosIdsPorCategoriaAsync(input.IdCategoria);
            await this.servicoSaloeServicos.AdicionaAsync(idSalao, idsServicos);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ExcluiSalao(string id)
        {
            if (id.StartsWith("semeado"))
            {
                return this.RedirectToAction("Index");
            }

            await this.servicoSaloes.ExcluiAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
