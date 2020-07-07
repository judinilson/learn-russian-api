using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DefaultNamespace;
using learn_Russian_API.Models.Category.GetAll;
using learn_Russian_API.Models.Content.Create;
using learn_Russian_API.Models.Content.GetAll;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ContentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public ContentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ContentGetAllResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Contents.ProjectTo<ContentGetAllResponse>(_mapper.ConfigurationProvider)
                .ToListAsync());
        }
        
        [HttpGet("Demonstration-Content")]
        [ProducesResponseType(typeof(ICollection<DemonstrationContentResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDemoContent()
        {
            
            var getdemo = await _context.Contents.Where(x => x.isDemo)
                .ProjectTo<DemonstrationContentResponse>(_mapper.ConfigurationProvider)
               .ToListAsync();
            
            return Ok(getdemo);
        }
        
        [HttpGet("Article-Content")]
        [ProducesResponseType(typeof(ICollection<ArticleContentResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArticleContent()
        {
            
            var getArticle = await _context.Contents.Where(x => x.isArticle)
                .ProjectTo<ArticleContentResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return Ok(getArticle);
        }
        
        
        [HttpPost("Content-Demo-Create")]
        [ProducesResponseType(typeof(ContentGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateContentDemo([FromBody] ContentDemoCreate request)
        {
            
            
            var res = await _context.Contents.AddAsync(_mapper.Map<Content>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateContentDemo),
                await _context.Contents.ProjectTo<ContentGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }
        
        [HttpPost("Content-Article-Create")]
        [ProducesResponseType(typeof(ContentGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateContentArticle([FromBody] ContentArticleCreate request)
        {
            
            
            var res = await _context.Contents.AddAsync(_mapper.Map<Content>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateContentArticle),
                await _context.Contents.ProjectTo<ContentGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }
    }
}