namespace EncantosSalao.Web.ViewModels.Salons
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class SalonSimpleViewModel : IMapFrom<Salon>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
