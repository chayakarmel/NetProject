
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
    public class UserBL: IBL.IUserBL
    {
        private readonly IDAL.IUserDal IUserDal;

        public UserBL(IUserDal iUserDal)
        {
            IUserDal = iUserDal;
        }

        public async Task<bool> AddAsync(UserDTO item)
        {
            try
            {
                return await IUserDal.AddAsync(item);
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
                return await IUserDal.DeleteAsync(id);
            }
            catch 
            { 
                return false;
            }
            
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            try
            {
                 return await IUserDal.GetAsync(id);
            }
            catch
            {
                return null;
            }
           
        }
        async Task<List<UserDTO>> IUserBL.GetAllAsync(Func<UserDTO, bool>? condition)
        {
            try
            {
                return await IUserDal.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }

       

        public async Task<bool> UpdateAsync(UserDTO user)
        {
            return await  IUserDal.UpdateAsync(user);
        }

       

       
    }
}
