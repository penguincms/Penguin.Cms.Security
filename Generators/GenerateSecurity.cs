using Penguin.Cms.Core.Interfaces;
using Penguin.Cms.Core.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Cms.Security.Generators
{
    /// <summary>
    /// Generates the default security users, groups, and roles
    /// </summary>
    public class GenerateSecurity : DefaultEntityGenerator<User>
    {
        /// <summary>
        /// Returns a list of default security users, groups, and roles
        /// </summary>
        /// <returns>An IEnumerable of default security users, groups, and roles</returns>
        public override IEnumerable<User> Generate()
        {
            yield return Users.Admin;

            yield return Users.Guest;
        }
    }
}