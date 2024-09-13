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

        public bool Add(LecturerDTO item)
        {
            try
            {
                return ILecturerDal.Add(item);
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
                return ILecturerDal.Delete(id);
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
                return ILecturerDal.Get(id);
            }
            catch
            {
                return null;
            }

        }
        List<LecturerDTO> ILecturerBL.GetAll(Func<LecturerDTO, bool>? condition)
        {
            try
            {
                return ILecturerDal.GetAll();
            }
            catch
            {
                return null;
            }
        }



        public bool Update(LecturerDTO lecturer)
        {
            return ILecturerDal.Update(lecturer);
        }

    }
}
