using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace dotNETCoreAPIRevamp.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Post> Posts { get; set; }
        public ICollection<Tag> CreatedPostTags{ get; set; }
    }
}
