namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Servicos.Dado.Servicos;
    using EncantosSalao.Servicos.Dado.ServicosSalaoServico;
    using EncantosSalao.Web.VisaoModelos.Comum.ListasSelecionadas;
    using EncantosSalao.Web.VisaoModelos.Servicos;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ServicosController : AdministracaoController
    {
        private readonly IServicosServico servicoServicos;
        private readonly ICategoriasServico servicoCategorias;
        private readonly ISaloesServico servicoSaloes;
        private readonly ISalaoServicosServico servicoSalaoServicos;

        public ServicosController(
            IServicosServico servicoServicos,
            ICategoriasServico servicoCategorias,
            ISaloesServico servicoSaloes,
            ISalaoServicosServico servicoSalaoServicos)
        {
            this.servicoServicos = servicoServicos;
            this.servicoCategorias = servicoCategorias;
            this.servicoSaloes = servicoSaloes;
            this.servicoSalaoServicos = servicoSalaoServicos;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ServicosListaVisaoModelo
            {
                Servicos = await this.servicoServicos.PegaTodosAsync<ServicoVisaoModelo>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddService()
        {
            var categorias = await this.servicoCategorias.PegaTodosAsync<CategoriaSelecionadaListaVisaoModelo>();
            this.ViewData["Categorias"] = new SelectList(categorias, "Id", "Nome");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServicoEntradaModelo input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // Adiciona Servico
            var idServico = await this.servicoServicos.AdicionaAsync(input.Nome, input.IdCategoria, input.Descricao);

            // Adiciona o servico para todos os saloes na categoria
            var idsSaloes = await this.servicoSaloes.PegaTodosIdsPorCategoriaAsync(input.IdCategoria);
            await this.servicoSalaoServicos.AdicionaAsync(idsSaloes, idServico);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ExcluiServico(int id)
        {
            if (id <= ConstantesGlobais.ContadoresDadosSemeados.Servicos)
            {
                return this.RedirectToAction("Index");
            }

            await this.servicoServicos.ExcluiAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
