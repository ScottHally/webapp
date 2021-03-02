using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    
    public class LeaguesController : Controller
    {
        private readonly WebApplication1Context _context;

        public LeaguesController(WebApplication1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Leagues"] = _context.League.ToList();

            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeagueID,Name,Sport")] League league)
        {
            if (ModelState.IsValid)
            {
                _context.Add(league);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(league);
        }
    }
}
