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
using Kursach.SendSMS;

namespace StudentAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PhoneDBController : ControllerBase
    {
        private readonly PhoneDB _context;

        public PhoneDBController(PhoneDB context)
        {
            _context = context;
        }

        [HttpGet("Phone")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAllNumbers()
        {
            return await _context.MealInfs.ToListAsync();
        }


        [HttpPost("Phone")]
        public async Task<ActionResult<Phone>> PostMeal(Phone phonedetail)
        {
            _context.MealInfs.Add(phonedetail);
            await _context.SaveChangesAsync();

            return Ok(phonedetail);
        }

    }
}
