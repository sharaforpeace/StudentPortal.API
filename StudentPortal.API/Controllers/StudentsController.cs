using AutoMapper;
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
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId,
                [FromBody] UpdateStudentRequest request)
        {
            if (await studentRepository.Exists(studentId))
            {
                // update Details
                var UpdatedStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if (UpdatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(UpdatedStudent));
                }
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await studentRepository.Exists(studentId))
            {
                var student = await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(student));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Insert")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var student = await studentRepository.AddStudent(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id }, 
                mapper.Map<Student>(student));
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