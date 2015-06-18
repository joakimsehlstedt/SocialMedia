// Library
// Joakim Sehlstedt
// 11 Dec 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialMedia.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.ViewModels {
    /// <summary>
    /// Viewmodel for sending username and the users friends to a view.
    /// </summary>
    public class UserModel {
        [Required]
        public string Username { get; set; }
        public bool Friend { get; set; }
    }
}