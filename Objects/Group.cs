using Penguin.Cms.Attributes;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Relations;
using Penguin.Security.Abstractions.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Represents a collection of roles used to assign permissions
    /// </summary>
    [Table("Groups")]
    public class Group : GroupRole, IGroup<IRole>, IGroup
    {
        /// <summary>
        /// The roles granted to members of this group
        /// </summary>
        [ManyToMany]
        [EagerLoad(1)]
        [CustomRoute(DisplayContexts.List, "Render", "AsCSV")]
        [CustomRoute(DisplayContexts.Edit, "Edit", "SecurityGroupSelector", "Admin")]
        public List<Role> Roles { get; set; }

        /// <summary>
        /// A virtual list of users assigned to this group
        /// </summary>
        [DontAllow(DisplayContexts.Any)]
        [EagerLoad(1)]
        public virtual IList<User> Users { get; set; }
        IReadOnlyList<IRole> IHasRoles<IRole>.Roles => Roles;


        /// <summary>
        /// Creates a new instance of a group and initializes the role list
        /// </summary>
        public Group()
        {
            this.Roles = new List<Role>();
        }
    }
}