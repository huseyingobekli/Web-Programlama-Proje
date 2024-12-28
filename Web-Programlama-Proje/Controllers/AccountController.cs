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
                Password = password,
                Email = email,
                CreatedDate = DateTime.Now,
                Role = "User"
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Başarıyla kayıt oldunuz!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password) // Parameter olarak IHttpContextAccessor parametresini kaldırdık.
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

            _httpContextAccessor.HttpContext.Session.SetString("Username", user.Username);
            _httpContextAccessor.HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Admin")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}