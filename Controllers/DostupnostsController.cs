using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automobili.Models;

namespace Automobili.Controllers
{
    public class DostupnostsController : Controller
    {
        private readonly AutomobiliContext _context;

        public DostupnostsController(AutomobiliContext context)
        {
            _context = context;
        }

        // GET: Dostupnosts
        public async Task<IActionResult> Index()
        {
            var automobiliContext = _context.Dostupnost.Include(d => d.MarkaAutomobila);
            return View(await automobiliContext.ToListAsync());
        }

        // GET: Dostupnosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostupnost = await _context.Dostupnost
                .Include(d => d.MarkaAutomobila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostupnost == null)
            {
                return NotFound();
            }

            return View(dostupnost);
        }

        // GET: Dostupnosts/Create
        public IActionResult Create()
        {
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Naziv");
            return View();
        }

        // POST: Dostupnosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MarkaId,Tip,GodinaProzvodnje,BenzinDizel,BrojBrzina,Kontakt")] Dostupnost dostupnost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dostupnost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Naziv", dostupnost.MarkaId);
            return View(dostupnost);
        }

        // GET: Dostupnosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostupnost = await _context.Dostupnost.FindAsync(id);
            if (dostupnost == null)
            {
                return NotFound();
            }
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Naziv", dostupnost.MarkaId);
            return View(dostupnost);
        }

        // POST: Dostupnosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MarkaId,Tip,GodinaProzvodnje,BenzinDizel,BrojBrzina,Kontakt")] Dostupnost dostupnost)
        {
            if (id != dostupnost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dostupnost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DostupnostExists(dostupnost.Id))
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
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Naziv", dostupnost.MarkaId);
            return View(dostupnost);
        }

        // GET: Dostupnosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostupnost = await _context.Dostupnost
                .Include(d => d.MarkaAutomobila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostupnost == null)
            {
                return NotFound();
            }

            return View(dostupnost);
        }

        // POST: Dostupnosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dostupnost = await _context.Dostupnost.FindAsync(id);
            _context.Dostupnost.Remove(dostupnost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DostupnostExists(int id)
        {
            return _context.Dostupnost.Any(e => e.Id == id);
        }
    }
}
