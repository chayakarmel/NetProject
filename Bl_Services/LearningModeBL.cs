using DTO;
using IBL;
using IDAL;

namespace Bl_Services
{
    public class LearningModeBL : ILearningModeBl
    {
        private readonly IDAL.ILearningModeDal ILearningModeDal;

        public LearningModeBL(ILearningModeDal _ILearningModeDal)
        {
            ILearningModeDal = _ILearningModeDal;
        }

        public async Task<bool> AddAsync(LearningModeDTO item)
        {
            try
            {
                return await ILearningModeDal.AddAsync(item);
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
                return await ILearningModeDal.DeleteAsync(id);
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
                return await ILearningModeDal.GetAsync(id);
            }
            catch
            {
                return null;
            }

        }
        async Task<List<LearningModeDTO>> ILearningModeBl.GetAllAsync(Func<LearningModeDTO, bool>? condition)
        {
            try
            {
                return await ILearningModeDal.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }


        public async Task<bool> UpdateAsync(LearningModeDTO learningMode)
        {
            return await ILearningModeDal.UpdateAsync(learningMode);
        }


    }
}

