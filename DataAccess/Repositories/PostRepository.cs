using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly SocialDbContext _context;

        public PostRepository(SocialDbContext context)
        {
            _context = context;
        }



        public async Task<Post> CreatePost(Post toCreate)
        {

            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.Posts.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;


        }

        public async Task DeletePost(int postID)
        {

            var post = _context.Posts.FirstOrDefault(p => p.Id == postID);
            if (post == null) return;
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByID(int Id)
        {
            var post = await _context.Posts.Where(p => p.Id == Id).FirstAsync();

            return post;
        }

        public async Task<Post> UpdatePost(string UpdatedContent, int postId)
        {

            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            post.LastModified = DateTime.Now;
            post.Content = UpdatedContent;
            await _context.SaveChangesAsync();
            return post;


        }
    }
}
