namespace EncantosSalao.Web.Areas.Administration.Controllers
{
    using EncantosSalao.Common;
    using EncantosSalao.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
