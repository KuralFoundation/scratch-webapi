using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScratchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        // GET: api/<MathController>
        [HttpGet]
        public IEnumerable<string> Add()
        {
            return new string[] { "Please enter two integers" };
        }

        // GET api/<MathController>/5
        [HttpGet("{num1}, {num2}")]
        public int Add(int num1, int num2)
        {
            return num1+num2;
        }
    }
}
