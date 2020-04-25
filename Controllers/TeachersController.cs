using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DefaultNamespace;
using learn_Russian_API.Models.Users.Student.Create;
using learn_Russian_API.Models.Users.Teacher.Create;
using learn_Russian_API.Models.Users.Teacher.GetAll;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{

        [Route("api/[controller]")]
        [Produces("application/json")]
        public class TeachersController : Controller
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public TeachersController(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet]
            [ProducesResponseType(typeof(ICollection<TeacherGetAllResponse>), StatusCodes.Status200OK)]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _context.Teachers.ProjectTo<TeacherGetAllResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync());
            }

            [HttpPost]
            [ProducesResponseType(typeof(TeacherGetAllResponse), StatusCodes.Status200OK)]
            public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateRequest request)
            {
                var res = await _context.Teachers.AddAsync(_mapper.Map<Teacher>(request));
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateTeacher),
                    await _context.Teachers.ProjectTo<TeacherGetAllResponse>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
            }


        }
}
