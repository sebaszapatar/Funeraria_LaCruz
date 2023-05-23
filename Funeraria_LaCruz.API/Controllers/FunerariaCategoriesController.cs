using Funeraria_LaCruz.API.Data;
using Funeraria_LaCruz.API.Helpers;
using Funeraria_LaCruz.Shared.DTOS;
using Funeraria_LaCruz.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Funeraria_LaCruz.API.Controllers
{

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("/api/FunerariaCategories")]



    public class FunerariaCategoriesController : ControllerBase
    {

        private readonly DataContext _context;

        public FunerariaCategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(FunerariaCategory funerariaCategory)
        {
            _context.Add(funerariaCategory);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(funerariaCategory);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoria con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.FunerariaCategories
                .Include(x => x.Products)
                .Where(x => x.Categories!.Id == pagination.Id)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            return Ok(await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.FunerariaCategories
               .Where(x => x.Categories!.Id == pagination.Id)
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }


            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var funerariaCategory = await _context.FunerariaCategories
                 .Include(x => x.Products!)
                 .FirstOrDefaultAsync(x => x.Id == id);
            if (funerariaCategory is null)
            {
                return NotFound();
            }

            return Ok(funerariaCategory);
        }

        ////Borrar e intentar si sale cargando...

        //[HttpGet("full")]
        //public async Task<ActionResult> GetFull()
        //{
        //    return Ok(await _context.Categories
        //        .Include(x => x.FunerariaCategories!)
        //        .ThenInclude(x => x.Products)
        //        .ToListAsync());
        //}


        [HttpPut]
        public async Task<ActionResult> Put(FunerariaCategory funerariaCategory)
        {
            _context.Update(funerariaCategory);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(funerariaCategory);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.FunerariaCategories
                .Where(y => y.Id == id)

                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }


}

