using SurfClub.DAL;
using SurfClub.Helpers;
using SurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helpers;
using Xunit;
using Xunit.Sdk;

namespace SurfClub.Controllers
{
    public class FeedController : Controller
    {
        private SurfDbContext dbContext = new SurfDbContext();
        // GET: Feed
        public ActionResult Index()
        {
            var posts = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;

            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {
            if (!ModelState.IsValid)
            {
                var posts1 = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = posts1;
                return View("Index", model);
            }

            if (imageData == null && model.Text == null)
            {
                ModelState.AddModelError(string.Empty, "Не загружено изображение и отсутствует текст");
                var posts1 = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = posts1;
                return View("Index", model);
            }

            model.PublishDate = DateTime.Now;

            if (imageData != null)
            {
                if (!ImageFormatHelper.IsJpg(imageData))
                {
                    ModelState.AddModelError(string.Empty, "Загруженный файл не картинка формата JPG");
                    var posts1 = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
                    ViewBag.Posts = posts1;
                    return View("Index", model);
                }

                model.Photo = ImageSaveHelper.SaveImage(imageData);
            }

            var userId = Convert.ToInt32(Session["UserId"]);
            var userInDb = dbContext.Users.FirstOrDefault(c => c.Id == userId);

            if (userInDb == null)
            {
                //пользователь не авторизован
                TempData["errorMessage"] = "Время сессии истекло. Авторизуйтесь повторно";
                return RedirectToAction("Index", "Home");
            }

            model.Author = userInDb;

            dbContext.Posts.Add(model);
            dbContext.SaveChanges();

            var posts = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;

            ModelState.Clear();

            return View("Index");
        }
    }
}