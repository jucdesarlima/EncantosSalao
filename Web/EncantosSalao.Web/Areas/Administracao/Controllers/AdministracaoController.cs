namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using EncantosSalao.Comum;
    using EncantosSalao.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = ConstantesGlobais.NomePapelAdministrador)]
    [Area("Administracao")]
    public class AdministracaoController : BaseController
    {
    }
}
