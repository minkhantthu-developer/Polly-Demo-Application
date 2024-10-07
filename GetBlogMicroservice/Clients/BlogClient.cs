using GetBlogMicroservice.DTOS;

namespace GetBlogMicroservice.Clients
{
    public class BlogClient : IBlogClient
    {
        private readonly HttpClient _httpClient;

        public BlogClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BlogDTO>? GetBlog(int blogId)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/blog/{blogId}");
            using var response = await _httpClient.SendAsync
               (httpRequestMessage,
               HttpCompletionOption.ResponseHeadersRead,
               CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var blog = await response.Content.ReadFromJsonAsync<BlogDTO>();
            return blog!;
        }
    }
}
