using Penguin.Auditing.Abstractions;
using Penguin.Auditing.Abstractions.Attributes;
using Penguin.Cms.Entities;

using System;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// A token intended to serve as a temporary login for API access, or password resets
    /// </summary>
    [DontAuditChanges]
    public class AuthenticationToken : Entity
    {
        /// <summary>
        /// When this token will expire
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Guid representing the user this token is tied to
        /// </summary>
        public Guid User { get; set; }
    }
}