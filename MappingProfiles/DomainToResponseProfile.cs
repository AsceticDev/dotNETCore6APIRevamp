using AutoMapper;
using dotNETCoreAPIRevamp.Contracts.V1.Responses;
using dotNETCoreAPIRevamp.Models;

namespace dotNETCoreAPIRevamp.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse>()
                .ForMember(dest => 
                    dest.Tags, opt =>
                    opt.MapFrom(src => src.PostTag.Select(x => new TagResponse { Name = x.TagName })));
                
            CreateMap<Tag, TagResponse>();
        }
    }
}
