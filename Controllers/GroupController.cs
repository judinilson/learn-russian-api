using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.Group;
using learn_Russian_API.Models.Group.Create;
using learn_Russian_API.Models.Group.GetAll;
using learn_Russian_API.Models.Group.GetById;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GroupController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GroupController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] [ProducesResponseType(typeof(ICollection<GroupGetAllResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Groups.ProjectTo<GroupGetAllResponse>(_mapper.ConfigurationProvider).ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GroupGetById), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(long id)
        {
            if (await _context.Groups.CountAsync(x => x.Id == id) == 0) return NotFound();
            return Ok(await _context.Groups.ProjectTo<GroupGetById>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GroupGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOne([FromBody] GroupCreateRequest request)
        {
            var res = await _context.Groups.AddAsync(_mapper.Map<Group>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateOne),
                await _context.Groups.ProjectTo<GroupGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }


        [HttpPut]
        [ProducesResponseType(typeof(GroupGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateGroup([FromBody]GroupModifyRequest request)
        {
            var foundGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == request.Id);
            if (foundGroup == null) return NotFound();

            foundGroup.Name = request.Name;
            _context.Groups.Update(foundGroup);
            await _context.SaveChangesAsync();

            return Ok(await _context.Groups.ProjectTo<GroupGetAllResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id));
        }
        
        
        [HttpDelete("{id}")]
        //[ProducesResponseType(typeof(GroupGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDelete(long id)
        {
            var foundGroup = await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
            if (foundGroup == null) return NotFound();

            _context.Groups.Remove(foundGroup);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        
    }
}