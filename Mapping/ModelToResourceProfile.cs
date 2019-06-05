using AutoMapper;
using Boards.API.Domain.Models;
using Boards.API.Resources;

namespace Boards.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Board, BoardResource>();
            CreateMap<Post, PostResource>();
        }
    }
}