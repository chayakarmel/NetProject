using AutoMapper;
using Dal_Repository.Model;
using DTO;
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
        public bool Add(LecturerDTO item)
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
                Lecturer l = ctx.Lecturers.Find(id);
                ctx.Lecturers.Remove(l);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public LecturerDTO Get(int id)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                    cnf =>
                    cnf.CreateMap<Lecturer, LecturerDTO>()
                    .ReverseMap()
                    );
                LecturerDTO u = Mapper.Map<LecturerDTO>(ctx.Lecturers.Find(id));
                return u;
                //object user = ctx.Users.Find(id);
                //return user;
            }
            catch
            {
                return null;
            }
        }

        public List<LecturerDTO> GetAll(Func<LecturerDTO, bool>? condition = null)
        {
            try
            {
                using Model.LearningPlatformContext ctx = new();
                Mapper.Initialize(
                    cnf =>
                    cnf.CreateMap<Lecturer, LecturerDTO>()
                    .ReverseMap()
                    );
                return ctx.Lecturers.Select(u => Mapper.Map<LecturerDTO>(u)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool Update(LecturerDTO item)
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
