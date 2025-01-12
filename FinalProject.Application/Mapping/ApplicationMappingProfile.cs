using AutoMapper;
using FinalProject.Application.DTO;
using FinalProject.Domain;

namespace FinalProject.Application.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
