namespace EncantosSalao.Web.Areas.Gerente.Controllers
{
    using EncantosSalao.Comum;
    using EncantosSalao.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = ConstantesGlobais.NomePapelGerenteSalao)]
    [Area("Gerente")]
    public class GerenteBaseController : BaseController
    {
    }
}
