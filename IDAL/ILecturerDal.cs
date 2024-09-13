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
        public LecturerDTO Get(int id);
        public List<LecturerDTO> GetAll(Func<LecturerDTO, bool>? condition = null);
        public bool Add(LecturerDTO item);
        public bool Update(LecturerDTO item);
        public bool Delete(int id);
    }
}
