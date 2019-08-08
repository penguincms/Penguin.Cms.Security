using Penguin.Cms.Security;

namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        #region Properties

        /// <summary>
        /// Role for users that are allowed to edit/update pages, but nothing else
        /// </summary>
        public static Role PageAuthor => new Role()
        {
            Name = Names.PageAuthor,
            Description = Descriptions.ContentManager
        };

        #endregion Properties
    }
}