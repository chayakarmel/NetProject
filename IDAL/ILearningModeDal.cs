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
        public LearningModeDTO Get(int id);
        public List<LearningModeDTO> GetAll(Func<LearningModeDTO, bool>? condition = null);
        public bool Add(LearningModeDTO item);
        public bool Update(LearningModeDTO item);
        public bool Delete(int id);
    }
}

