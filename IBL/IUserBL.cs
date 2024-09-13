using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IUserBL
    {
        Task<UserDTO> GetAsync(int id);
        Task<List<UserDTO>> GetAllAsync(Func<UserDTO, bool>? condition = null);
        Task<bool> AddAsync(UserDTO item);
        Task<bool> UpdateAsync(UserDTO item);
        Task<bool> DeleteAsync(int id);
    }
}
