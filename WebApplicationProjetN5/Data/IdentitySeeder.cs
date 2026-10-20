using Microsoft.AspNetCore.Identity;

namespace WebApplicationProjetN5.Data;

public static class IdentitySeeder
{
    public static async Task CreateAdminAsync(
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope();

        var services = scope.ServiceProvider;

        var userManager =
            services.GetRequiredService<UserManager<ApplicationUser>>();

        var roleManager =
            services.GetRequiredService<RoleManager<IdentityRole>>();

        string email = configuration["AdminAccount:Email"]
            ?? throw new InvalidOperationException(
                "L'adresse email de l'administrateur est absente.");

        string password = configuration["AdminAccount:Password"]
            ?? throw new InvalidOperationException(
                "Le mot de passe de l'administrateur est absent.");

        const string roleName = "Admin";

        // Créer le rôle Admin s'il n'existe pas.
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            var roleResult = await roleManager.CreateAsync(
                new IdentityRole(roleName));

            if (!roleResult.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join("; ",
                        roleResult.Errors.Select(e => e.Description)));
            }
        }

        // Rechercher le compte administrateur.
        var admin = await userManager.FindByEmailAsync(email);

        // Créer le compte s'il n'existe pas.
        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var userResult = await userManager.CreateAsync(
                admin, password);

            if (!userResult.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join("; ",
                        userResult.Errors.Select(e => e.Description)));
            }
        }

        // Attribuer le rôle Admin au compte.
        if (!await userManager.IsInRoleAsync(admin, roleName))
        {
            var roleResult = await userManager.AddToRoleAsync(
                admin, roleName);

            if (!roleResult.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join("; ",
                        roleResult.Errors.Select(e => e.Description)));
            }
        }
    }
}