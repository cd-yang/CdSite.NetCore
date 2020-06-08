using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CdSite.Repository.Data;
using CdSite.Model.Model;
using System.Collections.Generic;

namespace CdSite
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            await EnsureTestAdminAsync(userManager);

            var dbContext = services.GetRequiredService<ApplicationDbContext>();
            EnsurePostsAsync(dbContext);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(UserManager<IdentityUser> userManager)
        {
            var adminUserName = "admin@todo.local";
            var testAdmin = await userManager.Users
            .Where(n => n.UserName == adminUserName)
            .SingleOrDefaultAsync();

            if (testAdmin != null)
                return;

            testAdmin = new IdentityUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(testAdmin, "NotSecure123!");
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }

        /// <summary>
        /// ��ʼ�����ݿ�����
        /// </summary>
        public static void EnsurePostsAsync(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any posts.
            if (context.Posts.Any())
            {
                return;   // DB has been seeded
            }

            var author = new Author { Id = 1, Name = "CdYang", Posts = new List<Post>() };
            var posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "No Code ����С��",
                    Slug = "nocode-trend",
                    Author = author,
                    AuthorId = author.Id,
                    ContentAbstract = "ǰһ������˵��һ�����ʴ� No Code��ֱ��������ǡ����롱����Ե�һ��Ӧ�Ƿ��ԣ�Fenng���Ĺ�˾��Ȼ������д�Ĳ�������� >_<",
                    CreateOnUtc = DateTime.Parse("2020-03-15"),
                    PubDateUtc = DateTime.Parse("2020-03-15"),
                    IsPublished = true
                },
                new Post
                {
                    Id = 2,
                    Title = "Electron��require����Ľ�������",
                    Slug = "electron-require-error",
                    Author = author,
                    AuthorId = author.Id,
                    ContentAbstract = "������Electron 7 ʹ�� Create-React-App ģ�� ����ʱ�����Ĵ���",
                    CreateOnUtc = DateTime.Parse("2020-03-09"),
                    PubDateUtc = DateTime.Parse("2020-03-15"),
                    IsPublished = true
                }

            };
            author.Posts.AddRange(posts);

            context.Posts.AddRange(posts);
            context.Authors.Add(author);
            context.SaveChanges();
        }
    }
}