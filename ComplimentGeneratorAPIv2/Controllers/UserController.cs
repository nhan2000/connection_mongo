using ComplimentGeneratorAPIv2.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ComplimentGeneratorAPIv2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMongoCollection<User> _userCollection;
       public UserController(ILogger<UserController> logger, IMongoDatabase database)
        {
            _logger = logger;
            _userCollection = database.GetCollection<User>(Environment.GetEnvironmentVariable("Db_CollectionName"));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var compliments = await _userCollection.Find(_ => true).ToListAsync();
            return Ok(compliments);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User compliment)
        {
            await _userCollection.InsertOneAsync(compliment);
            return CreatedAtAction("Get", new { id = compliment.Id }, compliment);
        }
    }
}
