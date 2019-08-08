﻿using Penguin.Cms.Security;

namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        #region Properties

        /// <summary>
        /// This user should be allowed to manage and create users and permissions
        /// </summary>
        public static Role UserManager => new Role()
        {
            Name = Names.UserManager,
            Description = Descriptions.UserManager
        };

        #endregion Properties
    }
}