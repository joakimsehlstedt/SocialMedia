using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SocialMedia.Models;

namespace SocialMedia.Repositories {
    /// <summary>
    /// This class handles instantiation of the repositories.
    /// </summary>
    public class RepositoryFactory {
        /// <summary>
        /// Wrapper property to get a context instance.
        /// </summary>
        static SocialMediaContext context {
            get { return ContextFactory.GetContext(); }
        }

        /// <summary>
        /// Retrive a user repository instance.
        /// </summary>
        public static UserRepository GetUserRepository() {
            return new UserRepository(context);
        }

        /// <summary>
        /// Retrive a user repository instance.
        /// </summary>
        public static PostRepository GetPostRepository() {
            return new PostRepository(context);
        }

        // More repositories..
    }
}