using Dictionary_Test.Data;
using Dictionary_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaltionController : Controller
    {
        private readonly TranslationApiDbContext dbContext;
        public TransaltionController(TranslationApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetTranslation()
        {
            return Ok(await dbContext.Translation.ToListAsync());
            
        }

        [HttpPost]
        public async Task<IActionResult> AddTranslation(AddTranslation addtranslation)
        {
            var translation = new Translation()
            {
                Id = Guid.NewGuid(),
                English = addtranslation.English,
                Hungarian = addtranslation.Hungarian
            };

            await dbContext.Translation.AddAsync(translation);
            await dbContext.SaveChangesAsync();

            return Ok(translation);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetTranslation_Id([FromRoute] Guid id)
        {
            var translate = await dbContext.Translation.FindAsync(id);
            if(translate == null)
            {
                return NotFound();
            }
            return Ok(translate);
        }

        [HttpGet]
        [Route("{Name:alpha}")]

        public IActionResult GetTranslation_Name([FromRoute] string Name)
            {       
            var translate =  dbContext.Translation.Where(b => b.English == Name ).FirstOrDefault();
            if (translate == null)
            {
                return NotFound();
            }
            return Ok(translate);
        }
    }   
}
