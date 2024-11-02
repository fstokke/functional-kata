using System.Collections.Immutable;

namespace FunctionalKataLib;

public record PermissionModel(
    ImmutableDictionary<string, ImmutableList<string>> RoleAssignments,
    ImmutableDictionary<string, ImmutableList<string>> RolePermissions
);
    
public static class PermissionModelExample
{
    private static readonly ImmutableDictionary<string, ImmutableList<string>> RoleAssignments =
        new Dictionary<string, ImmutableList<string>>
        {   {"User", ImmutableList.Create("Per", "Inga", "Kari", "Pål", "Espen")},
            {"UserAdmin", ImmutableList.Create("Kari", "Espen")},
            {"GroupAdmin", ImmutableList.Create("Kari", "Inga")}
        }.ToImmutableDictionary();

    private static readonly ImmutableDictionary<string, ImmutableList<string>> RolePermissions =
        new Dictionary<string, ImmutableList<string>>
        {
            {"User", ImmutableList.Create(new[] {"Group.List"})},
            {"UserAdmin", ImmutableList.Create("User.List", "User.Create", "User.Delete")},
            {"GroupAdmin", ImmutableList.Create("User.List", "Group.Create", "Group.Delete")}
        }.ToImmutableDictionary();
    
    public static readonly PermissionModel PermissionModel = new(
        RoleAssignments,
        RolePermissions
    );
}