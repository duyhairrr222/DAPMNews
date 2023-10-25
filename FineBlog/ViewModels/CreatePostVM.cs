using FineBlog.Models;
using System.ComponentModel.DataAnnotations;

namespace FineBlog.ViewModels
{
    public class CreatePostVM
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public float? Prices { get; set; }

        public int? CateID;
        public IFormFile? Thumbnail { get; set; }
    }
}
