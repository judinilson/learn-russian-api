using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.Country.Create;
using learn_Russian_API.Models.Country.GetAlll;
using learn_Russian_API.Models.Country.GetById;
using learn_Russian_API.Models.Group.GetAll;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CountryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<CountryGetAllResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Countries.ProjectTo<CountryGetAllResponse>(_mapper.ConfigurationProvider)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryGetById), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(long id)
        {
            if (await _context.Countries.CountAsync(x => x.Id == id) == 0) return NotFound();
            return Ok(await _context.Countries.ProjectTo<CountryGetById>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CountryGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCountry([FromBody] CountryCreateRequest request)
        {
            var res = await _context.Countries.AddAsync(_mapper.Map<Country>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateCountry),
                await _context.Countries.ProjectTo<CountryGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }
    }
}