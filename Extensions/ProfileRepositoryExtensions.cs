using Penguin.Persistence.Abstractions.Interfaces;
using System.Linq;

namespace Penguin.Cms.Security.Extensions
{
    public static class ProfileRepositoryExtensions
    {
        /// <summary>
        /// Returns the user profile for a user with the requested login
        /// </summary>
        /// <param name="login">The login of the user that owns the profile</param>
        /// <returns>The users profile</returns>
        public static UserProfile GetByLogin(this IRepository<UserProfile> repository, string login) => repository.Where(u => u.User.ExternalId == login).FirstOrDefault();
    }
}