namespace EncantosSalao.Web.ViewModels.Cities
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SalonsCount { get; set; }
    }
}
