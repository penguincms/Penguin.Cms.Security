using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Models.Base;
using System;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Defines the type of access that a security group has to a permissionable entity
    /// </summary>
    [Flags]
    public enum PermissionTypes
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None = 0,
        Read = 1,
        Write = 2,
        Create = 4,
        Delete = 8,
        Full = Read | Write | Create | Delete
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

    /// <summary>
    /// Represents a set of permissions to define a security groups access to any permissionable entity
    /// </summary>
    public class SecurityGroupPermission : KeyedObject
    {
        /// <summary>
        /// The security group that this permission applies to
        /// </summary>
        [EagerLoad(1)]
        public SecurityGroup SecurityGroup { get; set; }

        /// <summary>
        /// Defines the type of access that the security group has to the permissionable entity
        /// </summary>
        public PermissionTypes Type { get; set; }

        /// <summary>
        /// Constructs a new instance of this class for the specified security group, using the specified access type
        /// </summary>
        /// <param name="securityGroup">The security group that this permission applies to </param>
        /// <param name="type">The type of access that the security group has to the permissionable entity</param>
        public SecurityGroupPermission(SecurityGroup securityGroup, PermissionTypes type)
        {
            this.Type = type;
            this.SecurityGroup = securityGroup;
        }

        /// <summary>
        /// Constructs an empty instance of this class
        /// </summary>
        public SecurityGroupPermission()
        {
        }

        /// <summary>
        /// Checks this permission using flags, to determine if this allows for a particular kind of access
        /// </summary>
        /// <param name="type">The access type to check for</param>
        /// <returns>True if the access should be granted</returns>
        public bool HasPermission(PermissionTypes type) => this.Type.HasFlag(type);
    }
}