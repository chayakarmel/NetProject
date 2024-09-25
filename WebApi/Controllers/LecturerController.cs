
using Bl_Services;
using Dal_Repository.Model;
using DTO;
using IBL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly IBL.ILecturerBL ILecturerBL;

        public LecturerController(IBL.ILecturerBL ibl)
        {
            ILecturerBL = ibl;
        }


        // GET: api/<UsersController>
        [HttpGet]
        //
        public async Task<IEnumerable<LecturerDTO>> Get()
        {
            return await ILecturerBL.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<LecturerDTO> Get(int id)
        {
            return await ILecturerBL.GetAsync(id);

        }

        //[HttpGet]
        //public object GetSpec()
        //{
        //    return new Bl_Services.UserBL().GetAll().Select(d=> new {d.Email,d.UserId});

        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LecturerDTO value)
        {
            var success = await ILecturerBL.AddAsync(value);
            return success ? Ok() : BadRequest();
        }




        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LecturerDTO lecturer)
        {
            if (id != lecturer.LecturerId)
            {
                return BadRequest();
            }

            var success = await ILecturerBL.UpdateAsync(lecturer);
            return success ? Ok() : NotFound();
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await ILecturerBL.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
