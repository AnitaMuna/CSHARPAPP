using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csharp4.Models;

namespace csharp4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Squarer(String Number1, String Number2){
            ViewBag.Result = SqrtMethod(Number1, Number2);
            return View();
        }
        
        private static String SqrtMethod(String Num1, String Num2 ){
            int Number1;
            int Number2;
            string show = string.Empty;
            bool given1 =int.TryParse(Num1, out Number1);
            bool given2 =int.TryParse(Num2, out Number2);

            if (Num1 == "" || Num2 == ""){
                show = "Please input a value";
            }

            else if (given1 && given2) {
                if (Number1 < 0 || Number2 < 0) {
                    show = "Error! This is not a valid input. It is a negative number";
                }
                else {
                    double So1 = Math.Sqrt(Number1);
                    double So2 = Math.Sqrt(Number2);

                    if (So1 > So2) {
                        show = "The number " + Number1 + "with Square root " + So1 + "Has a higher square root than the number " + Number2 + "with Square root " + So2;
                    }
                    else if (So1 < So2) {
                        show = "The number " + Number2 + "with Square root " + So2 + "Has a higher square root than the number" + Number1 + "with Square root " + So1;
                    }
                    else if (So1 == So2){
                        show = "These values are equal. Please enter another value";
                    }
                }
            }
            else {
                show = "Invalid! Please enter a valid number";
            }

            return show;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
