using Microsoft.AspNetCore.Identity;

namespace SubtitleRed.Infrastructure.Identity;

public static class IdentityRolesInitializer
{
    public static async Task EnsureStandardRolesCreated(RoleManager<IdentityRole<Guid>> roleManager)
    {
        var standardRoles = new List<string>
        {
            IdentityRoleConstants.User
        };

        foreach (var role in standardRoles)
        {
            await EnsureRoleCreated(roleManager, role);
        }
    }

    private static async Task EnsureRoleCreated(RoleManager<IdentityRole<Guid>> roleManager, string roleName)
    {
        var isRoleExists = await roleManager.RoleExistsAsync(roleName);
            
        if (!isRoleExists)
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>
            {
                Name = roleName
            });
        }
    }
}