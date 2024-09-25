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
    public class LecturerBL:IBL.ILecturerBL
    {
        private readonly IDAL.ILecturerDal ILecturerDal;

        public LecturerBL(ILecturerDal _ILecturerDal)
        {
            ILecturerDal = _ILecturerDal;
        }

        public async Task<bool> AddAsync(LecturerDTO item)
        {
            try
            {
                return await ILecturerDal.AddAsync(item);
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
                return await ILecturerDal.DeleteAsync(id);
            }
            catch
            {
                return false;
            }

        }

        public async Task<LecturerDTO> GetAsync(int id)
        {
            try
            {
                return await ILecturerDal.GetAsync(id);
            }
            catch
            {
                return null;
            }

        }
        async Task<List<LecturerDTO>> ILecturerBL.GetAllAsync(Func<LecturerDTO, bool>? condition)
        {
            try
            {
                return await ILecturerDal.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool> UpdateAsync(LecturerDTO lecturer)
        {
            return await ILecturerDal.UpdateAsync(lecturer);
        }

    }
}
