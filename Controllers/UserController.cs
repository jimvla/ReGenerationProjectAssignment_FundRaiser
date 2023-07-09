using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;
using ReGenerationProjectAssignment_FundRaiser.Models;

namespace ReGenerationProjectAssignment_FundRaiser.Controllers
{
    public class UserController : Controller
    {
        private readonly CrmDbContext _context;

        public UserController(CrmDbContext context)
        {
            _context = context;
        }
        // GET: HomeController1
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: Users/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var product = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("UserId,UserName,UserSurName")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }             
    }
}
