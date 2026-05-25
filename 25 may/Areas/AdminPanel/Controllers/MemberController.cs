using _25_may.Areas.AdminPanel.ViewModel;
using _25_may.DAL;
using _25_may.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace _25_may.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        public MemberController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.histories.Where(c => !c.IsDeleted));
        }
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVM createvm)
        {
            if (!ModelState.IsValid)
            {
                return View(createvm);
            }
            History newMember = new History
            {
                ImageURL = createvm.ImageURL,
                Title = createvm.Title
,
                Descriiption = createvm.Descriiption
            };


            await _context.histories.AddAsync(newMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public IActionResult Update(int? id)
        {
            if (id == null) return BadRequest();
            History product = _context.histories.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            UpdateVM updatevm = new UpdateVM
            {
                ImageURL = product.ImageURL,
                Title = product.Title,
                Descriiption = product.Descriiption
            };
            return View(updatevm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, UpdateVM updateVM)
        {
            if (id == null) return BadRequest();
            History product = _context.histories.FirstOrDefault(y => y.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            product.ImageURL = updateVM.ImageURL;
            product.Title = updateVM.Title;
            product.Descriiption = updateVM.Descriiption;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            History product = _context.histories.Where(c => !c.IsDeleted).FirstOrDefault(y => y.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
