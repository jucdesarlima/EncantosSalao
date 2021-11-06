namespace EncantosSalao.Web.ViewModels.Appointments
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Common;
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class AppointmentRatingViewModel : IMapFrom<Appointment>
    {
        public string Id { get; set; }

        public string SalonId { get; set; }

        public string SalonName { get; set; }

        public string SalonCategoryName { get; set; }

        public string SalonCityName { get; set; }

        public string SalonAddress { get; set; }

        public string SalonImageUrl { get; set; }

        public bool? IsSalonRatedByTheUser { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = GlobalConstants.ErrorMessages.Rating)]
        public int RateValue { get; set; }
    }
}
