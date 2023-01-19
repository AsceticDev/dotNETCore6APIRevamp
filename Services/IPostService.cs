using dotNETCoreAPIRevamp.Models;

namespace dotNETCoreAPIRevamp.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(int postId);
        Task<bool> DeletePostAsync(int postId);
        Task<bool> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post postToUpdate);
        Task <bool> UserOwnsPostAsync(int postId, string userId);
        Task<List<Tag>> GetAllTagsAsync();
        //Task<bool> CreateTagAsync(Tag tag);
        //Task<Tag> GetTagByNameAsync(string tagName);
        //Task<bool> DeleteTagAsync(string tagName);
    }
}
