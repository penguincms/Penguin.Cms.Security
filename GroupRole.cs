﻿using Penguin.Persistence.Abstractions.Attributes.Relations;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using System;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Base class for assignable permissions objects
    /// </summary>
    [Serializable]
    public abstract class GroupRole : SecurityGroup
    {
        /// <summary>
        /// Should this permission be assigned to all new users?
        /// </summary>
        [Display(Order = -800)]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Maps to the External ID
        /// </summary>
        [NotMapped]
        [Display(Order = -1000)]
        public string Name { get => ExternalId; set => ExternalId = value; }

        /// <summary>
        /// Returns the Name/ExternalId
        /// </summary>
        /// <returns>The Name/ExternalId</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}