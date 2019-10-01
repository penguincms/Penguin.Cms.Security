using Penguin.Cms.Security.Strings;
using Penguin.Security.Abstractions.Constants;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Used to access typed instances of system roles
    /// </summary>
    public static class Roles
    {
        /// <summary>
        /// This role allows a user or group to access the administration panel
        /// </summary>
        public static Role AdminAccess { get; } = new Role()
        {
            Name = RoleNames.AdminAccess,
            Description = RoleStrings.AdminAccess.Description
        };

        /// <summary>
        /// This role is the base for all site users
        /// </summary>
        public static Role AllUsers { get; } = new Role()
        {
            Name = RoleNames.AllUsers,
            Description = RoleStrings.AllUsers.Description
        };

        /// <summary>
        /// This role represents users that are not logged in
        /// </summary>
        public static Role Guest { get; } = new Role()
        {
            Name = RoleNames.Guest,
            Description = RoleStrings.Guest.Description
        };

        /// <summary>
        /// This role represents users that are logged in
        /// </summary>
        public static Role LoggedIn { get; } = new Role()
        {
            Name = RoleNames.LoggedIn,
            Description = RoleStrings.LoggedIn.Description
        };

        /// <summary>
        /// This Role is grants access to all aspects of the web site
        /// </summary>
        public static Role SysAdmin { get; } = new Role()
        {
            Name = RoleNames.SysAdmin,
            Description = RoleStrings.SysAdmin.Description
        };

        /// <summary>
        /// This role allows access to functions that control other users
        /// </summary>
        public static Role UserManager { get; } = new Role()
        {
            Name = RoleNames.UserManager,
            Description = RoleStrings.UserManager.Description
        };
    }
}