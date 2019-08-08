namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        #region Classes

        /// <summary>
        /// Hard coded names for default roles
        /// </summary>
        public static class Names
        {
            #region Fields

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string AdminAccess = "Admin Access";

            public const string AllUsers = "All Users";

            public const string ContentManager = "Content Manager";
            public const string Guest = "Guest";

            public const string ImageManager = "Image Manager";
            public const string LoggedIn = "LoggedIn";

            public const string PageAuthor = "Page Author";
            public const string SysAdmin = "System Administrator";
            public const string UserManager = "User Manager";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            #endregion Fields
        }

        #endregion Classes
    }
}