namespace EncantosSalao.Web.ViewModels.SalonServices
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class SalonServiceSimpleViewModel : IMapFrom<SalonService>
    {
        public string SalonId { get; set; }

        public int ServiceId { get; set; }

        public bool Available { get; set; }
    }
}
