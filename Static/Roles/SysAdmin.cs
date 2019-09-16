﻿namespace Penguin.Cms.Security.Static
{
    public partial class Roles
    {
        /// <summary>
        /// Role to manage access for any system administrators
        /// </summary>
        public static Role SysAdmin => new Role()
        {
            Name = Names.SysAdmin,
            Description = Descriptions.SysAdmin
        };
    }
}