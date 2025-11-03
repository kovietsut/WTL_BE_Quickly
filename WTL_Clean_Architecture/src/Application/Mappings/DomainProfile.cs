using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CreateGenreDto, Genere>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(_ => false));

            CreateMap<UpdateGenreDto, Genere>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateUserDto, User>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(_ => false))
                .ForMember(d => d.PasswordHash, opt => opt.Ignore())
                .ForMember(d => d.SecurityStamp, opt => opt.Ignore());
        }
    }
}


