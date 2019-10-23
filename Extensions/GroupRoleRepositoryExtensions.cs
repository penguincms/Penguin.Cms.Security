using Penguin.Persistence.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Penguin.Cms.Security.SecurityGroup;

namespace Penguin.Cms.Security.Extensions
{
    public static class GroupRoleRepositoryExtensions
    {
        public static T CreateIfNotExists<T>(this IRepository<T> repository, string Name, string Description, SecurityGroupSource source = SecurityGroupSource.System) where T : SecurityGroup, new()
        {
            T existingGroup = repository.FirstOrDefault(gr => gr.ExternalId == Name);
            if (existingGroup == null)
            {
                T thisGroup = new T()
                {
                    ExternalId = Name,
                    Description = Description,
                    Source = source
                };

                repository.Add(thisGroup);

                return thisGroup;
            }

            return existingGroup;
        }

        public static bool Exists<T>(this IRepository<T> repository, string name) where T : GroupRole => repository.Where(r => r.ExternalId == name).Any();

        /// <summary>
        /// Gets a group or role by name
        /// </summary>
        /// <param name="Name">The name to check for</param>
        /// <returns>The group/role or null</returns>
        public static T GetByName<T>(this IRepository<T> repository, string Name) where T : GroupRole => repository.Where(t => t.ExternalId == Name).SingleOrDefault();

        /// <summary>
        /// Gets any groups/roles that are set to be assigned to all new users
        /// </summary>
        /// <returns>Any groups/roles that are set to be assigned to all new users</returns>
        public static List<T> GetDefaults<T>(this IRepository<T> repository) where T : GroupRole => repository.Where(gr => gr.IsDefault).ToList();
    }
}