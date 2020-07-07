using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.TrainingContent.Create;
using learn_Russian_API.Models.TrainingContent.GetAll;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TrainingContentController: Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TrainingContentController(AppDbContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<TrainingContentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.TrainingContents
                .ProjectTo<TrainingContentResponse>(_mapper.ConfigurationProvider).ToListAsync());
        }

        [HttpPost("Create-Trainig")]
        [ProducesResponseType(typeof(ICollection<TrainingContentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingContentRequest request)
        {
            var res = await _context.TrainingContents
                .AddAsync(_mapper.Map<TrainingContent>(request));
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateTraining),
                await _context.TrainingContents.ProjectTo<TrainingContentResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync());
        }

    }
}