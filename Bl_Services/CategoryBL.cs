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
    public   class CategoryBL:IBL.ICategoryBL
    {
        private readonly IDAL.ICategoryDal ICategoryDal;

        public CategoryBL(ICategoryDal _IcategoryDal)
        {
            ICategoryDal = _IcategoryDal;
        }
       
        public async Task<bool> AddAsync(CategoryDTO item)
        {
            try
            {
                return await ICategoryDal.AddAsync(item);
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
                return await ICategoryDal.DeleteAsync(id);
            }
            catch
            {
                return false;
            }

        }
      
        public async Task<CategoryDTO> GetAsync(int id)
        {
            try
            {
                return await ICategoryDal.GetAsync(id);
            }
            catch
            {
                return null;
            }

        }
        async Task<List<CategoryDTO>> ICategoryBL.GetAllAsync(Func<CategoryDTO, bool>? condition)
        {
            try
            {
                 return await ICategoryDal.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool> UpdateAsync(CategoryDTO user)
        {
            return await ICategoryDal.UpdateAsync(user);
        }

    }
}
