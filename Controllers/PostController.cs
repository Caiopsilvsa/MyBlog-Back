using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Dto;
using MyBlog.Entities;
using MyBlog.Interfaces;

namespace MyBlog.Controllers
{
    public class PostController:BaseController
    {
        private readonly IPostInterface _postRepository;

        public PostController(IPostInterface postRepository)
        {
           _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPost()
        {
            var posts = await _postRepository.GetPosts();

            return Ok(posts);
           
        }

        [HttpGet("posts/{authorName}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPostByName(string authorName)
        {
            var post = await _postRepository.GetPostByName(authorName);
            return Ok(post);
        }
    }
}
