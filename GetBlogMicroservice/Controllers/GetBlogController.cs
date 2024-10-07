using GetBlogMicroservice.Clients;
using GetBlogMicroservice.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetBlogMicroservice.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class GetBlogController : ControllerBase
    {
        private readonly IBlogClient _blogClient;

        public GetBlogController(IBlogClient blogClient,BlogClientOption blogClientOption)
        {
            _blogClient = blogClient;
        }

        [HttpGet("{blogId}")]
        public async Task<IActionResult> GetBlog(int blogId)
        {
            var blog = await _blogClient.GetBlog(blogId)!;
            return Ok(blog);
        }
    }
}
