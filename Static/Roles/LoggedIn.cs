﻿using Penguin.Cms.Security;

namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        #region Properties

        /// <summary>
        /// Role for managing access for any user that is actively logged in to the system
        /// </summary>
        public static Role LoggedIn => new Role()
        {
            Name = Names.LoggedIn,
            Description = Descriptions.LoggedIn
        };

        #endregion Properties
    }
}