using System.ComponentModel.DataAnnotations;

namespace GetBlogMicroservice.Options
{
    public class BlogClientOption
    {
        [Required]
        public Uri BaseAddress { get; set; }

        [Required]
        public TimeSpan TimeOut { get; set; } 
    }
}
