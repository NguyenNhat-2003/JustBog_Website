﻿using Microsoft.AspNetCore.Identity;
using WebBlog.Data.Models;

namespace WebBlog.Data.Data
{
    public static class SeedData
    {
        public static void Initialize(WebBlogDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            // Create roles
            var roles = new List<Role>
        {
            new Role() { Id = Guid.NewGuid(), Name = "Admin", Description = "Admin Role" },
            new Role() { Id = Guid.NewGuid(), Name = "User", Description = "User Role" }
        };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role.Name).Result)
                {
                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        // Handle role creation errors
                        throw new Exception($"Error creating role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
            }

            // Create users
            var admin = new User() { Id = Guid.NewGuid(), UserName = "admin", Email = "admin@fpt.com", FirstName = "admin", IsActive = true };
            var regularUser = new User() { Id = Guid.NewGuid(), UserName = "user", Email = "user@fpt.com", FirstName = "user", IsActive = true };

            var adminResult = userManager.CreateAsync(admin, "P@ssword123").Result;
            var userResult = userManager.CreateAsync(regularUser, "P@ssword123").Result;

            if (!adminResult.Succeeded || !userResult.Succeeded)
            {
                // Handle user creation errors
                throw new Exception($"Error creating user: {string.Join(", ", adminResult.Errors.Select(e => e.Description))} {string.Join(", ", userResult.Errors.Select(e => e.Description))}");
            }

            // Assign roles to users
            var adminRoleResult = userManager.AddToRoleAsync(admin, "Admin").Result;
            var userRoleResult = userManager.AddToRoleAsync(regularUser, "User").Result;

            if (!adminRoleResult.Succeeded || !userRoleResult.Succeeded)
            {
                // Handle role assignment errors
                throw new Exception($"Error assigning roles: {string.Join(", ", adminRoleResult.Errors.Select(e => e.Description))} {string.Join(", ", userRoleResult.Errors.Select(e => e.Description))}");
            }

            // Seed Categories
            var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Technology", UrlSlug = "technology", Description = "Tech news and articles" },
            new Category { Id = Guid.NewGuid(), Name = "Science", UrlSlug = "science", Description = "Science news and articles" },
            new Category { Id = Guid.NewGuid(), Name = "Health", UrlSlug = "health", Description = "Health news and tips" },
            new Category { Id = Guid.NewGuid(), Name = "Travel", UrlSlug = "travel", Description = "Travel guides and tips" },
            new Category { Id = Guid.NewGuid(), Name = "Food", UrlSlug = "food", Description = "Food recipes and reviews" }
        };
            context.Categories.AddRange(categories);

            // Seed Tags
            var tags = new List<Tag>
        {
            new Tag { Id = Guid.NewGuid(), Name = "AI", UrlSlug = "ai", Description = "Artificial Intelligence" },
            new Tag { Id = Guid.NewGuid(), Name = "Future", UrlSlug = "future", Description = "Future" },
            new Tag { Id = Guid.NewGuid(), Name = "Fitness", UrlSlug = "fitness", Description = "Health and fitness" },
            new Tag { Id = Guid.NewGuid(), Name = "Adventure", UrlSlug = "adventure", Description = "Adventure travel" }
        };
            context.Tags.AddRange(tags);

            // Seed Posts
            var posts = new List<Post>
        {
            new Post { Id = Guid.NewGuid(), Title = "The Rise of AI", Description = "An overview of artificial intelligence.", Content = "Content about AI...", UrlSlug = "the-rise-of-ai", PostedOn = DateTime.Now, Published = true, CategoryId = categories[0].Id },
            new Post { Id = Guid.NewGuid(), Title = "Exploring Space", Description = "Latest news on space exploration.", Content = "Content about space...", UrlSlug = "exploring-space", PostedOn = DateTime.Now, Published = true, CategoryId = categories[1].Id },
            new Post { Id = Guid.NewGuid(), Title = "Healthy Living Tips", Description = "Tips for a healthier lifestyle.", Content = "Content about health...", UrlSlug = "healthy-living-tips", PostedOn = DateTime.Now, Published = false, CategoryId = categories[2].Id },
            new Post { Id = Guid.NewGuid(), Title = "Top Travel Destinations", Description = "Best places to travel this year.", Content = "Content about travel...", UrlSlug = "top-travel-destinations", PostedOn = DateTime.Now, Published = true, CategoryId = categories[3].Id },
        };
            context.Posts.AddRange(posts);

            // Seed PostTagMap
            var postTagMaps = new List<PostTagMap>
        {
            new PostTagMap { PostId = posts[0].Id, TagId = tags[0].Id },
            new PostTagMap { PostId = posts[0].Id, TagId = tags[1].Id },
            new PostTagMap { PostId = posts[1].Id, TagId = tags[1].Id },
            new PostTagMap { PostId = posts[2].Id, TagId = tags[2].Id }
        };
            context.PostTagMaps.AddRange(postTagMaps);

            context.SaveChanges();
        }
    }
}
