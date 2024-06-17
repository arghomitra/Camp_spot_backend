using Final_Project.data;
using Final_Project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private dataContext _data;
        public BookingController(dataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> Get()
        {
            return Ok(_data.GetBookings());
        }
        [HttpPost]
        public ActionResult Post([FromBody] Booking booking)
        {
            _data.AddBooking(booking);
            return Ok(new{message= "A new booking added!" });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteBooking(id);
            return Ok($"booking {id} deleted");
        }



    }
}
