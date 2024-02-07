using Microsoft.EntityFrameworkCore;
using ShareHere.Database.Context;
using ShareHere.Database.Models;
using ShareHere.Repository.Interfaces;
using ShareHere.Repository.ObserverClasses;
using static ShareHere.Database.Models.Enums;

namespace ShareHere.Repository.FactoryRepositories
{
    public class BlogFactoryRepository : IBlogFactoryRepository
    {
        private readonly ShareHereContext context;
        private List<ObserverClass> observers = new List<ObserverClass>
        {
            new ObserverClass{
                Name = "Alice"
            },
            new ObserverClass{
                Name = "Bob"
            }
        };
        public BlogFactoryRepository(ShareHereContext shareHereContext)
        {
            this.context = shareHereContext ?? throw new ArgumentNullException(nameof(shareHereContext));
        }
        public async Task<List<string>> AddBlog(BlogTypes blogType) 
        {
            if(BlogTypes.Tech.Equals(blogType)) 
            {
                var newBlog = new TechBlog
                {
                    Id = Guid.NewGuid(),
                    Title = "Tech",
                    Content = "Tech"
                };
                context.TechBlogs.Add(newBlog);
                await context.SaveChangesAsync();
            }
            else if (BlogTypes.Political.Equals(blogType))
            {
                var newBlog = new PoliticalBlog
                {
                    Id = Guid.NewGuid(),
                    Title = "Political",
                    Content = "Political"
                };
                context.PoliticalBlogs.Add(newBlog);
                await context.SaveChangesAsync();
            }
            else if (BlogTypes.Food.Equals(blogType))
            {
                var newBlog = new FoodBlog
                {
                    Id = Guid.NewGuid(),
                    Title = "Food",
                    Content = "Food"
                };
                context.FoodBlogs.Add(newBlog);
                await context.SaveChangesAsync();
            }
            
            return NotifyObservers(blogType);
        }

        public async Task<List<TechBlog>> GetTechBlogs()
        {
            var ret = await context.TechBlogs.ToListAsync();
            return ret;
        }
        public async Task<List<PoliticalBlog>> GetPoliticalBlogs()
        {
            return await context.PoliticalBlogs.ToListAsync();
        }
        public async Task<List<FoodBlog>> GetFoodBlogs()
        {
            return await context.FoodBlogs.ToListAsync();
        }

        private List<string> NotifyObservers(BlogTypes blogTypes)
        {
            List<string> ret = new List<string>();
            
            return observers.Select(obserber => obserber.NotifyObsevers(blogTypes)).ToList();
        }
    }
}
                                                                                                        