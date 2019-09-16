using System.Collections.Generic;

namespace Penguin.Cms.Security.Static
{
    public partial class Groups
    {
        /// <summary>
        /// The highest level of permissions in any system. Should allow access to anything.
        /// </summary>
        public static Group SysAdmins => new Group()
        {
            Name = Names.SysAdmins,
            Description = Descriptions.SysAdmins,
            Roles = new List<Role>()
                    {
                        Roles.ImageManager,
                        Roles.LoggedIn,
                        Roles.AdminAccess,
                        Roles.ContentManager,
                        Roles.SysAdmin,
                        Roles.UserManager
                    }
        };
    }
}