using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.Country.GetAlll;
using learn_Russian_API.Models.TeacherGroup.Create;
using learn_Russian_API.Presistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TeacherGroupController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        HttpRequestMessage _request = new HttpRequestMessage();
        
        public TeacherGroupController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<TeacherGroup>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.TeacherGroups.ProjectTo<TeacherGroup>(_mapper.ConfigurationProvider)
                .ToListAsync());
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(TeacherGroup), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateTGroup([FromBody] TeacherGroupCreate request)
        {
            if (await _context.TeacherGroups.CountAsync(x => x.TeacherId == request.TeacherId) == 2)
                return this.Conflict("Teacher cannot have more than Two group");
             
            if (await _context.TeacherGroups.CountAsync(x => x.GroupId == request.GroupId) == 1)
                            return this.Conflict("Group cannot repeat(one group -> one teacher)");
                
            var res = await _context.TeacherGroups.AddAsync(_mapper.Map<TeacherGroup>(request));
            await _context.SaveChangesAsync();
            
            if (res != null)
                ModelState.AddModelError("Teacher-Group", "The Teacher already exists on Group");

            return CreatedAtAction(nameof(CreateTGroup),
                await _context.TeacherGroups.ProjectTo<TeacherGroup>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(
                        x => x.TeacherId == res.Entity.TeacherId &
                                 x.GroupId == res.Entity.GroupId)
                );
        }
        
        
        [HttpPut]
        [ProducesResponseType(typeof(TeacherGroup), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateGroup([FromBody]TeacherGroupModify  request)
        {
            var foundGroup = await _context.TeacherGroups.FirstOrDefaultAsync(g => g.Id == request.Id);
            if (foundGroup == null) return NotFound();

            foundGroup.TeacherId = request.TeacherId;
            foundGroup.GroupId = request.GroupId;
            foundGroup.teaching_time = request.teaching_time;
            
            
            _context.TeacherGroups.Update(foundGroup);
            await _context.SaveChangesAsync();

            return Ok(await _context.TeacherGroups.ProjectTo<TeacherGroup>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id));
        }
        
        
        [HttpDelete("{id}")]
        //[ProducesResponseType(typeof(GroupGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDelete(long id)
        {
            var foundGroup = await _context.TeacherGroups.FirstOrDefaultAsync(g => g.Id == id);
            if (foundGroup == null) return NotFound();

            _context.TeacherGroups.Remove(foundGroup);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}