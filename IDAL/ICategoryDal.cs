using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ICategoryDal
    {
        public Task<CategoryDTO> GetAsync(int id);
        public Task<List<CategoryDTO>> GetAllAsync(Func<CategoryDTO, bool>? condition = null);
        public Task<bool> AddAsync(CategoryDTO item);
        public Task<bool> UpdateAsync(CategoryDTO item);
        public Task<bool> DeleteAsync(int id);
    }
}
