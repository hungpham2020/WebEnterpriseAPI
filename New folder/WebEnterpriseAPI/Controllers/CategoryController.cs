using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEnterpriseAPI.Data;
using WebEnterpriseAPI.Model;

namespace WebEnterpriseAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CustomContext context;
        public CategoryController(CustomContext _context)
        {
            context = _context;
        }

        //[HttpGet]
        //public IEnumerable<Category> ViewAll()
        //{
        //    var categories = (from c in context.Categories
        //                      select new Category
        //                      {
        //                          Name = c.Name,
        //                          Description = c.Description,
        //                          Id = c.Id,

        //                      }).ToList();
        //    return categories;
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCate()
        {
            return await context.Categories.ToListAsync();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Category>> GetCate(int id)
        {
            var cat = await context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCat(Category cat)
        {
            context.Categories.Add(cat);
            await context.SaveChangesAsync();
            return Ok(new { id = cat.Id });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditCat(int id, Category cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }

            context.Entry(cat).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExits(id))
                {
                    return NotFound();
                }
                throw;
            }
            return Ok(new { status = 200, data = cat });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var cat = await context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            context.Categories.Remove(cat);
            await context.SaveChangesAsync();

            return Content("Delete done" + cat.Name + "with id:" + cat.Id);
        }

        private bool categoryExits(int id)
        {
            return context.Categories.Any(c => c.Id == id);
        }
    }
}
