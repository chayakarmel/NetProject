using AutoMapper;
using Dal_Repository.Model;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class LecturerDal : IDAL.ILecturerDal
    {
        public async Task<bool> AddAsync(LecturerDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<Lecturer, LecturerDTO>()
                   .ReverseMap()
                   );
                Lecturer u = Mapper.Map<Lecturer>(item);
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
                Lecturer l = ctx.Lecturers.Find(id);
                ctx.Lecturers.Remove(l);
                await  ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<LecturerDTO> GetAsync(int id)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Lecturer, LecturerDTO>().ReverseMap());
                var mapper = config.CreateMapper();
                var lecturer = await ctx.Lecturers.FindAsync(id);
                return mapper.Map<LecturerDTO>(lecturer);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<LecturerDTO>> GetAllAsync(Func<LecturerDTO, bool>? condition = null)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();

                // אתחול המיפוי של AutoMapper
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Lecturer, LecturerDTO>().ReverseMap();
                });
                var mapper = config.CreateMapper();

                // קבלת כל המשתמשים מהמסד נתונים בצורה אסינכרונית
                var lecturers = await ctx.Lecturers.ToListAsync();

                // המרת הנתונים ל-UserDTO בצורה אסינכרונית
                var lecturerDtos = lecturers.Select(l => mapper.Map<LecturerDTO>(l)).ToList();

                // אם יש תנאי מסנן, ניישם אותו על רשימת ה-DTO
                return condition == null ? lecturerDtos : lecturerDtos.Where(condition).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(LecturerDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<Lecturer, LecturerDTO>()
                   .ReverseMap()
                   );
                Lecturer u = Mapper.Map<Lecturer>(item);
                ctx.Lecturers.Update(u);
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
