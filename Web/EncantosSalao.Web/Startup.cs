﻿namespace EncantosSalao.Web
{
    using System.Reflection;

    using CloudinaryDotNet;
    using EncantosSalao.Common;
    using EncantosSalao.Data;
    using EncantosSalao.Data.Common;
    using EncantosSalao.Data.Common.Repositories;
    using EncantosSalao.Data.Models;
    using EncantosSalao.Data.Repositories;
    using EncantosSalao.Data.Seeding;
    using EncantosSalao.Services.Cloudinary;
    using EncantosSalao.Services.Data.Appointments;
    using EncantosSalao.Services.Data.BlogPosts;
    using EncantosSalao.Services.Data.Categories;
    using EncantosSalao.Services.Data.Cities;
    using EncantosSalao.Services.Data.Salons;
    using EncantosSalao.Services.Data.SalonServicesServices;
    using EncantosSalao.Services.Data.Services;
    using EncantosSalao.Services.DateTimeParser;
    using EncantosSalao.Services.Mapping;
    using EncantosSalao.Services.Messaging;
    using EncantosSalao.Web.ViewModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Cloudinary Setup
            Cloudinary cloudinary = new Cloudinary(new Account(
                GlobalConstants.CloudName, // this.configuration["Cloudinary:CloudName"],
                this.configuration["Cloudinary:ApiKey"],
                this.configuration["Cloudinary:ApiSecret"]));
            services.AddSingleton(cloudinary);

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<IBlogPostsService, BlogPostsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<ISalonsService, SalonsService>();
            services.AddTransient<ISalonServicesService, SalonServicesService>();
            services.AddTransient<IAppointmentsService, AppointmentsService>();
            services.AddTransient<IDateTimeParserService, DateTimeParserService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Principal/Error/{0}");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Principal/Error/{0}");
                app.UseExceptionHandler("/Principal/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Principal}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Principal}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}