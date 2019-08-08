using Penguin.Cms.Attributes;
using Penguin.Cms.Security.Interfaces;
using Penguin.Extensions.String.Security;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Relations;
using Penguin.Persistence.Abstractions.Attributes.Validation;
using System;
using System.Collections.Generic;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Represents a collection of identifying information and security properties to allow a single person to be tracked and permissioned within a system
    /// </summary>
    [Serializable]
    public partial class User : SecurityGroup, IHasGroupsAndRoles
    {
        #region Properties

        /// <summary>
        /// A contact email for the user
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// If enabled, the user should be allowed to access the system
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// A collection of groups that the user belongs to
        /// </summary>
        [ManyToMany]
        [EagerLoad(2)]
        [DontAllow(DisplayContext.List)]
        [CustomRoute(DisplayContext.Edit, "Edit", "SecurityGroupSelector", "Admin")]
        public List<Group> Groups { get; set; }

        /// <summary>
        /// The post-hash password. Setting this will not alter the password in any way
        /// </summary>
        [DontAllow(DisplayContext.Any)]
        public string HashedPassword { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// A unique log in for the user, used to access the system
        /// </summary>
        [NotMapped]
        public string Login { get => this.ExternalId; set => this.ExternalId = value; }


        /// <summary>
        /// This item should increment every time a log in attempt is failed, and reset when sucessfull
        /// </summary>
        [DontAllow(DisplayContext.List)]
        public int LoginAttempts { get; set; }

        /// <summary>
        /// The password of the user, persisted as a hash. Setting this property will hash the password
        /// </summary>
        [NotMapped]
        [DontAllow(DisplayContext.List)]
        [CustomRoute(DisplayContext.Edit, "User", "ResetPasswordButton", "Admin")]
        public string Password { get => this.HashedPassword; set => this.HashedPassword = value.SHA512(); }

        /// <summary>
        /// A customizable collection of information not otherwise contained on this object
        /// </summary>
        [OptionalToRequired]
        [DontAllow(DisplayContext.Any)]
        public Profile Profile { get; set; }

        /// <summary>
        /// A list of roles directly assigned to the user to ensure access even through group changes
        /// </summary>
        [ManyToMany]
        [EagerLoad(1)]
        [DontAllow(DisplayContext.List)]
        [CustomRoute(DisplayContext.Edit, "Edit", "SecurityGroupSelector", "Admin")]
        public List<Role> Roles { get; set; }

        #endregion Properties

        #region Constructors

       /// <summary>
       /// Creates a new instance of the user object
       /// </summary>
        public User()
        {
            this.Roles = new List<Role>();
            this.Groups = new List<Group>();
            this.Enabled = true;
        }

        #endregion Constructors
    }
}