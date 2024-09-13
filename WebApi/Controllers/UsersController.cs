using DTO;
using IBL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UsersController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _userBL.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await _userBL.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO value)
        {
            var success = await _userBL.AddAsync(value);
            return success ? Ok() : BadRequest();
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            var success = await _userBL.UpdateAsync(user);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userBL.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
