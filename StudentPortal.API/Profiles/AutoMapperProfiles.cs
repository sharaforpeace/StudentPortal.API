using AutoMapper;
using StudentPortal.API.DomainModels;
using StudentPortal.API.Profiles.AfterMaps;
using DataModels = StudentPortal.API.DataModels;

namespace StudentPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>()
                .ReverseMap();
            CreateMap<DataModels.Gender, Gender>()
               .ReverseMap();
            CreateMap<DataModels.Address, Address>()
               .ReverseMap();
            CreateMap<UpdateStudentRequest, DataModels.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
            CreateMap<AddStudentRequest, DataModels.Student>()
                .AfterMap<AddStudentRequestAfterMap>();
        }
    }
}
