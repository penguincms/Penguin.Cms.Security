using Penguin.Cms.Security.Constants.Strings;
using System.Collections.Generic;

namespace Penguin.Cms.Security.Constants
{
    /// <summary>
    /// Used to access typed instances of system groups
    /// </summary>
    public static class Groups
    {
        /// <summary>
        /// This group is the base for all site users
        /// </summary>
        public static Group AllUsers { get; } = new Group()
        {
            Name = GroupStrings.AllUsers.Name,
            Description = GroupStrings.AllUsers.Description,
            Roles = new List<Role>()
            {
                Roles.LoggedIn
            }
        };

        /// <summary>
        /// This group contains users that are not logged in
        /// </summary>
        public static Group Guest { get; } = new Group()
        {
            Name = GroupStrings.Guest.Name,
            Description = GroupStrings.Guest.Description,
            Roles = new List<Role>()
            {
                Roles.Guest
            }
        };

        /// <summary>
        /// This group contains users that are not logged in
        /// </summary>
        public static Group LoggedIn { get; } = new Group()
        {
            Name = GroupStrings.LoggedIn.Name,
            Description = GroupStrings.LoggedIn.Description,
            Roles = new List<Role>()
            {
                Roles.LoggedIn
            }
        };

        /// <summary>
        /// This group is grants access to all aspects of the web site
        /// </summary>
        public static Group SysAdmins { get; } = new Group()
        {
            Name = GroupStrings.SysAdmin.Name,
            Description = GroupStrings.SysAdmin.Description,
            Roles = new List<Role>()
            {
                Roles.AllUsers,
                Roles.LoggedIn,
                Roles.AdminAccess,
                Roles.SysAdmin,
                Roles.UserManager
            }
        };
    }
}