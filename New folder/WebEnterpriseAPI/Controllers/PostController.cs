using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEnterpriseAPI.Data;
using WebEnterpriseAPI.Model;

namespace WebEnterpriseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly CustomContext context;
        public PostController(CustomContext _context)
        {
            context = _context;
        }

        //[HttpPost]
        //public IActionResult AddPost(Post post)
        //{

        //}
    }
}
