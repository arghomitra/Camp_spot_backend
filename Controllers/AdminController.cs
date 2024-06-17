using Final_Project.data;
using Final_Project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private dataContext _data;
        public AdminController(dataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Admin>> Get()
        {
            return Ok(_data.GetAdmins());
        }
        [HttpPost]
        public ActionResult<Admin> Post([FromBody] Admin admin)
        {
            _data.AddAdmin(admin);
            return Ok(new {message = ""});
        }
    }
}
