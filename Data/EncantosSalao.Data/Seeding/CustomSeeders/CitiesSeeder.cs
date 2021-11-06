namespace EncantosSalao.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Data.Models;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cities = new City[]
                {
                    new City // Id = 1
                    {
                        Name = "Sofia",
                    },
                    new City // Id = 2
                    {
                        Name = "Varna",
                    },
                };

            // Need them in particular order
            foreach (var city in cities)
            {
                await dbContext.AddAsync(city);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
