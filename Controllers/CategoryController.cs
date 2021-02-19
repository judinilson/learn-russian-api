using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using learn_Russian_API.Models.Category.Create;
using learn_Russian_API.Models.Category.GetAll;
using learn_Russian_API.Models.Category.Update;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<CategoryGetAllResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Categories.ProjectTo<CategoryGetAllResponse>(_mapper.ConfigurationProvider)
                .ToListAsync());
        }
        
        
        
        [HttpPost]
        [ProducesResponseType(typeof(CategoryGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateRequest request)
        {
            if (await _context.Categories.CountAsync(x => x.Name.Equals(request.name)) != 0)
            {
                return BadRequest("Category name already exist");
            }
            
            var res = await _context.Categories.AddAsync(_mapper.Map<Category>(request));
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateCategory),
                await _context.Categories.ProjectTo<CategoryGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == res.Entity.Id));
        }
        
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoryGetAllResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategory(long id, [FromBody] CategoryUpdateRequest request)
        {

          
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound("Category wasn't found");
            category.Name = request.Name;
            
            
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Categories.ProjectTo<CategoryGetAllResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == category.Id));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var foundCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (foundCategory == null) return NotFound();

            _context.Categories.Remove(foundCategory);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}