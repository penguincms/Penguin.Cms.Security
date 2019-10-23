namespace Penguin.Cms.Security.Constants.Strings
{
    public partial class Roles
    {
        /// <summary>
        /// Hardcoded descriptions for default roles
        /// </summary>
        public static class Descriptions
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

            public const string ContentManager = "This role is grants access to content creation and management portions of the web site";

            public const string ImageManager = "This role is grants access to Image Management portions of the web site";

            public const string PageAuthor = "This role allows users to create new pages on the website";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }
    }
}