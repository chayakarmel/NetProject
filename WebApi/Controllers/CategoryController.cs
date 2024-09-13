
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBL.ICategoryBL ICategoryBL;

        public CategoryController(IBL.ICategoryBL ibl)
        {
            ICategoryBL = ibl;
        }


        // GET: api/<UsersController>
        [HttpGet]

        public async Task<IEnumerable<CategoryDTO>> GetAsync()
        {
            return await ICategoryBL.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDTO> GetAsync(int id)
        {
            return await ICategoryBL.GetAsync(id);

        }

        //[HttpGet]
        //public object GetSpec()
        //{
        //    return new Bl_Services.UserBL().GetAll().Select(d=> new {d.Email,d.UserId});

        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryDTO value)
        {
            var success = await ICategoryBL.AddAsync(value);
            return success ? Ok() : BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            var success = await ICategoryBL.UpdateAsync(category);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await ICategoryBL.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}

