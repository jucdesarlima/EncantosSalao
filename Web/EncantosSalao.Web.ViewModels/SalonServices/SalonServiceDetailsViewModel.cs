﻿namespace EncantosSalao.Web.ViewModels.SalonServices
{
    using EncantosSalao.Data.Models;
    using EncantosSalao.Services.Mapping;

    public class SalonServiceDetailsViewModel : IMapFrom<SalonService>
    {
        public string SalonId { get; set; }

        public string SalonName { get; set; }

        public string SalonCityName { get; set; }

        public string SalonAddress { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }
    }
}