﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public PostController(IPostInterface postRepository, IMapper mapper )
        {
           _postRepository = postRepository;
           _mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPost()
        {
            var posts = await _postRepository.GetPosts();

            return Ok(posts);
           
        }

        [HttpGet("posts/{titleName}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPostByName(string titleName)
        {
            var post = await _postRepository.GetPostByName(titleName.Trim().ToUpper());
            return Ok(post);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePost([FromBody] PostUpdateDto postUpdate)
        {
            var post = await _postRepository.GetPostByTitleName(postUpdate.Author.Trim());
            var testPost = await _postRepository.GetPostByName(postUpdate.Titulo.Trim());
            if (testPost != null) return BadRequest("Titulo já cadastrado");

            _mapper.Map(postUpdate, post);
            _postRepository.UpdatePost(post);
            if (await _postRepository.SaveChanges()) return NoContent();

            return BadRequest("Não foi possivel atualizar");

        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreatePost([FromBody] PostUpdateDto postUpdate)
        {
            var postMapped = _mapper.Map<Post>(postUpdate);
           
            var testPost = await _postRepository.GetPostByName(postMapped.Titulo.Trim().ToUpper());
            if (testPost != null) return BadRequest("Titulo já cadastrado");

            _postRepository.NewPost(postMapped);

            if (await _postRepository.SaveChanges()) return NoContent();

            return BadRequest("Failed to Create Post");
        }

        [HttpDelete("posts/{authorName}")]
        public async Task<ActionResult<bool>> DeletePost(string authorName)
        {

            var testPost = await _postRepository.GetPostEntity(authorName);
            //var testPost = await _postRepository.GetPostById(28);
            if (testPost == null) return NotFound();

            _postRepository.DeletePost(testPost);

            if(await _postRepository.SaveChanges()) return NoContent();

            return BadRequest("Failed to Delete Post");
        }
    }
}
