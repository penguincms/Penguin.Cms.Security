namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        #region Classes

        /// <summary>
        /// Hardcoded descriptions for default roles
        /// </summary>
        public static class Descriptions
        {
            #region Fields

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string AdminAccess = "This role allows a user or group to access the administration panel";

            public const string AllUsers = "This role is the base for all site users";

            public const string ContentManager = "This role is grants access to content creation and management portions of the web site";
            public const string Guest = "This role represents users that are not logged in";

            public const string ImageManager = "This role is grants access to Image Management portions of the web site";
            public const string LoggedIn = "This role represents users that are logged in";

            public const string PageAuthor = "This role allows users to create new pages on the website";
            public const string SysAdmin = "This role is grants access to all aspects of the web site";
            public const string UserManager = "This role is grants access to User, Group, Role Management portions of the web site";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            #endregion Fields
        }

        #endregion Classes
    }
}