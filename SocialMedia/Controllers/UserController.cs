// Library
// Joakim Sehlstedt
// 11 Dec 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialMedia.Models;
using SocialMedia.ViewModels;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers {
    public class UserController : Controller {
        UserRepository _userRepository = RepositoryFactory.GetUserRepository();
        PostRepository _postRepository = RepositoryFactory.GetPostRepository();

        //
        // GET: /User/
        [Authorize]
        public ActionResult Index(string search) {
            IEnumerable<User> allUser;

            if (String.IsNullOrEmpty(search)) {
                allUser = _userRepository.All();
            }
            else {
                allUser = _userRepository.RangeBySearchString(search);
            }

            var user = _userRepository.GetByUserName(this.User.Identity.Name);
            var listmodel = new List<UserModel>();

            foreach (var item in allUser) {
                if (user.Friends.FirstOrDefault(f => f.Username.ToLower() == item.Username.ToLower()) != null) {
                    listmodel.Add(new UserModel() { Friend = true, Username = item.Username });
                }
                else if (item.Username.ToLower() == user.Username.ToLower()) {
                    // Do nothing!
                }
                else {
                    listmodel.Add(new UserModel() { Friend = false, Username = item.Username });
                }
            }
            return View(listmodel);
        }

        //
        // GET: /User/Friends
        [Authorize]
        public ActionResult Friends() {
            var user = _userRepository.GetByUserName(this.User.Identity.Name);
            return View(user.Friends.ToList());
        }

        //
        // GET: /User/Stream
        [Authorize]
        public ActionResult Stream() {
            var allPosts = _postRepository.All();
            var user = _userRepository.GetByUserName(this.User.Identity.Name);
            var listmodel = new List<Post>();

            foreach (var item in allPosts) {
                if (user.Friends.FirstOrDefault(f => f.Username.ToLower() == item.Author.ToLower()) != null
                    || item.Author.ToLower() == user.Username.ToLower()) {
                    listmodel.Add(item);
                }
            }

            var outputList = from p in listmodel
                             orderby p.DateCreated descending
                             select p;

            return View(outputList);
        }

        //
        // GET: /User/Wall
        [Authorize]
        public ActionResult Wall() {
            var postsByUser = _postRepository.AllByUser(this.User.Identity.Name);
            var outputList = from p in postsByUser
                             orderby p.DateCreated descending
                             select p;
            return View(outputList);
        }

        //
        // GET: /User/Create
        [Authorize]
        public ActionResult Create() {
            return View();
        }

        //
        // POST: /User/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(PostModel postModel) {

            Post post = new Post() {
                Author = this.User.Identity.Name,
                Content = postModel.Content
            };

            if (ModelState.IsValid) {
                _postRepository.Add(post);
                return RedirectToAction("Wall");
            }

            return View();
        }

        //
        // GET: /User/Comment
        [Authorize]
        public ActionResult Comment(int id) {
            ViewBag.PostId = id;
            return View();
        }

        //
        // POST: /User/Comment
        [Authorize]
        [HttpPost]
        public ActionResult Comment(CommentModel commentModel) {

            if (ModelState.IsValid) {
                Comment comment = new Comment() {
                    Author = this.User.Identity.Name,
                    Content = commentModel.Content
                };
                Post post = _postRepository.GetById(commentModel.Id);
                post.Comments.Add(comment);

                _postRepository.Edit(post);
                return RedirectToAction("Stream");
            }

            return View();
        }

        //
        // GET: /User/LikePost
        [Authorize]
        public ActionResult LikePost(int id) {
            Post post = _postRepository.GetById(id);
            Like like = new Like() {
                Username = this.User.Identity.Name
            };

            if (post.Likes.FirstOrDefault(l => l.Username.ToLower() == this.User.Identity.Name.ToLower()) == null) {
                post.Likes.Add(like);
                _postRepository.Edit(post);
            }

            return RedirectToAction("Stream");
        }

        //
        // GET: /User/AddFriend
        [Authorize]
        public ActionResult AddFriend(string username) {
            Friend friend = new Friend() {
                Username = username
            };

            if (_userRepository.GetByUserName(username) != null && username.ToLower() != this.User.Identity.Name.ToLower()) {
                User user = _userRepository.GetByUserName(this.User.Identity.Name);
                user.Friends.Add(friend);
                _userRepository.Edit(user);
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /User/Reset
        [Authorize]
        public ActionResult Reset() {
            _postRepository.RemoveAll();
            return RedirectToAction("Stream");
        }

    }
}
