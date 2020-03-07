namespace Penguin.Cms.Security.Constants.Strings
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>")]
    public partial class Roles
    {
        /// <summary>
        /// Hardcoded descriptions for default roles
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "<Pending>")]
        public static class Descriptions
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

            public const string CONTENT_MANAGER = "This role is grants access to content creation and management portions of the web site";

            public const string IMAGE_MANAGER = "This role is grants access to Image Management portions of the web site";

            public const string PAGE_AUTHOR = "This role allows users to create new pages on the website";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }
    }
}