 using System;
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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
 using learn_Russian_API.Models.Content.DemoContents;
 using Microsoft.Extensions.Logging;
 using Microsoft.OpenApi.Any;

 namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class
    ContentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostingEnviroment;
        //private readonly FileService _fileService;
        private readonly ILogger<ContentController > _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public ContentController(
            AppDbContext context, 
            IMapper mapper,
            IWebHostEnvironment hostingEnvironment,
            ILogger<ContentController> logger, 
            IHttpContextAccessor httpContextAccessor
            )
        {
            _context = context;
            _mapper = mapper;
            _hostingEnviroment = hostingEnvironment;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
             //_fileService = fileService;

             ;
            //string host = _httpContextAccessor.HttpContext.Request.Host.Value;
             //Console.WriteLine(host);
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

        [HttpPost("Article-Content")]
        [ProducesResponseType(typeof(ICollection<ArticleContentResponse>),StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateArticleContent([FromBody]ContentArticleCreate request)
        {
            try
            {
               
                var res = await _context.Contents.AddAsync(_mapper.Map<Content>(request));
                await _context.SaveChangesAsync();
            
                return CreatedAtAction(nameof(CreateArticleContent),
                    await _context.Contents.ProjectTo<ArticleContentResponse>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
            }catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }
        
        [HttpPut("Article-Content {id}")]
        [ProducesResponseType(typeof(ICollection<ArticleContentResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateArticleContent(long id, [FromBody] ContentArticleCreate request)
        {

          
            var article_content = await _context.Contents
                .FirstOrDefaultAsync(c => c.Id == id);
            if (article_content == null) return NotFound("Article Content wasn't found");
            article_content.title = request.title;
            article_content.subtitle = request.subtitle;
            article_content.coverImage = request.coverImage;
            article_content.categoryID = request.categoryID;
            article_content.article = request.article;
            article_content.created = request.created;
            //demo_content.DemonstrationContentID = request.DemonstrationContentID;



            _context.Contents.Update(article_content);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Contents.ProjectTo<ArticleContentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == article_content.Id));
        }

        
        [HttpPost("Content-Demo-Create")]
        [ProducesResponseType(typeof(ContentGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateContentDemo([FromBody] ContentDemoCreate request)
        {
           
          try{
              var res = await _context.Contents.AddAsync(_mapper.Map<Content>(request));
              await _context.SaveChangesAsync();
            
              return CreatedAtAction(nameof(CreateContentDemo),
                  await _context.Contents.ProjectTo<ContentGetAllResponse>(_mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
          }catch (Exception exception)
          {
              return BadRequest($"Error: {exception.Message}");
          }
           
        }
        
        /* PUT DEMO CONTENT */
        [HttpPut("Content-Demo {id}")]
        [ProducesResponseType(typeof(ContentGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateContentDemo(long id, [FromBody] ContentDemoCreate request)
        {

          
            var demo_content = await _context.Contents
                .FirstOrDefaultAsync(c => c.Id == id);
            if (demo_content == null) return NotFound("Content wasn't found");
            demo_content.title = request.title;
            demo_content.subtitle = request.subtitle;
            demo_content.coverImage = request.coverImage;
            demo_content.categoryID = request.categoryID;
            demo_content.created = request.created;
            //demo_content.DemonstrationContentID = request.DemonstrationContentID;



            _context.Contents.Update(demo_content);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Contents.ProjectTo<ContentGetAllResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == demo_content.Id));
        }
        
        
        // DELETE DEMO CONTENT 
        [HttpDelete("Content {id}")]
        public async Task<IActionResult> DeleteContentDemo(long id)
        {
            var contentfound = await _context.Contents.FindAsync(id);
            if (contentfound != null)
            {
                 _context.Contents.Remove(contentfound);
                 await _context.SaveChangesAsync();
                 return Ok("Content Deleted SUCCESSFULLY !!");
            }
            return NotFound("Incorrect ID content Wasn't found");
        }
        
        
        
        [HttpPost("upload-files"),DisableRequestSizeLimit]
        public  IActionResult UploadFile()
        {
           
            List<String> urls = new List<string>();
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            try
                {
                    var files = Request.Form.Files;
                    var folderName = Path.Combine("Resources", "media-files");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (files.Any(f => f.Length == 0))
                    {
                        return BadRequest();
                    }
                    foreach (var file in files)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(host,folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        dbPath = dbPath.Replace("\\", "/");
                        urls.Add(dbPath);
                    }
                    
                    return Ok(urls.ToList());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
        }
       
        
        [HttpPost("upload-coverimg"), DisableRequestSizeLimit]
        public IActionResult UploadImage()
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(host,folderName, fileName);
                    dbPath = dbPath.Replace("\\", "/");

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
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