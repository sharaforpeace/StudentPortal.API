﻿using AutoMapper;
using StudentPortal.API.DomainModels;
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


        }

    }
}
