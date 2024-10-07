using BlogMicroservice.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogMicroservice.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {
        private static int _requestContent;

        private readonly List<BlogDTO> _lstBlog = new List<BlogDTO>
        {
            new BlogDTO
            {
                BlogId=1,
                BlogTitle="Blog and Blog",
                BlogAuthor="Sann Lynn Htun",
                BlogContent="What is blog,blog is a blog and blog doesn't have girlfriend"
            },
            new BlogDTO
            {
                BlogId=2,
                BlogTitle="BLogBLog",
                BlogAuthor="Min Khant THu",
                BlogContent="Who is that"
            }
        };

        [HttpGet("{blogId}")]
        public async Task<IActionResult> GetBlog(int blogId)
        {
            await Task.Delay(1000);
            _requestContent++;
            var blog = _lstBlog.FirstOrDefault(x => x.BlogId == blogId);
            return _requestContent % 5 == 0 ?
                Ok(blog) :
                StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
        }
    }
}
