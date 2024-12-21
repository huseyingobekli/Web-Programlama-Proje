using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_Programlama_Proje.Models;

namespace Web_Programlama_Proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Logger ba��ml�l��� enjekte ediliyor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana sayfa i�in View d�nd�r�l�yor
        public IActionResult Index()
        {
            return View();
        }

        // �leti�im sayfas� i�in View d�nd�r�l�yor
        public IActionResult iletisim()
        {
            return View();
        }

        // Gizlilik politikas� sayfas� i�in View d�nd�r�l�yor
        public IActionResult Privacy()
        {
            return View();
        }

        // Hata sayfas� i�in View d�nd�r�l�yor
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
