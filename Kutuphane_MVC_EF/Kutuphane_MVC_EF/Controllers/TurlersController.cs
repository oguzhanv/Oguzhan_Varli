using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kutuphane_MVC_EF.Models;

namespace Kutuphane_MVC_EF.Controllers
{
    public class TurlersController : Controller
    {
        private readonly KutuphaneSabahContext _context;

        public TurlersController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        // GET: Turlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turlers.ToListAsync());
        }

        // GET: Turlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turler = await _context.Turlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turler == null)
            {
                return NotFound();
            }

            return View(turler);
        }

        // GET: Turlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurAd")] Turler turler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turler);
        }

        // GET: Turlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turler = await _context.Turlers.FindAsync(id);
            if (turler == null)
            {
                return NotFound();
            }
            return View(turler);
        }

        // POST: Turlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurAd")] Turler turler)
        {
            if (id != turler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurlerExists(turler.Id))
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
            return View(turler);
        }

        // GET: Turlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turler = await _context.Turlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turler == null)
            {
                return NotFound();
            }

            return View(turler);
        }

        // POST: Turlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turler = await _context.Turlers.FindAsync(id);
            _context.Turlers.Remove(turler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurlerExists(int id)
        {
            return _context.Turlers.Any(e => e.Id == id);
        }
    }
}
