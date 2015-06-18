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
    /// To store the relevant data related to a user.
    /// Has it's own database table "Users".
    /// </summary>
    [Table("Users")]
    public class User {
        /// <summary>
        /// Default constructor creates list objects for the
        /// roles and friends property.
        /// </summary>
        public User() {
            Roles = new List<Role>();
            Friends = new List<Friend>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }
    }
}