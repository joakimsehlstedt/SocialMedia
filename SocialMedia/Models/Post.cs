// Library
// Joakim Sehlstedt
// 11 Dec 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models {
    /// <summary>
    /// Holds the relevant data related to a single post and is stored
    /// in a database table called Posts.
    /// Subclass to the comment class and holds a 
    /// comment list and likes list as well as the variables from the 
    /// baseclass.
    /// </summary>
    [Table("Posts")]
    public class Post : Comment {
        /// <summary>
        /// Default constructor instantiates the comments and likes lists.
        /// </summary>
        public Post() : base() {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}