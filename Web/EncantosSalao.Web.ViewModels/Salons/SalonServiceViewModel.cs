namespace EncantosSalao.Web.ViewModels.Salons
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class SalonServiceViewModel : IMapFrom<SalonService>
    {
        public string SalonId { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public bool Available { get; set; }
    }
}
