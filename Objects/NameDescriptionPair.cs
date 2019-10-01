using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Cms.Security.Objects
{
    /// <summary>
    /// A struct containing both a name and description for a security object
    /// </summary>
    public struct NameDescriptionPair
    {
        /// <summary>
        /// A description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the security object
        /// </summary>
        public string Name { get; set; }
    }
}