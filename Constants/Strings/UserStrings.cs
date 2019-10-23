using Penguin.Security.Abstractions;

namespace Penguin.Cms.Security.Constants.Strings
{
    /// <summary>
    /// Contains static variables for generating and referencing default users
    /// </summary>
    public static class UserStrings
    {
        /// <summary>
        /// This group is the base for all site users
        /// </summary>
        public static NameDescriptionPair Admin { get; } = new NameDescriptionPair()
        {
            Name = "Admin",
            Description = "The system administrator account for the CMS"
        };

        /// <summary>
        /// This group is grants access to all aspects of the web site
        /// </summary>
        public static NameDescriptionPair Guest { get; } = new NameDescriptionPair()
        {
            Name = "Guest",
            Description = "A user representing anyone who is not currently logged into the system"
        };
    }
}