namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        /// <summary>
        /// The user should be allowed to produce content in the CMS, pages, navigation menus, etc
        /// </summary>
        public static Role ContentManager => new Role()
        {
            Name = Names.ContentManager,
            Description = Descriptions.ContentManager
        };
    }
}