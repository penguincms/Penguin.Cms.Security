using System.Collections.Generic;

namespace Penguin.Cms.Security.Static
{
    /// <summary>
    /// Contains definitions for default groups
    /// </summary>
    public partial class Groups
    {
        /// <summary>
        /// A group that serves as a target for all users in any context
        /// </summary>
        public static Group AllUsers => new Group()
        {
            Name = Names.AllUsers,
            Description = Descriptions.AllUsers,
            Roles = new List<Role>()
                    {
                        Roles.AllUsers
                    }
        };
    }
}