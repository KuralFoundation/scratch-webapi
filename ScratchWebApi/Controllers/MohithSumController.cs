using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScratchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MohithSumController : ControllerBase
    {
        // GET: api/<MohithSumController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MohithSumController>/5
        [HttpGet("{a}/{b}")]
        public int GetSum(int a, int b)
        {
            return a + b;
        }
    }
}
