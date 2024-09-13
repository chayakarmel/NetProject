
using DTO;
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
        public IEnumerable<LecturerDTO> Get()
        {
            return ILecturerBL.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public LecturerDTO Get(int id)
        {
            return ILecturerBL.Get(id);

        }

        //[HttpGet]
        //public object GetSpec()
        //{
        //    return new Bl_Services.UserBL().GetAll().Select(d=> new {d.Email,d.UserId});

        //}

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] LecturerDTO value)
        {
            ILecturerBL.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LecturerDTO user)
        {
            ILecturerBL.Update(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ILecturerBL.Delete(id);
        }
    }
}
