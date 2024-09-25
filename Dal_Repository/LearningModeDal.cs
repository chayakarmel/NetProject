 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal_Repository.Model;
using DTO;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace Dal_Repository
{
    public class LearningModeDal : IDAL.ILearningModeDal
    {
        public async Task<bool> AddAsync(LearningModeDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<LearningMode, LearningModeDTO>()
                   .ReverseMap()
                   );
                LearningMode u = Mapper.Map<LearningMode>(item);
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
                LearningMode learning = ctx.LearningModes.Find(id);
                ctx.LearningModes.Remove(learning);
               await ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<LearningModeDTO> GetAsync(int id)
        {
            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<LearningMode, LearningModeDTO>().ReverseMap());
                var mapper = config.CreateMapper();
                var learning = await ctx.LearningModes.FindAsync(id);
                return mapper.Map<LearningModeDTO>(learning);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<LearningModeDTO>> GetAllAsync(Func<LearningModeDTO, bool>? condition = null)
        {

            try
            {
                using var ctx = new Model.LearningPlatformContext();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<LearningMode, LearningModeDTO>().ReverseMap();
                });
                var mapper = config.CreateMapper();
                var learnings = await ctx.LearningModes.ToListAsync();
                var learningDtos = learnings.Select(u => mapper.Map<LearningModeDTO>(u)).ToList();
                return condition == null ? learningDtos : learningDtos.Where(condition).ToList();
            }
            catch
            {
                return null;
            }
        }

      
        public async Task<bool> UpdateAsync(LearningModeDTO item)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                   cnf =>
                   cnf.CreateMap<LearningMode, LearningModeDTO>()
                   .ReverseMap()
                   );
                LearningMode l = Mapper.Map<LearningMode>(item);
                ctx.LearningModes.Update(l);
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




    
        
