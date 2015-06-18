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
    /// A base model for a person in a very slimmed down format.
    /// Contains the username and can be used wherever a reference
    /// to a user is needed without using the full User class.
    /// </summary>
    public class Person {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
    }
}