using DTO;
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
        public IEnumerable<LearningModeDTO> Get()
        {
            return IlearningModeBl.GetAll();
        }
        // GET api/<LearningModeController>/5
        [HttpGet("{id}")]
        public LearningModeDTO Get(int id)
        {
            return IlearningModeBl.Get(id);
        }

        // POST api/<LearningModeController>
        [HttpPost]
        public void Post(LearningModeDTO value)
        {
            IlearningModeBl.Add(value);
        }

        // PUT api/<LearningModeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LearningModeDTO value)
        {
            IlearningModeBl.Update(value);
        }

        // DELETE api/<LearningModeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IlearningModeBl.Delete(id);
        }
    }
}
