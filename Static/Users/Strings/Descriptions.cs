namespace Penguin.Cms.Security.Static
{
    public partial class Users
    {
        #region Classes

        /// <summary>
        /// Hard coded descriptions for default users
        /// </summary>
        public static class Descriptions
        {
            #region Fields

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string Admin = "The default user account for the system";

            public const string Guest = "The user record used for users that are not logged in";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            #endregion Fields
        }

        #endregion Classes
    }
}