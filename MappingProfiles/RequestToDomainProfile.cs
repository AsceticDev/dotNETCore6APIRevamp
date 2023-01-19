using AutoMapper;
using dotNETCoreAPIRevamp.Contracts.V1.Requests.Queries;
using dotNETCoreAPIRevamp.Models;

namespace dotNETCoreAPIRevamp.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            //CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<GetAllPostsQuery, GetAllPostsFilter>();
        }
    }
}
