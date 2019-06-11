using AutoMapper;
using Boards.API.Domain.Models;
using Boards.API.Resources;

namespace Boards.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveBoardResource, Board>();
            CreateMap<SavePostResource, Post>();
            CreateMap<SaveReplyResource, Reply>();
            CreateMap<UserCredentialResource, User>();
        }
    }
}