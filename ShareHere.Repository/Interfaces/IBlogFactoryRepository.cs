using ShareHere.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShareHere.Database.Models.Enums;

namespace ShareHere.Repository.Interfaces
{
    public interface IBlogFactoryRepository
    {
        Task<List<string>> AddBlog(BlogTypes blogType);
        Task<List<TechBlog>> GetTechBlogs();
        Task<List<PoliticalBlog>> GetPoliticalBlogs();
        Task<List<FoodBlog>> GetFoodBlogs();
    }
}
