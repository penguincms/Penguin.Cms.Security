using Penguin.Cms.Security.Interfaces;
using Penguin.Entities;
using System;
using System.Collections.Generic;

namespace Penguin.Cms.Security.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class SecurityGroupExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        #region Methods

        /// <summary>
        /// Returns a list of Guids representing the user themselves, all groups, and all roles (inc recursive)
        /// </summary>
        /// <param name="target">The user to check</param>
        /// <returns>A list of Guids representing the user themselves, all groups, and all roles (inc recursive)</returns>
        public static IEnumerable<Guid> SecurityGroupGuids(this Security.User target)
        {
            yield return target.Guid;

            foreach (Guid g in GetGroupGuids(target))
            {
                yield return g;
            }

            foreach (Guid g in GetRoleGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Gets a list of security groups for the user containing themselves, all groups, and all roles (inc recursive)
        /// </summary>
        /// <param name="target">The user to retrieve the security groups for</param>
        /// <returns>A list of security groups for the user containing themselves, all groups, and all roles (inc recursive)</returns>
        public static IEnumerable<Security.SecurityGroup> SecurityGroups(this Security.User target)
        {
            yield return target as Security.SecurityGroup;

            foreach (Security.SecurityGroup g in GetGroups(target))
            {
                yield return g;
            }

            foreach (Security.SecurityGroup g in GetRoles(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Gets a list of security group guids for the target containing all groups, and all roles (inc recursive)
        /// </summary>
        /// <param name="target">The user to retrieve the security groups for</param>
        /// <returns>A list of security group guids for the user containing all groups, and all roles (inc recursive)</returns>
        public static IEnumerable<Guid> SecurityGroups(this IHasGroupsAndRoles target)
        {
            if (!((target as Entity) is null))
            {
                yield return (target as Entity).Guid;
            }

            foreach (Guid g in GetGroupGuids(target))
            {
                yield return g;
            }

            foreach (Guid g in GetRoleGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns a list of Guids representing ONLY the groups (not roles) that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing ONLY the groups (not roles) that an object belongs to</returns>
        public static IEnumerable<Guid> SecurityGroups(this IHasGroups target)
        {
            if (!((target as Entity) is null))
            {
                yield return (target as Entity).Guid;
            }

            foreach (Guid g in GetGroupGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns a list of Guids representing ONLY the roles (not groups) that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing ONLY the roles (not groups) that an object belongs to</returns>
        public static IEnumerable<Guid> SecurityGroups(this IHasRoles target)
        {
            if (!((target as Entity) is null))
            {
                yield return (target as Entity).Guid;
            }

            foreach (Guid g in GetRoleGuids(target))
            {
                yield return g;
            }
        }

        /// <summary>
        /// Returns a list of Guids representing groups AND roles that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing groups AND roles that an object belongs to</returns>
        private static IEnumerable<Guid> GetGroupGuids(IHasGroups target)
        {
            foreach (Group thisGroup in target.Groups)
            {
                yield return thisGroup.Guid;

                foreach (Guid g in GetRoleGuids(thisGroup))
                {
                    yield return g;
                }
            }
        }


        /// <summary>
        /// Returns a list of security groups including groups AND roles that an object belongs to
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>A list of Guids representing groups AND roles that an object belongs to</returns>
        private static IEnumerable<Security.SecurityGroup> GetGroups(IHasGroups target)
        {
            foreach (Security.SecurityGroup thisGroup in target.Groups)
            {
                yield return thisGroup;

                foreach (Security.SecurityGroup r in GetRoles(thisGroup as Group))
                {
                    yield return r;
                }
            }
        }

        private static IEnumerable<Guid> GetRoleGuids(IHasRoles target)
        {
            foreach (Role r in target.Roles)
            {
                yield return r.Guid;
            }
        }

        private static IEnumerable<Security.SecurityGroup> GetRoles(IHasRoles target)
        {
            foreach (Security.SecurityGroup r in target.Roles)
            {
                yield return r;
            }
        }

        #endregion Methods
    }
}