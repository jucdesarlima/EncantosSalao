namespace EncantosSalao.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Common;
    using EncantosSalao.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Salons = new HashSet<Salon>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Salon> Salons { get; set; }
    }
}
