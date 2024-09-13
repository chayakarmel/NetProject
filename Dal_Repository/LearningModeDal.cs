
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal_Repository.Model;
using DTO;
using IDAL;

namespace Dal_Repository
{
    public class LearningModeDal : IDAL.ILearningModeDal
    {
        public bool Add(LearningModeDTO item)
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
                ctx.Add(u);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public bool Delete(int id)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                LearningMode user = ctx.LearningModes.Find(id);
                ctx.LearningModes.Remove(user);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public LearningModeDTO Get(int id)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                    cnf =>
                    cnf.CreateMap<LearningMode, LearningModeDTO>()
                    .ReverseMap()
                    );
                LearningModeDTO u = Mapper.Map<LearningModeDTO>(ctx.LearningModes.Find(id));
                return u;
                //object user = ctx.Users.Find(id);
                //return user;
            }
            catch
            {
                return null;
            }
        }

        public List<LearningModeDTO> GetAll(Func<LearningModeDTO, bool>? condition = null)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                    cnf =>
                    cnf.CreateMap<LearningMode, LearningModeDTO>()
                    .ReverseMap()
                    );
                return ctx.LearningModes.Select(u => Mapper.Map<LearningModeDTO>(u)).ToList();
            }
            catch
            {
                return null;
            }
        }

      
        public bool Update(LearningModeDTO item)
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
                ctx.LearningModes.Update(u);
                int changes = ctx.SaveChanges();
                return changes > 0;
            }
            catch
            {
                return false;
            }
        }

     

      
    }
}




    
        
