using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNETCoreAPIRevamp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be between 4 and 20 characters.")]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string? UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<PostTag> PostTag { get; set; }
    }
}
