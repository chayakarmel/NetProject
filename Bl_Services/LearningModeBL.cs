using DTO;
using IBL;
using IDAL;

namespace Bl_Services
{
    public class LearningModeBL:ILearningModeBl
    {
            private readonly IDAL.ILearningModeDal ILearningModeDal;

            public LearningModeBL(ILearningModeDal _ILearningModeDal)
            {
                ILearningModeDal = _ILearningModeDal;
            }

            public bool Add(LearningModeDTO item)
            {
                try
                {
                    return ILearningModeDal.Add(item);
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
                    return ILearningModeDal.Delete(id);
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
                    return ILearningModeDal.Get(id);
                }
                catch
                {
                    return null;
                }

            }
        List<LearningModeDTO> ILearningModeBl.GetAll(Func<LearningModeDTO, bool>? condition)
            {
                try
                {
                    return ILearningModeDal.GetAll();
                }
                catch
                {
                    return null;
                }
            }


        public bool Update(LearningModeDTO user)
            {
                return ILearningModeDal.Update(user);
            }

       
    }
}

