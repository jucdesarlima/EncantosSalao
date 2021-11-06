namespace EncantosSalao.Web.ViewModels.Categories
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class CategorySimpleViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SalonsCount { get; set; }
    }
}
