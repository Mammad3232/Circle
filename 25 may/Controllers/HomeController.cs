using _25_may.DAL;
using _25_may.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace _25_may.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<History> histories = _context.histories.Where(c=>!c.IsDeleted).ToList();

            return View(histories);
        }
    }
}
