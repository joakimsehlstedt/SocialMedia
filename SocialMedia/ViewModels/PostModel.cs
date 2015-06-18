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
    /// Viewmodel for posting post content from a view to controller
    /// when creating a new post.
    /// </summary>
    public class PostModel {
        [Required]
        public string Content { get; set; }
    }
}