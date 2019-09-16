using System.Collections.Generic;

namespace Penguin.Cms.Security.Interfaces
{
    /// <summary>
    /// An interface denoting that an object can be assigned to groups
    /// </summary>
    public interface IHasGroups
    {
        /// <summary>
        /// A list of groups that the object belongs to
        /// </summary>
        List<Group> Groups { get; set; }
    }
}