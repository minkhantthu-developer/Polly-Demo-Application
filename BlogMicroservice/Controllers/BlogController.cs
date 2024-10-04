using BlogMicroservice.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace BlogMicroservice.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            List<BlogDTO> _lstBlog = new List<BlogDTO>()
            {
                new BlogDTO
                {
                    BlogId=1,
                    BlogTitle="About Blog",
                    BlogAuthor="Author",
                    BlogContent="Content",
                },
                new BlogDTO
                {
                    BlogId=2,
                    BlogTitle="AboutBlog2",
                    BlogAuthor="Author",
                    BlogContent="Content"
                }
            };
            return Ok(_lstBlog);
        }
    }
}
