﻿using Penguin.Cms.Security.Strings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Used to access typed instances of system users
    /// </summary>
    public static class Users
    {
        /// <summary>
        /// The default system administrator log in for the system
        /// </summary>
        public static User Admin => new User()
        {
            FirstName = UserStrings.Admin.Name,
            Login = UserStrings.Admin.Name,
            Groups = new List<Group>()
                    {
                        Groups.SysAdmins,
                        Groups.AllUsers,
                        Groups.LoggedIn
                    }
        };

        /// <summary>
        /// The default system administrator log in for the system
        /// </summary>
        public static User Guest => new User()
        {
            FirstName = UserStrings.Guest.Name,
            Login = UserStrings.Guest.Name,
            Groups = new List<Group>()
                    {
                        Groups.Guest
                    }
        };
    }
}