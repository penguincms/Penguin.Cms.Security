using Penguin.Cms.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        public static void AddGroup(this IHasGroups target, Group thisGroup)
        {
            Contract.Requires(target != null);
            Contract.Requires(thisGroup != null);

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
        public static void AddRole(this IHasRoles target, Role thisRole)
        {
            Contract.Requires(target != null);
            Contract.Requires(thisRole != null);

            target.Roles = target.Roles ?? new List<Role>();

            if (!target.HasRole(thisRole))
            {
                target.Roles.Add(thisRole);
            }
        }

        /// <summary>
        /// Returns all roles from associated groups as well as directly assigned
        /// </summary>
        /// <param name="target">The object to retrieve roles for</param>
        /// <returns>An IEnumerable of distinct roles</returns>
        public static IEnumerable<Role> AllRoles(this IHasGroupsAndRoles target)
        {
            Contract.Requires(target != null);

            List<Role> allRoles = new List<Role>();

            if (target.Groups != null)
            {
                foreach (Group g in target.Groups)
                {
                    if (g.Roles != null)
                    {
                        foreach (Role r in g.Roles)
                        {
                            if (!allRoles.Contains(r))
                            {
                                yield return r;
                                allRoles.Add(r);
                            }
                        }
                    }
                }
            }

            if (target.Roles != null)
            {
                foreach (Role r in target.Roles)
                {
                    if (!allRoles.Contains(r))
                    {
                        yield return r;
                        allRoles.Add(r);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the target group list to see if a group exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisGroup">The group to check for</param>
        /// <returns>If the target has the group in its group list</returns>
        public static bool HasGroup(this IHasGroups target, Group thisGroup)
        {
            Contract.Requires(target != null);
            Contract.Requires(thisGroup != null);
            return target.HasGroup(thisGroup.Name);
        }

        /// <summary>
        /// Checks the target group list to see if a group exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="groupName">The group name to check for</param>
        /// <returns>If the target has the group in its group list</returns>
        public static bool HasGroup(this IHasGroups target, string groupName)
        {
            Contract.Requires(target != null);
            return target.Groups.Any(g => string.Equals(groupName, g.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks the target role list and roles associated with groups to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisRole">The role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole(this IHasGroupsAndRoles target, Role thisRole)
        {
            Contract.Requires(target != null);
            Contract.Requires(thisRole != null);
            return target.HasRole(thisRole.Name);
        }

        /// <summary>
        /// Checks the target role list to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="thisRole">The role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole(this IHasRoles target, Role thisRole)
        {
            Contract.Requires(target != null);
            Contract.Requires(thisRole != null);
            return target.HasRole(thisRole.Name);
        }

        /// <summary>
        /// Checks the target role list and roles associated with groups to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="roleName">The name of the role to check for</param>
        /// <returns>If the target has the role</returns>
        public static bool HasRole(this IHasGroupsAndRoles target, string roleName)
        {
            Contract.Requires(target != null);

            List<Role> userRoles = target.Roles ?? new List<Role>();
            List<Role> groupRoles = target.Groups?.SelectMany(g => g.Roles)?.ToList() ?? new List<Role>();
            return userRoles.Any(r => string.Equals(r.Name, roleName, StringComparison.InvariantCultureIgnoreCase)) || groupRoles.Any(r => string.Equals(r.Name, roleName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks the target role list to see if a role exists
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <param name="roleName">The name of the role to check for</param>
        /// <returns>If the target has the role in its role list</returns>
        public static bool HasRole(this IHasRoles target, string roleName)
        {
            Contract.Requires(target != null);

            ICollection<Role> userRoles = target.Roles ?? new List<Role>();
            return userRoles.Any(r => string.Equals(r.Name, roleName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Removes a specified group from the objects group list
        /// </summary>
        /// <param name="target">The object to remove the group from</param>
        /// <param name="thisGroup">The group to remove</param>
        public static void RemoveGroup(this IHasGroups target, Group thisGroup)
        {
            Contract.Requires(target != null);

            if (target.Groups is null)
            {
                return;
            }

            if (target.HasGroup(thisGroup))
            {
                target.Groups.Remove(target.Groups.First(g => string.Equals(thisGroup.Name, g.Name, StringComparison.InvariantCultureIgnoreCase)));
            }
        }

        /// <summary>
        /// Removes a specified role from the objects role list
        /// </summary>
        /// <param name="target">The object to remove the role from</param>
        /// <param name="thisRole">The role to remove</param>
        public static void RemoveRole(this IHasRoles target, Role thisRole)
        {
            Contract.Requires(target != null);
            Contract.Requires(thisRole != null);

            if (target.Roles is null)
            {
                return;
            }

            if (target.HasRole(thisRole))
            {
                target.Roles.Remove(target.Roles.First(r => string.Equals(r.Name, thisRole.Name, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}