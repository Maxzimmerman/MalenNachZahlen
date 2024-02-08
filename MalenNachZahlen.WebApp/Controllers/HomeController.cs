using MalenNachZahlen.WebApp.Models;
using MalenNachZahlen.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MalenNachZahlen.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string picture = "rocket";
            KoordinateSystem koordinateSystemRocket = new KoordinateSystem();
            koordinateSystemRocket.ReadCSV(Path.Combine(_webHostEnvironment.ContentRootPath, "dateien", $"{picture}.csv"));
            koordinateSystemRocket.SetFieldForRocket(9);
            koordinateSystemRocket.UpdateField();

            string bugImage = "bug";
            KoordinateSystem koordinateSystemBug = new KoordinateSystem();
            koordinateSystemBug.ReadCSV((Path.Combine(_webHostEnvironment.ContentRootPath, "dateien", $"{bugImage}.csv")));
            koordinateSystemBug.SetFieldForSizeForOtherThanRocket(13);
            koordinateSystemBug.UpdateField();

            string butterflyImage = "butterfly";
            KoordinateSystem koordinateSystemButterfly = new KoordinateSystem();
            koordinateSystemButterfly.ReadCSV((Path.Combine(_webHostEnvironment.ContentRootPath, "dateien", $"{butterflyImage}.csv")));
            koordinateSystemButterfly.SetFieldForSizeForOtherThanRocket(12);
            koordinateSystemButterfly.UpdateField();

            string bienImage = "bien";
            KoordinateSystem koordinateSystemBien = new KoordinateSystem();
            koordinateSystemBien.ReadCSV((Path.Combine(_webHostEnvironment.ContentRootPath, "dateien", $"{bienImage}.csv")));
            koordinateSystemBien.SetFieldForSizeForOtherThanRocket(11);
            koordinateSystemBien.UpdateField();

            ImagesViewModel images = new ImagesViewModel();
            images.rocketImage = koordinateSystemRocket;
            images.bugImage = koordinateSystemBug;
            images.bienImage = koordinateSystemBien;
            images.butterflytImage = koordinateSystemButterfly;


            return View(images);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
