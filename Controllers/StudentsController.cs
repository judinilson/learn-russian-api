using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace learn_Russian_API.Controllers
{
    
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentsController : Controller
    {
        /*
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<StudentGetAllResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Students.ProjectTo<StudentGetAllResponse>(_mapper.ConfigurationProvider)
                .ToListAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(StudentGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateStudent([FromBody] studentCreateRequest request)
        {
            var res = await _context.Students.AddAsync(_mapper.Map<Student>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateStudent),
                await _context.Students.ProjectTo<StudentGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }*/
        
        

    }
}