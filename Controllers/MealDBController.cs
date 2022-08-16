using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SQLite.EF6;
using Meal.Models;
using KursachBot.Model;

namespace StudentAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MealDBController : ControllerBase
    {
        private readonly MealDB _context;

        public MealDBController(MealDB context)
        {
            _context = context;
        }

        [HttpGet("Meal")]
        public async Task<ActionResult<IEnumerable<Model>>> GetAllMeals()
        {
            return await _context.MealInfs.ToListAsync();
        }



        [HttpGet("{id}/Meal")]
        public async Task<ActionResult<Model>> GetMealDetail(int id)
        {
            var studentDetail = await _context.MealInfs.FindAsync(id);

            if (studentDetail == null)
            {
                return NotFound();
            }

            return studentDetail;
        }

        [HttpPut("{id}/Meal")]
        public async Task<IActionResult> PutMeal(int id, Model mealdetail)
        {
            if (id != mealdetail.id)
            {
                return BadRequest();
            }

            _context.Entry(mealdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetMealDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost("Meal")]
        public async Task<ActionResult<Model>> PostMeal(Model mealdetail)
        {
            _context.MealInfs.Add(mealdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDetail", new { id = mealdetail.readyInMinutes }, mealdetail);
        }

        [HttpDelete("{id}/Meal")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var mealdetail = await _context.MealInfs.FindAsync(id);
            if (mealdetail == null)
            {
                return NotFound();
            }

            _context.MealInfs.Remove(mealdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GetMealDetailExists(int id)
        {
            return _context.MealInfs.Any(e => e.readyInMinutes == id);
        }
    }
}
