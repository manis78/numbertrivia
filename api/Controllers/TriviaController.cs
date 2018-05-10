using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TriviaController : Controller
    {
        //test for demo
        //Test run
        //Added comments for screenshots
        // GET api/trivia/number
        [HttpGet("{number}")]
        public async Task<TriviaResponse> GetAsync(int number)
        {
            if(number == 444)
            {
                return new TriviaResponse { Text = "Triple four", Number = 444, Found = true, Type = "hardcoded trivia" };
            }
            
            if(number == 666)
            {
                return new TriviaResponse { Text = "The number of the beast.", Number = 666, Found = true, Type = "hardcoded trivia" };
            }
            //Call numbersapi.com and return results
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://numbersapi.com/" + number + "?json");
            var triviaResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TriviaResponse>(triviaResult);
        }
    }


}