using System.ComponentModel.DataAnnotations;

namespace dotNETCoreAPIRevamp.Models
{
    public class PostTag
    {
        [Key]
        public int PostTagId { get; set; }
        public string TagName { get; set; }
        public Tag Tag { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
