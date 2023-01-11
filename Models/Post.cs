using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNETCoreAPIRevamp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be between 4 and 20 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
