namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        /// <summary>
        /// Role for users allowed to upload and edit images, but not other file types
        /// </summary>
        public static Role ImageManager => new Role()
        {
            Name = Names.ImageManager,
            Description = Descriptions.ImageManager
        };
    }
}