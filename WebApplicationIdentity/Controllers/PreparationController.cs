using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationIdentity.Controllers
{
    public class PreparationController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var apiKey = "0jwpC0lmPTNq0hyaOQ9bv3POXb1fVubpX7SdZbcA";
            var token = "0jwpC0lmPTNq0hyaOQ9bv3POXb1fVubpX7SdZbcA";
            var apiUrl = $"https://quizapi.io/api/v1/questions?apiKey={apiKey}&limit=10&token={token}";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

             
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseBody);

                    
                    return View("Index", responseBody);
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Error = $"Error: {ex.Message}";
                    return View("ErrorView");
                }
            }
        }
    }
}
