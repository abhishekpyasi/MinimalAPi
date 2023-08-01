using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {

        Task<ICollection<Post>> GetAllPosts();
        Task<Post> GetPostByID(int Id);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string UpdatedContent, int postId);
        Task DeletePost(int postID);


    }
}
