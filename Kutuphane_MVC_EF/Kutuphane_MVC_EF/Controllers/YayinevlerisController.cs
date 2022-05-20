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
    public class YayinevlerisController : Controller
    {
        private readonly KutuphaneSabahContext _context;

        public YayinevlerisController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        // GET: Yayinevleris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yayinevleris.ToListAsync());
        }

        // GET: Yayinevleris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevleri = await _context.Yayinevleris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yayinevleri == null)
            {
                return NotFound();
            }

            return View(yayinevleri);
        }

        // GET: Yayinevleris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yayinevleris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Adres,Tel")] Yayinevleri yayinevleri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yayinevleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yayinevleri);
        }

        // GET: Yayinevleris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevleri = await _context.Yayinevleris.FindAsync(id);
            if (yayinevleri == null)
            {
                return NotFound();
            }
            return View(yayinevleri);
        }

        // POST: Yayinevleris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Adres,Tel")] Yayinevleri yayinevleri)
        {
            if (id != yayinevleri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yayinevleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YayinevleriExists(yayinevleri.Id))
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
            return View(yayinevleri);
        }

        // GET: Yayinevleris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevleri = await _context.Yayinevleris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yayinevleri == null)
            {
                return NotFound();
            }

            return View(yayinevleri);
        }

        // POST: Yayinevleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yayinevleri = await _context.Yayinevleris.FindAsync(id);
            _context.Yayinevleris.Remove(yayinevleri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YayinevleriExists(int id)
        {
            return _context.Yayinevleris.Any(e => e.Id == id);
        }
    }
}
