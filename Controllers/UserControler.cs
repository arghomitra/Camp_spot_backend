using Final_Project.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Model;
using Microsoft.AspNetCore.Components.RenderTree;


namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControler : ControllerBase
    {

        private dataContext _data;
        public UserControler(dataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_data.GetUsers());
        }
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _data.AddUser(user);
            return Ok(user);
        }
        //[HttpGet("{name}")]
        //public ActionResult<IEnumerable<User>> Get(string name)
        //{
        //    IEnumerable<User> users = _data.GetUserByName(name);
        //    if (users != null) return Ok(users);
        //    return NotFound("User not found!");
        //}
        [HttpGet("{email}")]
        public ActionResult<IEnumerable<User>> Get(string email)
        {
            IEnumerable<User> user = _data.GetUserByEmail(email);
            if (user != null) return Ok(user);
            return NotFound("User not found");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            User existingUser = _data.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound("User not found!");
            }

            

            _data.SaveChanges(id, user); // Call the SaveChanges method with the ID and updated user

            return Ok($"userId {id} is updated!");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteUser(id);
            return Ok($"user {id} deleted");
        }
        [HttpPatch("{email}/update-password")]
        public IActionResult UpdatePassword(string email, [FromBody] UpdatePasswordRequest request)
        {
            var existingUser = _data.GetUserByEmail(email);
            if (existingUser == null)
            {
                return NotFound(new { message = "User not found!" });
            }

            _data.UpdateUserPassword(email, request.NewPassword);
            return Ok(new { message = "Password updated successfully!" });
        }

        public class UpdatePasswordRequest
        {
            public string NewPassword { get; set; }
        }

    }
}
