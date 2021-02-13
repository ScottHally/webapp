using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlayersController : Controller
    {
        private readonly WebApplication1Context _context;

        public PlayersController(WebApplication1Context context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Test(int id, Player player)
        {

            return "Hello... " + id + " " + player.Name;
        }


        // GET: Players
        public async Task<IActionResult> Index(string playerTeam, string searchString)
        {

            IQueryable<string> teamQuery = from p in _context.Player
                                           orderby p.Team
                                           select p.Team;

            var players = from p in _context.Player select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(playerTeam))
            {
                players = players.Where(x => x.Team == playerTeam);
            }

            var playerTeamVM = new PlayerTeamViewModel
            {
                Teams = new SelectList(await teamQuery.Distinct().ToListAsync()),
                Players = await players.ToListAsync()
            };



            return View(playerTeamVM);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,Team,Salary,Rating")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,Team,Salary,Rating")] Player player)
        {
            // this doesn't work if we modify the routing as we have.
            // we have no route id
            //if (id != player.Id)
            //{
            //    return NotFound();
            //}

            var players = from p in _context.Player select p;
            var pId = players.Where(p => p.Id == player.Id);
            
            if(players.Count() == 0)
            {
                return NotFound();
            }
            else if(pId.Count() == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
            //return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SubmitEdit(int id, Player player)
        {
            if (id != player.Id)
            {
                return NotFound(); ;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
