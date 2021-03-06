﻿using Penguin.Persistence.Abstractions;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// A Key Value pair representing a single profile field
    /// </summary>
    public partial class ProfileData : KeyedObject
    {
        /// <summary>
        /// The name of the field
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the field
        /// </summary>
        public string Value { get; set; }
    }
}