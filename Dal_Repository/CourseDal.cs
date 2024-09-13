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
    public class CourseDal:IDAL.ICourseDal
    {
        public async Task<bool> AddAsync(CourseDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<Course, CourseDTO>()
                   .ReverseMap()
                   );
                Course u = Mapper.Map<Course>(item);
               await ctx.AddAsync(u);
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
                Course user = await ctx.Courses.FindAsync(id);
                ctx.Courses.Remove(user);
                await ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CourseDTO> GetAsync(int id)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Course, CourseDTO>().ReverseMap());
                var mapper = config.CreateMapper();
                var course = await ctx.Courses.FindAsync(id);
                return mapper.Map<CourseDTO>(course);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<CourseDTO>> GetAllAsync(Func<CourseDTO, bool>? condition = null)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Course, CourseDTO>().ReverseMap();
                });
                var mapper = config.CreateMapper();
                var users = await ctx.Courses.ToListAsync();
                var userDtos = users.Select(u => mapper.Map<CourseDTO>(u)).ToList();
                return condition == null ? userDtos : userDtos.Where(condition).ToList();
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool> UpdateAsync(CourseDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<Course, CourseDTO>()
                   .ReverseMap()
                   );
                Course u = Mapper.Map<Course>(item);
                ctx.Courses.Update(u);
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
