// Library
// Joakim Sehlstedt
// 11 Dec 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    /// <summary>
    /// Derived context.
    /// </summary>
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
            : base("SocialMediaConnection")
        {
            // Database strategy
            Database.SetInitializer<SocialMediaContext>(new SocialMediaDbInit());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }


        // If you want to try or need to (some use cases) use fluent API this is the place!
        // Reference: http://blogs.msdn.com/b/adonet/archive/2010/12/14/ef-feature-ctp5-fluent-api-samples.aspx
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Derived database strategy
    /// </summary>
    class SocialMediaDbInit : DropCreateDatabaseIfModelChanges<SocialMediaContext>
    {
        protected override void Seed(SocialMediaContext context)
        {
            base.Seed(context);

            // Seed your data here!
        }
    }
}