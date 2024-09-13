
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IBL.ICourseBL ICourseBL;

        public CourseController(IBL.ICourseBL ibl)
        {
            ICourseBL = ibl;
        }
       

        // GET: api/<UsersController>
        [HttpGet]
     
        public async Task<IEnumerable<CourseDTO>> GetAsync()
        {
            return await ICourseBL.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<CourseDTO> GetAsync(int id)
        {
            return await ICourseBL.GetAsync(id);

        }

        //[HttpGet]
        //public object GetSpec()
        //{
        //    return new Bl_Services.UserBL().GetAll().Select(d=> new {d.Email,d.UserId});

        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CourseDTO value)
        {
            var success = await ICourseBL.AddAsync(value);
            return success ? Ok() : BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseDTO user)
        {
            if (id != user.CourseId)
            {
                return BadRequest();
            }

            var success = await ICourseBL.UpdateAsync(user);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await ICourseBL.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
