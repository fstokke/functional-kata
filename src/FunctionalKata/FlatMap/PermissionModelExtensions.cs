using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.FlatMap;

public static class PermissionModelExtensions
{
    // Returns list of all permission names currently in use
    public static ImmutableList<string> GetPermissions(this PermissionModel permissionModel)
    {
        var permissions = new HashSet<string>();
        foreach (var (_, rolePermissions) in permissionModel.RolePermissions)
        {
            foreach (var permission in rolePermissions)
            {
                permissions.Add(permission);    
            }
        }

        return permissions.ToImmutableList();
    }


    // Returns all permissions assigned to user
    public static ImmutableList<string> GetUserPermissions(this PermissionModel permissionModel, string userName)
    {
        // Find user's roles
        var userRoles = new HashSet<string>();
        foreach (var (role, roleUsers) in permissionModel.RoleAssignments)
        {
            foreach (var user in roleUsers)
            {
                if (user == userName)
                {
                    userRoles.Add(role);
                }
            }
        }

        // Find permissions for user's roles
        var permissions = new HashSet<string>(); // Use a set to filter out duplicate permissions
        foreach (var role in userRoles)
        {
            if (permissionModel.RolePermissions.TryGetValue(role, out var rolePermissions))
            {
                foreach (var permission in rolePermissions)
                {
                    permissions.Add(permission);
                }
            }
        }

        return permissions.ToImmutableList();
    }
}