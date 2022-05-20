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
    public class UyelersController : Controller
    {
        private readonly KutuphaneSabahContext _context;

        public UyelersController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        // GET: Uyelers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uyelers.ToListAsync());
        }

        // GET: Uyelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyeler = await _context.Uyelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uyeler == null)
            {
                return NotFound();
            }

            return View(uyeler);
        }

        // GET: Uyelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uyelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,Cinsiyet,DogumTarihi,Tel,Mail,UyelikTarihi,UyelikTipi,TcNo,Meslek,EgitimDurumu,CezaDurumu")] Uyeler uyeler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uyeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uyeler);
        }

        // GET: Uyelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyeler = await _context.Uyelers.FindAsync(id);
            if (uyeler == null)
            {
                return NotFound();
            }
            return View(uyeler);
        }

        // POST: Uyelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Cinsiyet,DogumTarihi,Tel,Mail,UyelikTarihi,UyelikTipi,TcNo,Meslek,EgitimDurumu,CezaDurumu")] Uyeler uyeler)
        {
            if (id != uyeler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uyeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UyelerExists(uyeler.Id))
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
            return View(uyeler);
        }

        // GET: Uyelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uyeler = await _context.Uyelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uyeler == null)
            {
                return NotFound();
            }

            return View(uyeler);
        }

        // POST: Uyelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uyeler = await _context.Uyelers.FindAsync(id);
            _context.Uyelers.Remove(uyeler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UyelerExists(int id)
        {
            return _context.Uyelers.Any(e => e.Id == id);
        }
    }
}
