namespace EncantosSalao.Web.ViewModels.Appointments
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Common;
    using EncantosSalao.Web.ViewModels.Common.CustomValidationAttributes;

    public class AppointmentInputModel
    {
        [Required]
        public string SalonId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Date { get; set; }

        [Required]
        [ValidateTimeString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Time { get; set; }
    }
}
