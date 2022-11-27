﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Dto;
using MyBlog.Entities;
using MyBlog.Interfaces;

namespace MyBlog.Repositories
{
    public class PostRepository : IPostInterface
    {
        private readonly DataContext _dataContext;
        private IMapper _mapper;
        public PostRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        
        public async Task<Post> GetPostById(int id)
        {
            return await _dataContext.Posts
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PostDto> GetPostByName(string authorName)
        {
            return await _dataContext.Posts
                  .Where(p => p.Author == authorName)
                  .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                  .SingleOrDefaultAsync();
        }

        public async Task<Post> GetPostEntity(string authorName)
        {
            return await _dataContext.Posts
                .Where(P => P.Author == authorName)
                .SingleAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            return await _dataContext.Posts
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async void NewPost(Post post)
        {
            await _dataContext.AddAsync(post);
        }

        public void DeletePost(Post post)
        {
            _dataContext.Remove(post);
        }

        public async Task<bool> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
