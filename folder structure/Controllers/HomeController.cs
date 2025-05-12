using folder_structure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace folder_structure.Controllers
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
        public string Hello() // Non-view action
        {
            return "Hello World!";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetJson()
        {
            return Json(new { Name = "John", Age = 30 });
        }
        //public ActionResult GetImage()
        //{
        //    // Load image bytes from file system, database, or other source
        //    string imagePath = Server.MapPath("~/Images/sample.png");
        //    byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

        //    // Return the image with MIME type
        //    return File(imageBytes, "image/png");
        //}

        //// Optional: To force download instead of displaying
        //public ActionResult DownloadImage()
        //{
        //    string imagePath = Server.MapPath("~/Images/sample.png");
        //    byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

        //    return File(imageBytes, "image/png", "downloaded-image.png");
        //}
    }
}
