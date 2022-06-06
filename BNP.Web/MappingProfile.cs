using AutoMapper;
using BNP.Domain.Entities;
using BNP.Web.Models;
using UserFile = BNP.Domain.Entities.UserFile;

namespace BNP.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationVM, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<StaticType, StaticTypeVM>().ReverseMap();
            CreateMap<FileHistory, FileStaticsVM>().ReverseMap();
        }
    }
}
