using SurfClub.Models.DBModels;
using System;
using System.Data.Entity;

namespace SurfClub.DAL
{
    public class SurfDbInitializer : DropCreateDatabaseAlways<SurfDbContext>
    // DropCreateDataBaseIfModelChanges<SurfDbContext>
    {
        protected override void Seed(SurfDbContext context)
        {
            var user = new User
            {
                Nickname = "vsel",
                Password = "1234567",
                Lastname = "Иванов",
                Name = "Иван",
                Email = "vsel@star.ru",
                About = "Я такой хороший!"
            };

            var post1 = new Post
            {
                Text = "Первый тестовый пост",
                Photo = System.Guid.NewGuid(),
                PublishDate = DateTime.Now,
                Author = user
            };

            var post2 = new Post
            {
                Text = "Второй тестовый пост",
                Photo = System.Guid.NewGuid(),
                PublishDate = DateTime.Now,
                Author = user
            };


            context.Users.Add(user);
            context.Posts.Add(post1);
            context.Posts.Add(post2);
            context.SaveChanges();
        }
    }
}