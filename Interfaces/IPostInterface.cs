using MyBlog.Dto;
using MyBlog.Entities;

namespace MyBlog.Interfaces
{
    public interface IPostInterface
    {
        Task<IEnumerable<PostDto>> GetPosts();
        Task<PostDto> GetPostByName(string authorName);
        Task<Post> GetPostById(int id);
    }
}
