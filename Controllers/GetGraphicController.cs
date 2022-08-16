using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SQLite.EF6;
using KursachBot.Model;
using FoodAPI2.Client;

namespace FoodAPI2.Controllers
{ 
    
    [ApiController]
    [Route("[controller]")]
    public class GetWeekMealGraphic : ControllerBase
    {

        [HttpGet(Name = "GetMeal")]
        public MealGraphic Meal2(string diet, string exclude, string calories)
        {
            try
            {
                MealClient client = new MealClient();
                return client.GenerateMealGraphic(diet, exclude, calories).Result;
            }
            catch(Exception ex)
            {
                return null;
            } 
        }

    }

    
}
