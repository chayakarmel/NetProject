using DTO;
using IBL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl_Services
{
    public class CourseBL:IBL.ICourseBL
    {
        private readonly IDAL.ICourseDal ICourseDal;

        public CourseBL(ICourseDal _ICourseDal)
        {
            ICourseDal = _ICourseDal;
        }

        public async Task<bool> AddAsync(CourseDTO item)
        {
            try
            {
                return await ICourseDal.AddAsync(item);
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
                return await ICourseDal.DeleteAsync(id);
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
                return await ICourseDal.GetAsync(id);
            }
            catch
            {
                return null;
            }

        }
        async Task<List<CourseDTO>> ICourseBL.GetAllAsync(Func<CourseDTO, bool>? condition)
        {
            try
            {
                return await ICourseDal.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool>  UpdateAsync(CourseDTO course)
        {
            return await ICourseDal.UpdateAsync(course);
        }
    }
}
