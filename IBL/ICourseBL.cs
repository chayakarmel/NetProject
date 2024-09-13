using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface ICourseBL
    {
        public Task<CourseDTO> GetAsync(int id);
        public Task<List<CourseDTO>> GetAllAsync(Func<CourseDTO, bool>? condition = null);
        public Task<bool> AddAsync(CourseDTO item);
        public Task<bool> UpdateAsync(CourseDTO item);
        public Task<bool> DeleteAsync(int id);
    }
}
