using Microsoft.AspNetCore.Mvc;
using KursachBot.Model;
using FoodAPI2.Client;

namespace FoodAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetMealInfbyID : ControllerBase
    {
        [HttpGet(Name = "GetMeal2")]
        public Model Meal(string id)
        {
            try
            {
                MealClient client = new MealClient();
                return client.GetFindMealAsync(id).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }


}
