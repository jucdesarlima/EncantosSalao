namespace EncantosSalao.Web.ViewModels.Common.SelectLists
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class CategorySelectListViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
