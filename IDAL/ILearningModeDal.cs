using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ILearningModeDal
    {
        public Task<LearningModeDTO> GetAsync(int id);
        public Task<List<LearningModeDTO>> GetAllAsync(Func<LearningModeDTO, bool>? condition = null);
        public Task<bool> AddAsync(LearningModeDTO item);
        public Task<bool> UpdateAsync(LearningModeDTO item);
        public Task<bool> DeleteAsync(int id);
    }
}

