using Penguin.Cms.Attributes;
using Penguin.Cms.Security.Interfaces;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Relations;
using System;
using System.Collections.Generic;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Represents a collection of roles used to assign permissions
    /// </summary>
    [Serializable]
    [Table("Groups")]
    public class Group : GroupRole, IHasRoles
    {
        #region Properties

        /// <summary>
        /// The roles granted to members of this group
        /// </summary>
        [ManyToMany]
        [EagerLoad(1)]
        [CustomRoute(DisplayContext.List, "Render", "AsCSV")]
        [CustomRoute(DisplayContext.Edit, "Edit", "SecurityGroupSelector", "Admin")]
        public List<Role> Roles { get; set; }

        /// <summary>
        /// A virtual list of users assigned to this group
        /// </summary>
        [DontAllow(DisplayContext.Any)]
        [EagerLoad(1)]
        public virtual List<User> Users { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new instance of a group and initializes the role list
        /// </summary>
        public Group()
        {
            this.Roles = new List<Role>();
        }

        #endregion Constructors
    }
}