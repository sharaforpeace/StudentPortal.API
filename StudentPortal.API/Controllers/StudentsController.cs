﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.API.DomainModels;
using StudentPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.API.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();
            return Ok(mapper.Map<List<Student>>(students)); 
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);
            if (student == null)
            {
                return   NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }
    }
}

//var domainModelStudetns = new List<Student>();
//foreach(var student in students)
//{
//    domainModelStudetns.Add(new Student(){
//        Id = student.Id,
//        FirstName = student.FirstName,
//        LastName = student.LastName,
//        DateOfBirth = student.DateOfBirth,
//        Email = student.Email,
//        Mobile = student.Mobile,
//        ProfileImageUrl = student.ProfileImageUrl,
//        GenderId = student.GenderId,
//        Address = new Address()
//        {
//            Id = student.Address.Id,
//            PhysicalAddress = student.Address.PhysicalAddress,
//            PostalAddress = student.Address.PostalAddress
//        },
//        Gender = new Gender()
//        {
//            Id =student.Gender.Id,
//            Description = student.Gender.Description
//        }
//    });
//}
//return Ok(domainModelStudetns);