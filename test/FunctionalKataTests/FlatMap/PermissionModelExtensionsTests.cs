using FunctionalKata.FlatMap;
using FunctionalKataLib;

namespace FunctionalKataTests.FlatMap;

public static class PermissionModelExtensionsTests
{
    public class GetPermissionsTests
    {
        [Fact]
        public void ReturnsAllPermissions()
        {
            var permissions = PermissionModelExample.PermissionModel.GetPermissions()
                .OrderBy(permission => permission);
            
            Assert.Equal("Group.Create, Group.Delete, Group.List, User.Create, User.Delete, User.List", 
                string.Join(", ", permissions));
        }
    }

    public class GetUserPermissions
    {
        [Theory]
        [InlineData("Per", "Group.List")]
        [InlineData("Espen", "Group.List, User.Create, User.Delete, User.List")]
        [InlineData("Inga", "Group.Create, Group.Delete, Group.List, User.List")]
        [InlineData("Kari", "Group.Create, Group.Delete, Group.List, User.Create, User.Delete, User.List")]
        public void ReturnsUnionOfPermissionsForAllRoles(string userName, string expectedPermissions)
        {
            var permissions = PermissionModelExample.PermissionModel.GetUserPermissions(userName)
                .OrderBy(permission => permission);
            
            Assert.Equal(expectedPermissions, String.Join(", ", permissions));
        }
    }
}