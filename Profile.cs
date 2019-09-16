using Penguin.Cms.Entities;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace Penguin.Cms.Security
{
    /// <summary>
    /// A data wrapper for custom user information attached to a used object
    /// </summary>
    public partial class UserProfile : UserAuditableEntity
    {
        /// <summary>
        /// Contains a list of key value pair style objects with additional information for users
        /// </summary>
        [EagerLoad]
        public List<ProfileData> Fields { get; set; } = new List<ProfileData>();

        /// <summary>
        /// The user that this profile object applies to
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Deserializes a concrete representation of a user profile from the fields attached to this object
        /// </summary>
        /// <typeparam name="T">A type representing a collection of user profile information</typeparam>
        /// <returns>The deserialized concrete user profile instance</returns>
        public T GetData<T>()
        {
            T toReturn = Activator.CreateInstance<T>();

            foreach (ProfileData pd in this.Fields)
            {
                PropertyInfo prop = typeof(T).GetProperty(pd.Name);

                if (pd != null)
                {
                    prop.SetValue(toReturn, pd.Value.Convert(prop.PropertyType));
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Sets the ProfileData fields by reflecting over a concrete instance of a User Profile object
        /// </summary>
        /// <param name="data">The object to use as the data source from the fields</param>
        public void SetData(object data)
        {
            Contract.Requires(data != null);

            foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
            {
                string Name = propertyInfo.Name;
                string Value = propertyInfo.GetValue(data)?.ToString();

                ProfileData existing = this.Fields?.Where(f => f.Name == Name).FirstOrDefault();

                if (existing is null)
                {
                    this.Fields.Add(new ProfileData() { Name = Name, Value = Value });
                }
                else
                {
                    existing.Value = Value;
                }
            }
        }
    }
}