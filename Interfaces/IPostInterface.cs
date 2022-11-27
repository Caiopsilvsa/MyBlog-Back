using MyBlog.Dto;
using MyBlog.Entities;

namespace MyBlog.Interfaces
{
    public interface IPostInterface
    {
        Task<IEnumerable<PostDto>> GetPosts();
        Task<PostDto> GetPostByName(string authorName);
        Task<Post> GetPostEntity(string authorName);
        Task<Post> GetPostById(int id);
        void NewPost(Post post);
        void DeletePost(Post post);
        Task<bool> SaveChanges();

    }
}
