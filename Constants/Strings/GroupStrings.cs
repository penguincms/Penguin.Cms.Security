using Penguin.Security.Abstractions;

namespace Penguin.Cms.Security.Constants.Strings
{
    /// <summary>
    /// Contains static variables for generating and referencing Groups
    /// </summary>
    public static class GroupStrings
    {
        /// <summary>
        /// This group is the base for all site users
        /// </summary>
        public static NameDescriptionPair AllUsers { get; } = new NameDescriptionPair()
        {
            Name = "All Users",
            Description = "This group is the base for all site users"
        };

        /// <summary>
        /// This group contains users that are not logged in
        /// </summary>
        public static NameDescriptionPair Guest { get; } = new NameDescriptionPair()
        {
            Name = "Guest",
            Description = "This group contains users that are not logged in"
        };

        /// <summary>
        /// This group represents users that are logged in
        /// </summary>
        public static NameDescriptionPair LoggedIn { get; } = new NameDescriptionPair()
        {
            Name = "Logged In",
            Description = "This group represents users that are logged in"
        };

        /// <summary>
        /// This group is grants access to all aspects of the web site
        /// </summary>
        public static NameDescriptionPair SysAdmin { get; } = new NameDescriptionPair()
        {
            Name = "System Administrators",
            Description = "This group is grants access to all aspects of the web site"
        };
    }
}