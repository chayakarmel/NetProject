using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUserDal
    {
        public Task<UserDTO> GetAsync(int id);
        public Task<List<UserDTO>> GetAllAsync(Func<UserDTO, bool>? condition = null);
        public Task<bool> AddAsync(UserDTO item);
        public Task<bool> UpdateAsync(UserDTO item);
        public Task<bool> DeleteAsync(int id);
    }
}
