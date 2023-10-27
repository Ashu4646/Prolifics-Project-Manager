using PPM.Model;
namespace PPM.Domain
{
    public class RolesRepo
    {
        public static List<Roles> roleObj = new List<Roles>();

        public void AddRole(int roleId, string roleName)
        {
            Roles rolesObj = new Roles()
            {
                roleId = roleId,
                roleName = roleName
            };
            roleObj.Add(rolesObj);
        }
        public static bool IsValidRole(int RoleId)

        {

            bool result = roleObj.Exists(e => e.roleId == RoleId);

            return result;

        }


       

        public static List<Roles> ViewRoles()
        {
            return roleObj;
        }
        public static List<Roles> GetRoleByName(string roleName)
        {
            
                List<Roles> role = roleObj.FindAll(p => p.roleName == roleName)!;
                return role;
            

        }

        
        public static Roles GetRolesById(int roleId)
        {
            {

                return roleObj.FirstOrDefault(p => p.roleId == roleId)!;
            }

        }
    }
}