using Penguin.Cms.Security;

namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        #region Properties

        /// <summary>
        /// Role to handle permissions for users that are not signed in to the CMS
        /// </summary>
        public static Role Guest => new Role()
        {
            Name = Names.Guest,
            Description = Descriptions.Guest
        };

        #endregion Properties
    }
}