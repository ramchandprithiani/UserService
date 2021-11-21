using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Core
{
    public interface IUserProcessor
    {
        Task<User> FetchUser(string username, CancellationToken cancellationToken);
        Task<User> SaveUser(User user, CancellationToken cancellation);
        bool IsValidUser(User user);

    }
    public class UserProcessor : IUserProcessor
    {
        private static readonly SimpleUserRepository _repository = new();

        /// <summary>
        /// Saves the given user.
        /// </summary>
        /// <param name="user">The user to save - no ID set</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A Task, with `null` when the user wasn't saved, and with the `user` object when saved</returns>
        public Task<User> SaveUser(User user, CancellationToken cancellationToken)
        {
            if (!IsValidUser(user))
            {
                return null;
            }

            return Task.FromResult(_repository.Save(user));
        }

        /// <summary>
        /// Fetching the user by id
        /// </summary>
        /// <param name="userId">The user id to fetch</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task, with `null` if not present, and with the `user` when present</returns>
        public Task<User> FetchUser(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.Get(userId));
        }

        public bool IsValidUser(User user)
        {
            if (null == user) return false;

            return IsUsernameAllowed(user);
        }

        private bool IsUsernameAllowed(User user)
        {
            // TODO This is our most important method to implement. We really need to think about this.
            // We should NOT allow users to be registered with any of these conditions: (our legacy systems doesn't allow it)
            // 1. If name contains any mention of "user" or "admin". 
            // 2. If name contains any characters but letters and space.

            return (!string.IsNullOrWhiteSpace(user.Name)
                && !user.Name.ToLowerInvariant().Contains("user")
                && !user.Name.ToLowerInvariant().Contains("admin")
                && Regex.IsMatch(user.Name, "^[a-zA-Z\\s]+$"));

          
        }
    }

    /// <summary>
    /// Very useful for our POC.
    ///
    /// TODO When launching the MVP this should be a SQL repository. We would benefit with a reasonable abstraction until then. HOWEVER, no need for us to implement a SQL repository just yet - just prepare for it...
    /// </summary>
    public class SimpleUserRepository : IUserRepository
    {
        private IDictionary<string, User> Users { get; } = new Dictionary<string, User>();

        public User Save(User user)
        {
            user.Id ??= Guid.NewGuid().ToString();

            Users[user.Id] = user;

            return user;
        }

        public User Get(string userId)
        {
            return Users[userId];
        }
    }

    public interface IUserRepository
    {
        public User Get(string userId);
        public User Save(User user);
    }

    /// <summary>
    /// This is a great domain model that should be persisted as-is. No need to change my internals
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id of the user - may be null for non-saved entities
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A string which contains uppercase and/or lowercase letters and optionally one or more spaces.
        /// </summary>
        public string Name { get; set; }
    }
}