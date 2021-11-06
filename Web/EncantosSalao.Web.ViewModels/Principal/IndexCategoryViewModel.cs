namespace EncantosSalao.Web.ViewModels.Principal
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
