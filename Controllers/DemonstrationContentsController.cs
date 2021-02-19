using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.Category.Create;
using learn_Russian_API.Models.Category.GetAll;
using learn_Russian_API.Models.Category.Update;
using learn_Russian_API.Models.Content.Create;
using learn_Russian_API.Models.Content.DemoContents;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using learn_Russian_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace DefaultNamespace
{
    
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DemonstrationContentsController : Controller
    {
        private IDemoContentsSourceService DemoContentsModelsourceService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
       
        
        public DemonstrationContentsController(
            AppDbContext context, 
            IMapper mapper,
            IDemoContentsSourceService dcms)
        {
            DemoContentsModelsourceService = dcms;
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<DemonstrationContentsRequest>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.DemonstrationContentses.ProjectTo<DemonstrationContentsRequest>(_mapper.ConfigurationProvider)
                .ToListAsync());
        }
        
        
        
        [HttpPost]
        [ProducesResponseType(typeof(DemonstrationContentsRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDemonstrationContents([FromBody] DemonstrationContentsCreate request)
        {
            /*var cnt = 0;
            var t = await _context.DemonstrationContentses..FindAsync(request.DemostrationContentses);
            if(t != null)
            {
                return BadRequest("Demonstration Content already exist");

            }*/
            
            
            /*if (await _context.DemonstrationContentses.CountAsync(x =>
            {
                var firstNotSecond = x.DemostrationContentses.Except(request.DemostrationContentses).ToList();
                var secondNotFirst = request.DemostrationContentses.Except(x.DemostrationContentses).ToList();
                if (!firstNotSecond.Any() & !secondNotFirst.Any())
                    return false;
                else
                    return true;
            })  != 0 )*/
            

            try
            {
                var res = await _context.DemonstrationContentses.AddAsync(_mapper.Map<DemonstrationContents>(request));
                await _context.SaveChangesAsync();
            
                return CreatedAtAction(nameof(CreateDemonstrationContents),
                    await _context.DemonstrationContentses.ProjectTo<DemonstrationContentsRequest>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
            
            
        }
        
        
        [HttpPut("source {id}")]
        [ProducesResponseType(typeof(DemonstrationContentsRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> Updatesource(long id, [FromBody] DemoContentsModel request)
        {

          
           var ctn =  DemoContentsModelsourceService.update(id,request);
           if(ctn == null)
               return NotFound("Source of Content wasn't found");
           
            return Ok(ctn); 
        }

        [HttpPut("Demosource {id}")]
        [ProducesResponseType(typeof(DemonstrationContentsRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDemosource(long id, [FromBody] DemoContentsModelCreate[] request)
        {

          
            var found = await _context.DemonstrationContentses.FindAsync(id);
            //var ctn =  DemoContentsModelsourceService.update(id,request);
            if(found == null) return NotFound("Demonstration Content wasn't found");

            try
            {
                foreach (var item in request)
                {
                    item.DemonstrationContentsId = found.Id;
                    var it = new DemoContentsModelCreate {src = item.src,title = item.title,DemonstrationContentsId = item.DemonstrationContentsId };
                    var res = await _context.DemoContentsModel.AddAsync(_mapper.Map<DemoContentsModel>(it));
                    await _context.SaveChangesAsync();

                }
                
                return CreatedAtAction(nameof(UpdateDemosource),
                    await _context.DemonstrationContentses
                        .ProjectTo<DemonstrationContentsRequest>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(x => x.Id == found.Id));
               
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            
        }
        
        [HttpDelete("source {id}")]
        public async Task<IActionResult> Deletesrc(long id)
        {
           var state =  DemoContentsModelsourceService.Delete(id);
           if (!state)
               return NotFound();

           
           return Ok();
        }

        [HttpDelete("DemoSource {id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var demosrc = await  _context.DemonstrationContentses.FindAsync(id);
            if (demosrc == null) return NotFound();

            _context.DemonstrationContentses.Remove(demosrc);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
    
}