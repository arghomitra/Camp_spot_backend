using Final_Project.data;
using Final_Project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private dataContext _data;
        public MessageController(dataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return Ok(_data.GetMessage());
        }
        [HttpPost]
        public ActionResult<Message> Post([FromBody] Message message)
        {
            _data.AddMessage(message);
            return Ok(new {message="a new message added!"});
        }
    }
}
