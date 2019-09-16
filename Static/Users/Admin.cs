using System.Collections.Generic;

namespace Penguin.Cms.Security.Static
{
    /// <summary>
    /// Default users to create when the system is initialized
    /// </summary>
    public partial class Users
    {
        /// <summary>
        /// The default system administrator log in for the system
        /// </summary>
        public static User Admin => new User()
        {
            FirstName = Names.Admin,
            Login = Names.Admin,
            Groups = new List<Group>()
                    {
                        Groups.SysAdmins
                    }
        };
    }
}