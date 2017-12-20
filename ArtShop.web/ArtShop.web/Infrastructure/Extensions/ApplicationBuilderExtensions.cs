namespace IdentityTesting.Infrastructure.Extensions
{
    using ArtShop.Data;
    using ArtShop.Data.DataModels;
    using ArtShop.web.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ArtShopDbContext>().Database.Migrate();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {

                        var role = GlobalConstants.AdministarorRole;

                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            var result = await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });
                        }

                        var adminEmail = "smallblind@abv.bg";

                        var adminUserExists = await userManager.FindByNameAsync(adminEmail);

                        if (adminUserExists == null)
                        {

                            adminUserExists = new User
                            {
                                Email = adminEmail,
                                UserName = adminEmail,
                          
                            };
                            var result = await userManager.CreateAsync(adminUserExists, "admin12");

                            await userManager.AddToRoleAsync(adminUserExists, role);
                        }
                    })
                .Wait();
            }

            return app;
        }
    }
}
