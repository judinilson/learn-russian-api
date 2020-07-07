using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.Statistic.Create;
using learn_Russian_API.Models.Statistic.GetAll;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StatisticController: Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StatisticController(AppDbContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ICollection<StatisticsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Statistics
                .ProjectTo<StatisticsResponse>(_mapper.ConfigurationProvider).ToListAsync());
        }
        
        

        [HttpPost("Create-Statistics")]
        [ProducesResponseType(typeof(ICollection<StatisticsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateStatistic([FromBody] StatisticsRequest request)
        {
            var res = await _context.Statistics.AddAsync(_mapper.Map<Statistic>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateStatistic),
                await _context.Statistics.ProjectTo<StatisticsResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }
    }
}