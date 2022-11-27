using AutoMapper;
using MyBlog.Dto;
using MyBlog.Entities;

namespace MyBlog.Helpers
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostUpdateDto>().ReverseMap();
        }
    }
}
