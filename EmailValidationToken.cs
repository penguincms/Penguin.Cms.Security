using Penguin.Cms.Entities;
using System;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Used to track whether or not a user has validated their email
    /// </summary>
    public class EmailValidationToken : AuditableEntity
    {
        /// <summary>
        /// The Guid of the user that created this token
        /// </summary>
        public Guid Creator { get; set; }

        /// <summary>
        /// True if the user has validated this token by clicking the link in their email
        /// </summary>
        public bool IsValidated { get; set; }
    }
}