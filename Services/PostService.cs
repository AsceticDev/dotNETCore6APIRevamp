using dotNETCoreAPIRevamp.Data;
using dotNETCoreAPIRevamp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace dotNETCoreAPIRevamp.Services
{
    public class PostService : IPostService
    {

        private readonly DataContext _dataContext;
        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            //post.Tags?.ForEach(x => x.TagName = x.TagName.ToLower());

            await AddNewTags(post);
            await _dataContext.Posts.AddAsync(post);
            
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await GetPostByIdAsync(postId);
            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> UserOwnsPostAsync(int postId, string userId)
        {
            var post = await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);

            if (post == null)
            {
                return false;
            }

            if (post.UserId != userId)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _dataContext.Tags.AsNoTracking().ToListAsync();
        }

        public async Task<bool> CreateTagAsync(Tag tag)
        {
            tag.TagName = tag.TagName.ToLower();
            var existingTag = await _dataContext.Tags.AsNoTracking().SingleOrDefaultAsync(x => x.TagName == tag.TagName);
            if (existingTag != null)
                return true;

            await _dataContext.Tags.AddAsync(tag);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<Tag> GetTagByNameAsync(string tagName)
        {
            return await _dataContext.Tags.AsNoTracking().SingleOrDefaultAsync(x => x.TagName == tagName.ToLower());
        }

        public async Task<bool> DeleteTagAsync(string tagName)
        {
            var tag = await _dataContext.Tags.AsNoTracking().SingleOrDefaultAsync(x => x.TagName == tagName.ToLower());

            if (tag == null)
                return true;

            var postTags = await _dataContext.PostTags.Where(x => x.TagName == tagName.ToLower()).ToListAsync();

            _dataContext.PostTags.RemoveRange(postTags);
            _dataContext.Tags.Remove(tag);
            return await _dataContext.SaveChangesAsync() > postTags.Count;
        }

        private async Task AddNewTags(Post post)
        {
            foreach (var tag in post.PostTag)
            {
                var existingTag =
                    await _dataContext.Tags.SingleOrDefaultAsync(x => x.TagName == tag.TagName);
                if (existingTag != null)
                    continue;

                await _dataContext.Tags.AddAsync(new Tag
                { TagName = tag.TagName, CreatedOn = DateTime.UtcNow, UserId = post.UserId });
            }
        }
    }
}
