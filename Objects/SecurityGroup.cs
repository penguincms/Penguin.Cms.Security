using Penguin.Cms.Entities;
using Penguin.Entities;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using Penguin.Security.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// The most shared class for any object that can be given access to another object, including Roles, Groups, and Users
    /// </summary>
    [Serializable]
    public class SecurityGroup : UserAuditableEntity, ISecurityGroup // This class cant be abstract because the model binder cant create an instance when posting json
    {
        /// <summary>
        /// The GUID for the group. Used for allowing access without needing to reference a specific instance of the object
        /// </summary>
        [DontAllow(DisplayContexts.Edit | DisplayContexts.List)]
        public override Guid Guid
        {
            get
            {
                //We only want a static guid if the model is populated
                //The model binder uses guid to generate temporary entities
                //so if we wholesale drop the guid being used to "set" then
                //When we try to get it again we will get a null string based guid,
                //which loses the identity of the object. This is a terrible hack to prevent that
                //by storing the "set" guid in the underlying object and only returning it
                //if the object is "empty". we cant use id = 0 because then it would not
                //store properly for new objects
                if (!Guid.TryParse(this.ExternalId, out Guid _))
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(this.TypeName + "." + this.ExternalId));
                        return new Guid(hash);
                    }
                }
                else
                {
                    return base.Guid;
                }
            }
            set
            {
                base.Guid = value;
            }
        }

        /// <summary>
        /// The source for the security group when it was created
        /// </summary>
        public SecurityGroupSource Source { get; set; }

        /// <summary>
        /// What describes the use of this object?
        /// </summary>
        [Display(Order = -900)]
        public string Description { get; set; }

        /// <summary>
        /// Represents the a list of options for the source of this security group
        /// </summary>
        public enum SecurityGroupSource
        {
            /// <summary>
            /// The group was created by the system as part of its core functionality
            /// </summary>
            System,

            /// <summary>
            /// The group was created by the client to extend functionality
            /// </summary>
            Client,

            /// <summary>
            /// The group was automatically pulled from Active Directory
            /// </summary>
            ActiveDirectory
        }

        /// <summary>
        /// Compares based on the type and the ExternalId
        /// </summary>
        /// <param name="obj1">The first object</param>
        /// <param name="obj2">The second object</param>
        /// <returns>If they are NOT equal</returns>
        public static bool operator !=(SecurityGroup obj1, SecurityGroup obj2)
        {
            if (obj1 is null ^ obj2 is null)
            {
                return true;
            }
            else if (obj1 is null && obj2 is null)
            {
                return false;
            }
            else
            {
                return obj1?.GetHashCode() != obj2?.GetHashCode();
            }
        }

        /// <summary>
        /// Compares based on the type and the ExternalId
        /// </summary>
        /// <param name="obj1">The first object</param>
        /// <param name="obj2">The second object</param>
        /// <returns>If they are equal</returns>
        public static bool operator ==(SecurityGroup obj1, SecurityGroup obj2)
        {
            if (obj1 is null ^ obj2 is null)
            {
                return false;
            }
            else if (obj1 is null && obj2 is null)
            {
                return true;
            }
            else
            {
                return obj1?.GetHashCode() == obj2?.GetHashCode();
            }
        }

        /// <summary>
        /// Compares based on the type and the ExternalId
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>If they are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Entity))
            {
                return false;
            }
            else
            {
                return object.ReferenceEquals(this, obj) || ((obj as Entity).GetHashCode() == this.GetHashCode());
            }
        }

        /// <summary>
        /// Hashes the Type and the External ID
        /// </summary>
        /// <returns>Hashes the Type and the External ID</returns>
        public override int GetHashCode() => this.TypeName.GetHashCode() + this.ExternalId.GetHashCode();

        /// <summary>
        /// Returns the ExternalId
        /// </summary>
        /// <returns>The ExternalId</returns>
        public override string ToString() => this.ExternalId;
    }
}