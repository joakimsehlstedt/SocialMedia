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
    /// Viewmodel for sending comment content and and id of 
    /// the post the comment is connected to from a view to
    /// it's controller.
    /// </summary>
    public class CommentModel : PostModel {
        [Required]
        public int Id { get; set; }
    }
}