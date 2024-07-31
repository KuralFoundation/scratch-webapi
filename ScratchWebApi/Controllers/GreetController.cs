using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScratchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetController : ControllerBase
    {
        // GET: api/<GreetController>
        [HttpGet]
        public string Get()
        {
            return "Hey There!!!";
        }

        // GET api/<GreetController>/5
        [HttpGet("{userId}")]
        public string Get(string userId)
        {
            return $"Hello {userId} how are you doing?";
        }

    }
}
