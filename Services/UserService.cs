using Penguin.Cms.Email.Abstractions.Attributes;
using Penguin.DependencyInjection.Abstractions.Interfaces;
using Penguin.Email.Abstractions.Interfaces;
using Penguin.Email.Templating.Abstractions.Extensions;
using Penguin.Email.Templating.Abstractions.Interfaces;
using Penguin.Persistence.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Cms.Security.Services
{
    /// <summary>
    /// This class provides basic CMS methods for managing and interacting with users
    /// </summary>
    public class UserService : IRegisterMostDerived, IEmailHandler
    {
        /// <summary>
        /// An IRepository implementation for accessing authentication tokens
        /// </summary>
        protected IRepository<AuthenticationToken> AuthenticationTokenRepository { get; set; }

        /// <summary>
        /// An email template repository
        /// </summary>
        protected ISendTemplates EmailTemplateRepository { get; set; }

        protected IRepository<User> UserRepository { get; set; }

        /// <summary>
        /// Constructs a new instance of this service
        /// </summary>
        /// <param name="userRepository">A user repository</param>
        /// <param name="emailTemplateRepository">An email template repository</param>
        /// <param name="authenticationTokenRepository">An IRepository implementation for accessing authentication tokens</param>
        public UserService(IRepository<User> userRepository, ISendTemplates emailTemplateRepository, IRepository<AuthenticationToken> authenticationTokenRepository)
        {
            this.UserRepository = userRepository;
            this.EmailTemplateRepository = emailTemplateRepository;
            this.AuthenticationTokenRepository = authenticationTokenRepository;
        }

        /// <summary>
        /// Gets a user using any valid authentication token
        /// </summary>
        /// <param name="token">The token to use to get the user</param>
        /// <returns>A user if a the token is valid, otherwise null</returns>
        public User GetByAuthenticationToken(AuthenticationToken token)
        {
            if (this.AuthenticationTokenRepository.Where(t => t.User == token.User && t.Guid == token.Guid && t.Expiration > DateTime.Now).Any())
            {
                return this.UserRepository.Where(u => u.Guid == token.User).FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Gets a user using any valid authentication token
        /// </summary>
        /// <param name="token">The token to use to get the user</param>
        /// <returns>A user if a the token is valid, otherwise null</returns>
        public User GetByAuthenticationToken(Guid token)
        {
            if (this.AuthenticationTokenRepository.SingleOrDefault(t => t.Guid == token && t.Expiration > DateTime.Now) is AuthenticationToken matchedToken)
            {
                return this.UserRepository.Where(u => u.Guid == matchedToken.User).FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Returns an authentication token that can be used to reset a password. If email templating is bundled, will send out a password reset email
        /// </summary>
        /// <param name="Login">The login for the user to request</param>
        /// <returns>Returns an authentication token that can be used to reset a password.</returns>
        public AuthenticationToken RequestPasswordReset(string Login)
        {
            return this.RequestPasswordReset(this.UserRepository.Find(Login), Guid.Empty);
        }

        /// <summary>
        /// Returns an authentication token that can be used to reset a password. If email templating is bundled, will send out a password reset email
        /// </summary>
        /// <param name="targetUser">The login for the user to request</param>
        /// <param name="Token">Parameter only used by email templating system</param>
        /// <returns>Returns an authentication token that can be used to reset a password.</returns>
        [EmailHandler("Request Password Reset")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public AuthenticationToken RequestPasswordReset(User targetUser, Guid Token)
        {
            if (targetUser != null)
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] stringChars = new char[16];
                Random random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                Token = Guid.NewGuid();

                this.EmailTemplateRepository.TrySendTemplate(new Dictionary<string, object>()
                {
                    [nameof(targetUser)] = targetUser,
                    [nameof(Token)] = Token
                });

                AuthenticationToken token;

                using (this.AuthenticationTokenRepository.WriteContext())
                {
                    token = new AuthenticationToken()
                    {
                        Expiration = DateTime.Now.AddMinutes(30),
                        User = this.UserRepository.Find(targetUser._Id).Guid,
                        Guid = Token
                    };

                    this.AuthenticationTokenRepository.AddOrUpdate(token);
                }

                return token;
            }

            return null;
        }

        /// <summary>
        /// If email templating is enabled, Sends the specified email a message containing the login name of any associated user account
        /// </summary>
        /// <param name="Email">The email to send information to</param>
        public void SendLoginInformation(string Email)
        {
            this.SendLoginInformation(this.UserRepository.FirstOrDefault(u => u.Email == Email));
        }

        /// <summary>
        /// If email templating is enabled, Sends the specified email a message containing the login name of any associated user account
        /// </summary>
        /// <param name="targetUser">The user to send login information to</param>
        [EmailHandler("Request Login")]
        public void SendLoginInformation(User targetUser)
        {
            if (targetUser != null)
            {
                this.EmailTemplateRepository.GenerateEmailFromTemplate(new Dictionary<string, object>()
                {
                    [nameof(targetUser)] = targetUser
                });
            }
        }
    }
}