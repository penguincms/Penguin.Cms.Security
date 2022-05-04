using Penguin.Security.Abstractions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Cms.Security.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class UserExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Adds a group to the targets group list
        /// </summary>
        /// <param name="target">The target to add the group to</param>
        /// <param name="thisGroup">The group to add</param>
        public static void AddGroup(this User target, Group thisGroup)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (thisGroup is null)
            {
                throw new ArgumentNullException(nameof(thisGroup));
            }

            target.Groups = target.Groups ?? new List<Group>();

            if (!target.HasGroup(thisGroup))
            {
                target.Groups.Add(thisGroup);
            }
        }

        /// <summary>
        /// Adds a role to the targets role list
        /// </summary>
        /// <param name="target">The target to add a role to</param>
        /// <param name="thisRole">The role to add</param>
        public static void AddRole(this User target, Role thisRole)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (thisRole is null)
            {
                throw new ArgumentNullException(nameof(thisRole));
            }

            target.Roles = target.Roles ?? new List<Role>();

            if (!target.HasRole(thisRole))
            {
                target.Roles.Add(thisRole);
            }
        }

        /// <summary>
        /// Adds a role to the targets role list
        /// </summary>
        /// <param name="target">The target to add a role to</param>
        /// <param name="thisRole">The role to add</param>
        public static void AddRole(this Group target, Role thisRole)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (thisRole is null)
            {
                throw new ArgumentNullException(nameof(thisRole));
            }

            target.Roles = target.Roles ?? new List<Role>();

            if (!target.HasRole(thisRole))
            {
                target.Roles.Add(thisRole);
            }
        }

        /// <summary>
        /// Removes a specified group from the objects group list
        /// </summary>
        /// <param name="target">The object to remove the group from</param>
        /// <param name="thisGroup">The group to remove</param>
        public static void RemoveGroup(this User target, Group thisGroup)
        {
            if (thisGroup is null)
            {
                throw new ArgumentNullException(nameof(thisGroup));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (target.Groups is null)
            {
                return;
            }

            if (target.HasGroup(thisGroup))
            {
                _ = target.Groups.Remove(target.Groups.First(g => string.Equals(thisGroup.Name, g.ExternalId, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}