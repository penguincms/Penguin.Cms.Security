﻿using Penguin.Cms.Entities;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using Penguin.Security.Abstractions;
using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// An object that tracks permissions for entities
    /// </summary>
    public class EntityPermissions : Entity, IEntityPermissions
    {
        [DontAllow(DisplayContexts.Any)]
        public override int _Id { get { return base._Id; } set { base._Id = value; } }

        /// <summary>
        /// Setting this object adds the defined permissions to the underlying collection.
        /// This exists to allow for inline-defining new object permissions without needing to worry
        /// about blowing away existing permissions if the object already exists
        /// </summary>
        [DontAllow(DisplayContexts.List)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1044:Properties should not be write only", Justification = "This is being used to simplify permissions creation during init")]
        public List<SecurityGroupPermission> AddPermissions
        {
            set
            {
                Contract.Requires(value != null);

                foreach (SecurityGroupPermission permission in value)
                {
                    this.AddPermission(permission.SecurityGroup, permission.Type);
                }
            }
        }

        /// <summary>
        /// The Guid for the entity being referenced
        /// </summary>
        public Guid EntityGuid { get; set; }

        /// <summary>
        /// A list of permission definitions applied to this object
        /// </summary>
        [EagerLoad(2)]
        [Display(GroupName = "table")]
        public List<SecurityGroupPermission> Permissions { get; set; }

        IReadOnlyList<ISecurityGroupPermission> IEntityPermissions.Permissions => this.Permissions;
        private const string NULL_SECURITY_GROUP_MESSAGE = "Can not assign access to null security group";

        /// <summary>
        /// Constructs a new instance of a permissionable entity and initializes the permissions list
        /// </summary>
        public EntityPermissions()
        {
            Permissions = new List<SecurityGroupPermission>();
        }

        /// <summary>
        /// Adds a new access type for a given security group
        /// </summary>
        /// <param name="securityGroup">The security group to give access to</param>
        /// <param name="permission">The type of access to allow</param>
        public void AddPermission(SecurityGroup securityGroup, PermissionTypes permission)
        {
            if (securityGroup is null)
            {
                throw new ArgumentNullException(nameof(securityGroup), NULL_SECURITY_GROUP_MESSAGE);
            }

            SecurityGroupPermission existing = this.Permissions.SingleOrDefault(p => p.SecurityGroup == securityGroup);

            if (existing is null)
            {
                this.Permissions.Add(new SecurityGroupPermission() { SecurityGroup = securityGroup, Type = permission });
            }
            else
            {
                existing.Type |= permission;
            }
        }

        /// <summary>
        /// When using newtonsoft, this ensures that entity permissions are not passed over with the entity if its serialized
        /// This would be a security vulnerability since user/group information might be passed forward
        /// </summary>
        /// <returns>False</returns>
        public bool ShouldSerializePermissions() => false;
    }
}