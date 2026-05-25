using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _25_may.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
