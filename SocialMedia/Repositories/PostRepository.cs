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
    public class PostRepository {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// PostRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public PostRepository(SocialMediaContext context) {
            db = context;
        }

        /// <summary>
        /// Add a post to the data storage.
        /// </summary>
        /// <param name="post">The post to add.</param>
        public void Add(Post post) {
            db.Posts.Add(post);
            db.SaveChanges();
        }

        /// <summary>
        /// Retrive a post by its id.
        /// </summary>
        /// <param name="id">The post id.</param>
        public Post GetById(int id) {
            var post = db.Posts.Find(id);
            return post;
        }

        /// <summary>
        /// Get a list of all posts.
        /// </summary>
        public IEnumerable<Post> All() {
            return db.Posts.ToList();
        }

        /// <summary>
        /// Get a list of all posts by a specific username.
        /// </summary>
        public IEnumerable<Post> AllByUser(string username) {
            return db.Posts.Where(p => p.Author == username).ToList();
        }

        /// <summary>
        /// Delete all posts in storage.
        /// </summary>
        public void RemoveAll() {
            db.Posts.RemoveRange(this.All());
            db.SaveChanges();
        }

        /// <summary>
        /// Update a post already existing in database context.
        /// </summary>
        /// <param name="newPost">The post with the updated data.</param>
        public void Edit(Post newPost) {
            db.Entry(newPost).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


    }
}
