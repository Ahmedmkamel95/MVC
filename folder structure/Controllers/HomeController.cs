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

        public IActionResult GetImage()
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sample.jpg");
                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(imageBytes, "image/jpeg");
            }
        /*
     "wwwroot/images/sample.jpg": Replace with your actual image path.

    "image/jpeg": MIME type for .jpg. Use "image/png" for .png, etc.

    "DownloadedImage.jpg": This will be the default name in the download dialog.
         */
        public IActionResult DownloadImage()
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sample.jpg");

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound("Image not found.");
            }

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg", "DownloadedImage.jpg");
        }
    }
}
