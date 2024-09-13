using AutoMapper;
using Dal_Repository.Model;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class CategoryDal : IDAL.ICategoryDal
    {
        public async Task<bool> AddAsync(CategoryDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<Category, CategoryDTO>()
                   .ReverseMap()
                   );
                Category category = Mapper.Map<Category>(item);
                await ctx.AddAsync(category);
               await ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Category user = ctx.Categories.Find(id);
                ctx.Categories.Remove(user);
                await ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
      
        public async Task<CategoryDTO> GetAsync(int id)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>().ReverseMap());
                var mapper = config.CreateMapper();
                var category = await ctx.Categories.FindAsync(id);
                return mapper.Map<CategoryDTO>(category);
                //object user = ctx.Users.Find(id);
                //return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<CategoryDTO>> GetAllAsync(Func<CategoryDTO, bool>? condition = null)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                });
                var mapper = config.CreateMapper();
                var users = await ctx.Categories.ToListAsync();
                var categoryDTOs = users.Select(u => mapper.Map<CategoryDTO>(u)).ToList();
                return condition == null ? categoryDTOs : categoryDTOs.Where(condition).ToList();
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool> UpdateAsync(CategoryDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<Category, CategoryDTO>()
                   .ReverseMap()
                   );
                Category u = Mapper.Map<Category>(item);
                ctx.Categories.Update(u);
                int changes = await ctx.SaveChangesAsync();
                return changes > 0;
             
            }
            catch
            {
                return false;
            }
        }

    

    }
}
