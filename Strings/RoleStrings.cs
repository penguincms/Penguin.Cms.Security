using Penguin.Cms.Security.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Cms.Security.Strings
{
    /// <summary>
    /// Contains static variables for generating and referencing roles
    /// </summary>
    public static class RoleStrings
    {
        /// <summary>
        /// This role allows a user or group to access the administration panel
        /// </summary>
        public static NameDescriptionPair AdminAccess { get; } = new NameDescriptionPair()
        {
            Name = "Admin Access",
            Description = "This role allows a user or group to access the administration panel"
        };

        /// <summary>
        /// This role is the base for all site users
        /// </summary>
        public static NameDescriptionPair AllUsers { get; } = new NameDescriptionPair()
        {
            Name = "All Users",
            Description = "This role is the base for all site users"
        };

        /// <summary>
        /// This role represents users that are not logged in
        /// </summary>
        public static NameDescriptionPair Guest { get; } = new NameDescriptionPair()
        {
            Name = "Guest",
            Description = "This role represents users that are not logged in"
        };

        /// <summary>
        /// This role represents users that are logged in
        /// </summary>
        public static NameDescriptionPair LoggedIn { get; } = new NameDescriptionPair()
        {
            Name = "Logged In",
            Description = "This role represents users that are logged in"
        };

        /// <summary>
        /// This role is grants access to all aspects of the web site
        /// </summary>
        public static NameDescriptionPair SysAdmin { get; } = new NameDescriptionPair()
        {
            Name = "System Administrator",
            Description = "This role is grants access to all aspects of the web site"
        };

        /// <summary>
        /// This role allows access to functions that control other users
        /// </summary>
        public static NameDescriptionPair UserManager { get; } = new NameDescriptionPair()
        {
            Name = "User Manager",
            Description = "This role allows access to functions that control other users"
        };
    }
}