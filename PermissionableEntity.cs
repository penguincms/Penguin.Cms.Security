﻿using Penguin.Cms.Entities;
using Penguin.Cms.Security.Extensions;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// The base class for any entity that should require permissions based access
    /// </summary>
    [Serializable]
    public abstract class PermissionableEntity : UserAuditableEntity
    {
        #region Properties

        /// <summary>
        /// Setting this object adds the defined permissions to the underlying collection.
        /// This exists to allow for inline-defining new object permissions without needing to worry 
        /// about blowing away existing permissions if the object already exists
        /// </summary>
        [DontAllow(DisplayContext.List)]
        public List<SecurityGroupPermission> AddPermissions
        {
            set
            {
                foreach (SecurityGroupPermission permission in value)
                {
                    this.AddPermission(permission.SecurityGroup, permission.Type);
                }
            }
        }

        /// <summary>
        /// A list of permission definitions applied to this object
        /// </summary>
        [EagerLoad(2)]
        [Display(GroupName = "table")]
        public List<SecurityGroupPermission> Permissions { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of a permissionable entity and initializes the permissions list
        /// </summary>
        public PermissionableEntity()
        {
            Permissions = new List<SecurityGroupPermission>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a new access type for a given security group
        /// </summary>
        /// <param name="securityGroup">The security group to give access to</param>
        /// <param name="permission">The type of access to allow</param>
        public void AddPermission(SecurityGroup securityGroup, PermissionType permission)
        {
            if (securityGroup is null)
            {
                throw new ArgumentNullException(nameof(securityGroup), "Can not assign access to null security group");
            }

            SecurityGroupPermission existing = this.Permissions.SingleOrDefault(p => p.SecurityGroup == securityGroup);

            if (existing is null)
            {
                this.Permissions.Add(new SecurityGroupPermission() { SecurityGroup = securityGroup, Type = permission });
            }
            else
            {
                existing.Type = existing.Type | permission;
            }
        }

        /// <summary>
        /// Checks to see if the user specified is allowed to access this object in a given way, based on its groups/roles
        /// </summary>
        /// <param name="user">The user to check for access</param>
        /// <param name="type">The type of access to check for</param>
        /// <returns>Whether or not the given user is allowed the requested access type</returns>
        public bool AllowsAccessType(User user, PermissionType type)
        {
            return this.Permissions.Any(sg => sg.Type.HasFlag(type) && user.SecurityGroups().Contains(sg.SecurityGroup));
        }

        /// <summary>
        /// When using newtonsoft, this ensures that entity permissions are not passed over with the entity if its serialized
        /// This would be a security vulnerability since user/group information might be passed forward
        /// </summary>
        /// <returns>False</returns>
        public bool ShouldSerializePermissions() => false;

        #endregion Methods
    }
}