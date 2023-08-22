using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;
using System.Diagnostics;

namespace RRHHCapucasCoffe.Controllers
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

        public IActionResult NoEncontrado()
        {
            return View();
        }

        //[responsecache(duration = 0, location = responsecachelocation.none, nostore = true)]
        //public iactionresult error(int statuscode)
        //{
        //    if (statuscode == 404)
        //    {
        //        return view("noencontrado");
        //    }
        //    else
        //    {
        //        return view(new errorviewmodel { requestid = activity.current?.id ?? httpcontext.traceidentifier });
        //    }
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}