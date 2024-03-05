using Microsoft.AspNetCore.Mvc;

namespace WebApplicationIdentity.Controllers
{
    public class TechnicalController : Controller
    {
        // GET: TechnicalModule
        public ActionResult Index()
        {
            // Sample technical questions
            List<Tuple<string, List<string>, string>> technicalQuestions = new List<Tuple<string, List<string>, string>>
            {
                // Database Technology Questions
                Tuple.Create("What is the primary key in a relational database?", new List<string>{"A field that uniquely identifies each record in a table", "A field that may contain NULL values", "A field that is indexed for faster retrieval", "A field that is a foreign key in another table"}, "A field that uniquely identifies each record in a table"),
                Tuple.Create("Which SQL keyword is used to retrieve data from a table?", new List<string>{"SELECT", "FETCH", "GET", "RETRIEVE"}, "SELECT"),

                // Core Java Questions
                Tuple.Create("What is the default value of the data type 'int' in Java?", new List<string>{"0", "1", "-1", "null"}, "0"),
                Tuple.Create("Which keyword is used to define a constant in Java?", new List<string>{"final", "const", "static", "define"}, "final"),

                // Data Structures and Algorithms Questions
                Tuple.Create("What is the time complexity of binary search in the worst case?", new List<string>{"O(log n)", "O(n)", "O(n log n)", "O(n^2)"}, "O(log n)"),
                Tuple.Create("Which data structure follows the Last In, First Out (LIFO) principle?", new List<string>{"Stack", "Queue", "Heap", "Linked List"}, "Stack")
            };

            return View(technicalQuestions);
        }
    }
}
