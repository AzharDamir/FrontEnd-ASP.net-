using Microsoft.AspNetCore.Mvc;
using TestAsp.Data;
using  TestAsp.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAsp.Controllers
{
    [Route("api/controll")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext data;
        private readonly ILogger<Livre> logger;
        public ValuesController(DataContext data, ILogger<Livre> logger) { this.data = data;
            this.logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IList<Livre> Get()
        {
            logger.LogInformation(" executing...");
            // string str="hello world";
            // return str;
            return data.Livres.ToList();
        }
       

      
    }
}
