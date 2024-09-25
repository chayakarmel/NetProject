using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ILecturerDal
    {
        public Task<LecturerDTO> GetAsync(int id);
        public Task<List<LecturerDTO>> GetAllAsync(Func<LecturerDTO, bool>? condition = null);
        public Task<bool> AddAsync(LecturerDTO item);
        public Task<bool> UpdateAsync(LecturerDTO item);
        public Task<bool> DeleteAsync(int id);
    }
}
