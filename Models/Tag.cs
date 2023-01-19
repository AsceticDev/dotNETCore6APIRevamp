using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace dotNETCoreAPIRevamp.Models
{
    public class Tag
    {
        [Key]
        public string TagName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<PostTag> PostTag { get; set; }
    }
}
