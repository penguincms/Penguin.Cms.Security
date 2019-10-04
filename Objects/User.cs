using Penguin.Cms.Attributes;
using Penguin.Extensions.Strings.Security;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Relations;
using Penguin.Persistence.Abstractions.Attributes.Validation;
using Penguin.Security.Abstractions.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// Represents a collection of identifying information and security properties to allow a single person to be tracked and permissioned within a system
    /// </summary>
    public partial class User : SecurityGroup, IUser
    {
        /// <summary>
        /// A contact email for the user
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// If enabled, the user should be allowed to access the system
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// A collection of groups that the user belongs to
        /// </summary>
        [ManyToMany]
        [EagerLoad(2)]
        [DontAllow(DisplayContexts.List)]
        public List<Group> Groups { get; set; } = new List<Group>();

        /// <summary>
        /// The post-hash password. Setting this will not alter the password in any way
        /// </summary>
        [DontAllow(DisplayContexts.Any)]
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
        [DontAllow(DisplayContexts.List)]
        public int LoginAttempts { get; set; }

        /// <summary>
        /// The password of the user, persisted as a hash. Setting this property will hash the password
        /// </summary>
        [NotMapped]
        [DontAllow(DisplayContexts.List)]
        [CustomRoute(DisplayContexts.Edit, "User", "ResetPasswordButton", "Admin")]
        public string Password { get => this.HashedPassword; set => this.HashedPassword = value.ComputeSha512Hash(); }

        /// <summary>
        /// A customizable collection of information not otherwise contained on this object
        /// </summary>
        [OptionalToRequired]
        [DontAllow(DisplayContexts.Any)]
        public UserProfile Profile { get; set; }

        /// <summary>
        /// A list of roles directly assigned to the user to ensure access even through group changes
        /// </summary>
        [ManyToMany]
        [EagerLoad(1)]
        [DontAllow(DisplayContexts.List)]
        public List<Role> Roles { get; set; } = new List<Role>();

        IReadOnlyList<IGroup> IHasGroups.Groups => this.Groups;

        IReadOnlyList<IRole> IHasRoles.Roles => this.Roles;
    }
}