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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        
        /* PUT TRAINING CONTENT*/
        [HttpPut("training-content {id}")]
        [ProducesResponseType(typeof(TrainingContentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTrainingContent(long id, [FromBody] TrainingContentRequest request)
        {
            var training_content = await _context.TrainingContents
                .FirstOrDefaultAsync(c => c.Id == id);
            if (training_content == null) return NotFound("Content wasn't found");

            training_content.Title = request.Title;
            training_content.CategoryId = request.CategoryId;
            training_content.coverImage = request.coverImage;
            training_content.Trainings = request.Trainings;
            training_content.Author = request.Author;

            _context.TrainingContents.Update(training_content);
            await _context.SaveChangesAsync();
                    
            return Ok(await _context.TrainingContents.ProjectTo<TrainingContentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == training_content.Id));
        }
            
            
        // DELETE DEMO CONTENT 
        [HttpDelete("Content {id}")]
        public async Task<IActionResult> DeleteTrainingContent(long id)
        {
            var contentfound = await _context.TrainingContents.FindAsync(id);
            if (contentfound != null)
            {
                _context.TrainingContents.Remove(contentfound);
                await _context.SaveChangesAsync();
                return Ok("Content Deleted SUCCESSFULLY !!");
            }
            return NotFound("Incorrect ID content Wasn't found");
        }
    }
    
    
           
}





