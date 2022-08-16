using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FoodAPI2.Client;
using FoodAPI2;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SQLite.EF6;
using Microsoft.AspNetCore.Mvc;
using KursachBot.Constants;
using KursachBot.Model;

namespace FoodAPI2.Client
{
    

    public class MealClient
    {
        private HttpClient _client;
        public static string _address;
        public static string _apiKey;
        public MealClient()
        {
            _address = Constants.address;
            _apiKey = Constants.apiKey;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        
        public async Task<MealGraphic> GenerateMealGraphic(string diet, string exclude,string calories)
        {
            var response = await _client.GetAsync($"/mealplanner/generate?diet={diet}&exclude={exclude}&targetCalories={calories}&apiKey={_apiKey}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MealGraphic>(content);
            return result;
        }

        public async Task<Model> GetFindMealAsync(string id)
        {
            var response = await _client.GetAsync($"recipes/{id}/information?apiKey={_apiKey}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Model>(content);
            return result;
        }
    }
}
