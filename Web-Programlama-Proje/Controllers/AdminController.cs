using Microsoft.AspNetCore.Mvc;
using webprogramlama4.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace webprogramlama4.Data.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AdminController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}