using CollectionManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollectionManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CollectionManagerDbContext _context;

        public HomeController(ILogger<HomeController> logger, CollectionManagerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            return View();

        }

        public IActionResult ViewThem()
        {
            List<Links> list = _context.Links.Where(x => x.Id > 0).ToList();

            return View(list);
        }


        [HttpPost]
        public IActionResult Add(Links model)
        {
            _context.Links.Add(model);
            _context.SaveChanges();

            return RedirectToAction("ViewThem");
        }

        public IActionResult Delete(int id)
        {
            Links link = _context.Links.Find(id);
            if (link != null)
            {
                _context.Links.Remove(link);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewThem");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}