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
using Microsoft.OpenApi.Any;
using Microsoft.VisualBasic;

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
            var trainingContent = await _context.TrainingContents
                .Where(p => p.Id == id)
                .Include(p => p.Trainings)
                .FirstOrDefaultAsync();
            
            if (trainingContent == null) return NotFound("Content wasn't found");

            //training_content.Title = request.Title;
            //training_content.CategoryId = request.CategoryId;
            //training_content.coverImage = request.coverImage;
            //training_content.Author = request.Author;

           
            
            //trainingContent.Trainings = request.Trainings;
            
            _context.Entry(trainingContent).CurrentValues.SetValues(request);

            //delete existing trainingQuetions and answers
           foreach (var traing in trainingContent.Trainings.ToList())
           {
               var item = await _context.Trainings.FindAsync(traing.Id);
                _context.Remove(item);
                await _context.SaveChangesAsync();
              
           }
           //trainingContent.Trainings = request.Trainings;
           
           
           //update trainingQuetions and answers
           foreach (var requestTraingQuest in request.Trainings)
           {
               var trainingQuestions = await _context.Trainings
                   .Where(c => c.TrainingContentId == trainingContent.Id)
                   .Include(c => c.Answers)
                   .FirstOrDefaultAsync();
               if(trainingQuestions != null)
                    _context.Entry(trainingQuestions).CurrentValues.SetValues(requestTraingQuest);
               else
               {
                   var newtraining = new Training {Questions = requestTraingQuest.Questions,Answers = requestTraingQuest.Answers};
                   trainingContent.Trainings.Add(newtraining);
               }
           }
            //_context.TrainingContents.Update(trainingContent);
            await _context.SaveChangesAsync();
                    
            return Ok(await _context.TrainingContents.ProjectTo<TrainingContentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == trainingContent.Id));
        }
            
            
        // DELETE DEMO CONTENT 
        [HttpDelete("Content {id}")]
        public async Task<IActionResult> DeleteTrainingContent(long id)
        {
            
            var trainingContent = await _context.TrainingContents
                            .FindAsync(id);
            //var trainingQuestions = await _context.Trainings.FirstOrDefaultAsync(c => c.TrainingContentId == id);
           // var trAnswer = await _context.Answers.FirstOrDefaultAsync(c => c.TrainingId == trainingQuestions.Id);
            if (trainingContent == null) return NotFound("Incorrect ID content Wasn't found");

           /* var trainingAnswer = _context.Trainings
                .Where(a => a.Id == trainingQuestions.Id)
                .Include(a => a.Answers).FirstAsync();
            
           var contentTraining =  _context.TrainingContents
               .Where(t => t.Id == id)
               .Include(t => t.Trainings).FirstAsync();*/
           
           //_context.Remove(trainingAnswer);
           //await _context.SaveChangesAsync();
           
            _context.Remove(trainingContent);
            await _context.SaveChangesAsync();
            
            
            return Ok("Content Deleted SUCCESSFULLY !!");
            
        }
    }
    
    
           
}





