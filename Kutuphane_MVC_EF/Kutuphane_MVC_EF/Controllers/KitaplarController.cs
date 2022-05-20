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
    public class KitaplarController : Controller
    {
        private readonly KutuphaneSabahContext _context;

        public KitaplarController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        // GET: Kitaplar
        public async Task<IActionResult> Index()
        {
            var kutuphaneSabahContext = _context.Kitaplars.Include(k => k.Turler).Include(k => k.YayinEvleri).Include(k => k.Yazarlar);
            return View(await kutuphaneSabahContext.ToListAsync());
        }

        // GET: Kitaplar/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars
                .Include(k => k.Turler)
                .Include(k => k.YayinEvleri)
                .Include(k => k.Yazarlar)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // GET: Kitaplar/Create
        public IActionResult Create()
        {
            ViewData["TurlerId"] = new SelectList(_context.Turlers, "Id", "TurAd");
            ViewData["YayinEvleriId"] = new SelectList(_context.Yayinevleris, "Id", "Ad");
            ViewData["YazarlarId"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad");
            return View();
        }

        // POST: Kitaplar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Isbn,Ad,SayfaSayisi,Stok,TurlerId,YazarlarId,YayinEvleriId")] Kitaplar kitaplar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitaplar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurlerId"] = new SelectList(_context.Turlers, "Id", "Id", kitaplar.TurlerId);
            ViewData["YayinEvleriId"] = new SelectList(_context.Yayinevleris, "Id", "Id", kitaplar.YayinEvleriId);
            ViewData["YazarlarId"] = new SelectList(_context.Yazarlars, "Id", "Id", kitaplar.YazarlarId);
            return View(kitaplar);
        }

        // GET: Kitaplar/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars.FindAsync(id);
            if (kitaplar == null)
            {
                return NotFound();
            }
            ViewData["TurlerId"] = new SelectList(_context.Turlers, "Id", "TurAd", kitaplar.TurlerId);
            ViewData["YayinEvleriId"] = new SelectList(_context.Yayinevleris, "Id", "Ad", kitaplar.YayinEvleriId);
            ViewData["YazarlarId"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", kitaplar.YazarlarId);
            return View(kitaplar);
        }

        // POST: Kitaplar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Isbn,Ad,SayfaSayisi,Stok,TurlerId,YazarlarId,YayinEvleriId")] Kitaplar kitaplar)
        {
            if (id != kitaplar.Isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitaplar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitaplarExists(kitaplar.Isbn))
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
            ViewData["TurlerId"] = new SelectList(_context.Turlers, "Id", "Id", kitaplar.TurlerId);
            ViewData["YayinEvleriId"] = new SelectList(_context.Yayinevleris, "Id", "Id", kitaplar.YayinEvleriId);
            ViewData["YazarlarId"] = new SelectList(_context.Yazarlars, "Id", "Id", kitaplar.YazarlarId);
            return View(kitaplar);
        }

        // GET: Kitaplar/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars
                .Include(k => k.Turler)
                .Include(k => k.YayinEvleri)
                .Include(k => k.Yazarlar)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // POST: Kitaplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kitaplar = await _context.Kitaplars.FindAsync(id);
            _context.Kitaplars.Remove(kitaplar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitaplarExists(string id)
        {
            return _context.Kitaplars.Any(e => e.Isbn == id);
        }
    }
}
