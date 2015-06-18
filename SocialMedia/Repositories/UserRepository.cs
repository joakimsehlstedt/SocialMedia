// Library
// Joakim Sehlstedt
// 11 Dec 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialMedia.Models;
using SocialMedia.Providers;

namespace SocialMedia.Repositories {
    /// <summary>
    /// Interface that is used together with the SimpleMembershipProvider.
    /// </summary>
    public interface IUserRepository {
        User GetByUserName(string username);
    }

    public class UserRepository : IUserRepository {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// UserRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(SocialMediaContext context) {
            db = context;
        }

        /// <summary>
        /// Add a user to the data storage.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void Add(User user) {
            // Encrypt password before saving to database
            user.Password = SimpleMembershipProvider.EncryptPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
        }

        /// <summary>
        /// Retrive a user by its username.
        /// </summary>
        /// <param name="username">The username.</param>
        public User GetByUserName(string username) {
            var user = db.Users.FirstOrDefault(
                u => u.Username.ToLower() == username.ToLower()
                );
            return user;
        }

        /// <summary>
        /// Retrive users by a searchstring.
        /// </summary>
        /// <param name="searchString">The searchstring.</param>
        public IEnumerable<User> RangeBySearchString(string searchString) {
            return db.Users.Where(u => u.Username.Contains(searchString)).ToList();
        }

        /// <summary>
        /// Get a list of all users in context.
        /// </summary>
        /// <returns>List of users.</returns>
        public IEnumerable<User> All() {
            return db.Users.ToList();
        }

        /// <summary>
        /// Update a user that already exists in database context.
        /// </summary>
        /// <param name="user">The User with the updated data.</param>
        public void Edit(User user) {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}