using Final_Project.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Model;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase
    {
        private dataContext _data;
        public SpotController(dataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Spot>> Get()
        {
            return Ok(_data.GetSpots());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Spot spot)
        {
            _data.AddSpot(spot);
            return Ok(new {message= "A new spot Added!" });
        }
        [HttpGet("{location}/{minPrice}/{maxPrice}")]
        public ActionResult<IEnumerable<Spot>> Get(string city, int minPrice, int maxPrice ) 
        {
            IEnumerable<Spot> spots = _data.GetSpotByLocationAndPrice(city,minPrice, maxPrice);
            if (spots.Any())
            {
                //var spotNames = spots.Select(spot => spot.Name);
                return Ok(spots);
            }
                
            else
                return NotFound("No spot found!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Spot spot)
        {
            Spot existingSpot = _data.GetSpotById(id);
            if (existingSpot == null)
            {
                return NotFound();
            }

            

            _data.SaveChanges(id, spot);

            return Ok($"id {id} is updated!");
        }
        [HttpGet("{city}/{startdate}/{enddate}/{guest}")]
        public ActionResult<IEnumerable<Spot>> Get(string city,DateTime startdate, DateTime enddate, int guest)
        {
            IEnumerable<Spot> spots = _data.GetSpotByfilter(city,startdate, enddate,guest);
            if (spots.Any())
            {
                //var spotNames = spots.Select(spot => spot.Name);
                return Ok(spots);
            }

            else
                return NotFound("No spot found!");
        }
        [HttpGet("{id}")]
        public ActionResult<Spot> Get(int id)
        {
            Spot Spot = _data.GetSpotById(id);
            return Ok(Spot);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteSpot(id);
            return Ok($"booking {id} deleted");
        }
    }
}
