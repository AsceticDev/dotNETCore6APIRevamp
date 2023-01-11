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
    }
}
