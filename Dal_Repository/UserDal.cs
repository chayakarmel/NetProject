
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal_Repository.Model;
using DTO;
using Microsoft.EntityFrameworkCore;


namespace Dal_Repository
{
    public class UserDal : IDAL.IUserDal
    {
        public async Task<bool> AddAsync(UserDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<User, UserDTO>()
                   .ReverseMap()
                   );
                User u = Mapper.Map<User>(item);
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
                User user = await ctx.Users.FindAsync(id);
                ctx.Users.Remove(user);
               await ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>().ReverseMap());
                var mapper = config.CreateMapper();
                var user = await ctx.Users.FindAsync(id);
                return mapper.Map<UserDTO>(user);
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<UserDTO>> GetAllAsync(Func<UserDTO, bool>? condition = null)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();

                // אתחול המיפוי של AutoMapper
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>().ReverseMap();
                });
                var mapper = config.CreateMapper();

                // קבלת כל המשתמשים מהמסד נתונים בצורה אסינכרונית
                var users = await ctx.Users.ToListAsync();

                // המרת הנתונים ל-UserDTO בצורה אסינכרונית
                var userDtos = users.Select(u => mapper.Map<UserDTO>(u)).ToList();

                // אם יש תנאי מסנן, ניישם אותו על רשימת ה-DTO
                return condition == null ? userDtos : userDtos.Where(condition).ToList();
            }
            catch
            {
                return null;
            }
        }
        //public async Task<List<UserDTO>> GetAllAsync(Func<UserDTO, bool>? condition = null)
        //{
        //    try
        //    {
        //        using Model.LearningPlatformContext ctx = new();
        //        Mapper.Initialize(
        //            cnf =>
        //            cnf.CreateMap<User, UserDTO>()
        //            .ReverseMap()
        //            );
        //        return ctx.Users.Select(u => Mapper.Map<UserDTO>(u)).ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}



        public async Task<bool> UpdateAsync(UserDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<User, UserDTO>()
                   .ReverseMap()
                   );
                User u = Mapper.Map<User>(item);
                ctx.Users.Update(u);
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