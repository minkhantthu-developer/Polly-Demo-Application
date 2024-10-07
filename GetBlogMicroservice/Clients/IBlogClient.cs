using GetBlogMicroservice.DTOS;

namespace GetBlogMicroservice.Clients
{
    public interface IBlogClient
    {
        Task<BlogDTO>? GetBlog(int blogId);
    }
}
