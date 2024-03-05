using Microsoft.AspNetCore.Mvc;

namespace WebApplicationIdentity.Controllers
{
    public class AptitudeController : Controller
    {
        // GET: Aptitude
        public ActionResult Index()
        {
            // Sample aptitude questions
            List<Tuple<string, List<string>, string>> aptitudeQuestions = new List<Tuple<string, List<string>, string>>
            {
                Tuple.Create("What is 10% of 50?", new List<string>{"5", "10", "15", "20"}, "5"),
                Tuple.Create("Which is the next number in the series: 2, 4, 8, 16, ...?", new List<string>{"32", "64", "128", "256"}, "32"),
                Tuple.Create("If a car travels at a speed of 60 km/h, how far will it travel in 2 hours?", new List<string>{"60 km", "120 km", "180 km", "240 km"}, "120 km"),
                Tuple.Create("What is the square root of 144?", new List<string>{"10", "12", "14", "16"}, "12"),
                Tuple.Create("How many sides does a hexagon have?", new List<string>{"4", "5", "6", "7"}, "6")
            };

            return View(aptitudeQuestions);
        }
    }
}
