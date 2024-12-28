using Microsoft.AspNetCore.Mvc;
using webprogramlama4.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace webprogramlama4.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurun.";
                return View();
            }
            if (_context.Users.Any(x => x.Username == username))
            {
                ViewBag.ErrorMessage = "Bu kullanıcı adı zaten kullanımda.";
                return View();
            }
            var newUser = new User
            {
                Username = username,
                Password = password, // Şifreyi düz metin olarak kaydediyoruz (Tehlikeli!)
                Email = email,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurun.";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}