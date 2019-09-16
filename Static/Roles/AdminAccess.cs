namespace Penguin.Cms.Security.Static
{
    /// <summary>
    /// An object containing default roles for the system
    /// </summary>
    public partial class Roles
    {
        /// <summary>
        /// Should be allowed to access the administration page, but not guaranteeing any content
        /// </summary>
        public static Role AdminAccess => new Role()
        {
            Name = Names.AdminAccess,
            Description = Descriptions.AdminAccess
        };
    }
}