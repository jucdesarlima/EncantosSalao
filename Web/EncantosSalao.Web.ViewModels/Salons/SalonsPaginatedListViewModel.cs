namespace EncantosSalao.Web.ViewModels.Salons
{
    using EncantosSalao.Web.ViewModels.Common.Pagination;

    public class SalonsPaginatedListViewModel
    {
        public PaginatedList<SalonViewModel> Salons { get; set; }
    }
}
