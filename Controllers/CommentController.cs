using Final_Project.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Model;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private dataContext _data;
        public CommentController(dataContext data)
        {
            _data =data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comments>> Get()
        {
            return Ok(_data.GetComments());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Comments comment)
        {
            _data.AddComment(comment);
            return Ok($"A new comment added SpotId {comment.SpotId}!");
        }
        //[HttpGet("{id}")]
        //public ActionResult<Spot> Get(int id)
        //{
        //    Comments comments = _data.GetCommentsById(id);
        //    return Ok(comments);
        //}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Comments>> Get(int id)
        {
            var comments = _data.GetCommentsBySpotId(id);
            if (comments == null || !comments.Any())
            {
                return NotFound(); // or any other appropriate action/result
            }
            return Ok(comments);
        }



    }
}
