using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialMedia.Models;

namespace SocialMedia.ViewModels {
    public class TwoUserModel {
        public User User { get; private set; }
        public User OtherUser { get; private set; }

        public TwoUserModel(User first, User second) {
            this.User = first;
            this.OtherUser = second;
        }
    }
}