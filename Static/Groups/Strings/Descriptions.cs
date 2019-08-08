namespace Penguin.Cms.Security.Static
{
    public partial class Groups
    {
        #region Classes

        /// <summary>
        /// Hard coded definitions for default groups
        /// </summary>
        public static class Descriptions
        {
            #region Fields

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string AllUsers = "This group is the base for all site users";

            public const string SysAdmins = "This group is grants access to all aspects of the web site";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            #endregion Fields
        }

        #endregion Classes
    }
}