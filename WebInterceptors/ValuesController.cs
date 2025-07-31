using Microsoft.AspNetCore.Mvc;

namespace WebInterceptors
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ValuesController(IReaderService readerService)
        {
            _readerService = readerService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            string result = _readerService.ReadData("some read query");
            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
