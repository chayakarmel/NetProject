using DTO;
using IBL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningModeController : ControllerBase
    {
      
            private readonly IBL.ILearningModeBl IlearningModeBl;

            public LearningModeController(IBL.ILearningModeBl ibl)
            {
            IlearningModeBl = ibl;
            }

        
       
        // GET: api/<LearningModeController>
        [HttpGet]
        public async Task<IEnumerable<LearningModeDTO>> GetAsync()
        {
            return await IlearningModeBl.GetAllAsync();
        }

        // GET api/<LearningModeController>/5
        [HttpGet("{id}")]
        public async Task<LearningModeDTO> Get(int id)
        {
            return await IlearningModeBl.GetAsync(id);

        }

        // POST api/<LearningModeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LearningModeDTO value)
        {
            var success = await IlearningModeBl.AddAsync(value);
            return success ? Ok() : BadRequest();
        }

        // PUT api/<LearningModeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LearningModeDTO learningMode)
        {
            if (id != learningMode.ModeId)
            {
                return BadRequest();
            }

            var success = await IlearningModeBl.UpdateAsync(learningMode);
            return success ? Ok() : NotFound();
        }
        // DELETE api/<LearningModeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await IlearningModeBl.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
