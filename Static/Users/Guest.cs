using Penguin.Persistence.Abstractions.Attributes.Control;
using System;
using System.Collections.Generic;

namespace Penguin.Cms.Security.Static
{
    /// <summary>
    /// Default users to create when the system is initialized
    /// </summary>
    public partial class Users
    {
        /// <summary>
        /// A user representing anyone who is not currently logged in to the system
        /// </summary>
        [DoNotCreate]
        public static User Guest => new User()
        {
            FirstName = Names.Guest,
            Login = Names.Guest,
            Roles = new List<Role>()
                    {
                        Roles.Guest
                    },
            Groups = new List<Group>()
            {
                Groups.AllUsers
            },
            Guid = Guid.Empty
        };
    }
}