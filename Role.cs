using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Relations;
using System.Collections.Generic;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// The smallest unit of permission, representing the fundamental reason any group might need to access a resource
    /// </summary>
    [Table("Roles")]
    public class Role : GroupRole
    {
        /// <summary>
        /// Virtual list of Groups that are directly assigned this role
        /// </summary>
        [EagerLoad(1)]
        [DontAllow(DisplayContexts.Any)]
        public virtual List<Group> Groups { get; set; }

        /// <summary>
        /// Virtual list of Users that are directly assigned this role
        /// </summary>
        [EagerLoad(1)]
        [DontAllow(DisplayContexts.Any)]
        public virtual List<User> Users { get; set; }
    }
}