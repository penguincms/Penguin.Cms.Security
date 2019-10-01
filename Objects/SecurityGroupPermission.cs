using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Models.Base;
using Penguin.Security.Abstractions;
using Penguin.Security.Abstractions.Interfaces;
using System;

namespace Penguin.Cms.Security
{


    /// <summary>
    /// Represents a set of permissions to define a security groups access to any permissionable entity
    /// </summary>
    public class SecurityGroupPermission : KeyedObject, ISecurityGroupPermission
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

        ISecurityGroup ISecurityGroupPermission.SecurityGroup => this.SecurityGroup;

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
    }
}