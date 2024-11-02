using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.FlatMap;

public static class PermissionModelExtensions
{
    // Returns list of all permission names currently in use
    public static ImmutableList<string> GetPermissions(this PermissionModel permissionModel) =>
        permissionModel.RolePermissions
            .SelectMany(pair => pair.Value)
            .Distinct()
            .ToImmutableList();

    // Returns all permissions assigned to user
    public static ImmutableList<string> GetUserPermissions(this PermissionModel permissionModel, string userName) =>
        permissionModel.RoleAssignments
            .Where(pair => pair.Value.Contains(userName))
            .SelectMany(pair => permissionModel.RolePermissions[pair.Key])
            .Distinct()
            .ToImmutableList();
}