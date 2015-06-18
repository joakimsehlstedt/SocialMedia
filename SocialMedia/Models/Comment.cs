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
    /// Comment class. 
    /// Stores the relevant data for a comment made on a post. Comments are not stored
    /// in a seperate database table but they are collected in a list in the post itself.
    /// </summary>
    public class Comment {
        /// <summary>
        /// Default constructor set's the DateCreated to now.
        /// </summary>
        public Comment() {
            DateCreated = DateTime.Now;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Author { get; set; }
    }
}