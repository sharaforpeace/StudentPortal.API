using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.API.Repositories;
using System.Linq;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using StudentPortal.API.DomainModels;

namespace StudentPortal.API.Controllers
{
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        
        public GendersController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await studentRepository.GetGendersAsync();
            if(genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<Gender>>(genderList));
        }
    }
}
