using AutoMapper;
using Boards.API.Domain.Models;
using Boards.API.Domain.Security.Tokens;
using Boards.API.Resources;

namespace Boards.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Board, BoardResource>();
            CreateMap<Post, PostResource>();
            CreateMap<Reply, ReplyResource>();
            CreateMap<User, UserResource>();
            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
    }
}