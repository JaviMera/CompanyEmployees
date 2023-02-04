using AutoMapper;
using CompanyEmployees.Entities.Models;
using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Profiles
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress", opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
