using Microsoft.AspNetCore.Mvc;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;
using ReGenerationProjectAssignment_FundRaiser.Models;
using System.Diagnostics;

namespace ReGenerationProjectAssignment_FundRaiser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrmDbContext _context;

        public HomeController(ILogger<HomeController> logger, CrmDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        


        public IActionResult Index()
        {
            var trending = _context.Projects.OrderByDescending(x => x.TotalAmount);
            var topThree = trending.Take(3);
            return View(topThree);
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