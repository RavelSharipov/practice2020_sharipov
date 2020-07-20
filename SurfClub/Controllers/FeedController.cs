using SurfClub.DAL;
using SurfClub.Helpers;
using SurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurfClub.Controllers
{
    public class FeedController : Controller
    {
        private SurfDbContext dbContext = new SurfDbContext();
        // GET: Feed
        public ActionResult Index()
        {
            var posts = dbContext.Posts.ToList();
            ViewBag.Posts = posts;
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {

            if (imageData == null &&
                model.Text == null)
            {
                ModelState.AddModelError(string.Empty, "Не загружено изображение и отсутствует текст");
                var postsInDb = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = postsInDb;
                return View("Index", model);
            }

            model.PublishDate = DateTime.Now;


            if (imageData != null)
            {
                model.Photo = ImageSaveHelper.SaveImage(imageData); 
            }

            var userId = Convert.ToInt32(Session["UserId"]);
            var userInDb = dbContext.Users.FirstOrDefault(c => c.Id == userId);

            model.Author = userInDb;

            dbContext.Posts.Add(model);

            dbContext.SaveChanges();

            var posts = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;

            return View("Index");
        }
    }
}