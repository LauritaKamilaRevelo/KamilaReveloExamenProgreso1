using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KamilaReveloExamenProgreso1.Models;

namespace KamilaReveloExamenProgreso1.Controllers
{
    public class KRmodelo1Controller : Controller
    {
        private readonly KamilaReveloExamenProgreso1Context _context;

        public KRmodelo1Controller(KamilaReveloExamenProgreso1Context context)
        {
            _context = context;
        }

        // GET: KRmodelo1
        public async Task<IActionResult> KRIndex()
        {
            return View(await _context.KRmodelo1.ToListAsync());
        }

        // GET: KRmodelo1/Details/5
        public async Task<IActionResult> KRDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kRmodelo1 = await _context.KRmodelo1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kRmodelo1 == null)
            {
                return NotFound();
            }

            return View(kRmodelo1);
        }

        // GET: KRmodelo1/Create
        public IActionResult KRCreate()
        {
            return View();
        }

        // POST: KRmodelo1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KRCreate([Bind("Id,Nombre,WithTea,Precio,FechaRegristo,FechaFinal")] KRmodelo1 kRmodelo1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kRmodelo1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(KRIndex));
            }
            return View(kRmodelo1);
        }

        // GET: KRmodelo1/Edit/5
        public async Task<IActionResult> KREdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kRmodelo1 = await _context.KRmodelo1.FindAsync(id);
            if (kRmodelo1 == null)
            {
                return NotFound();
            }
            return View(kRmodelo1);
        }

        // POST: KRmodelo1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KREdit(int id, [Bind("Id,Nombre,WithTea,Precio,FechaRegristo,FechaFinal")] KRmodelo1 kRmodelo1)
        {
            if (id != kRmodelo1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kRmodelo1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KRmodelo1Exists(kRmodelo1.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(KRIndex));
            }
            return View(kRmodelo1);
        }

        // GET: KRmodelo1/Delete/5
        public async Task<IActionResult> KRDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kRmodelo1 = await _context.KRmodelo1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kRmodelo1 == null)
            {
                return NotFound();
            }

            return View(kRmodelo1);
        }

        // POST: KRmodelo1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kRmodelo1 = await _context.KRmodelo1.FindAsync(id);
            if (kRmodelo1 != null)
            {
                _context.KRmodelo1.Remove(kRmodelo1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(KRIndex));
        }

        private bool KRmodelo1Exists(int id)
        {
            return _context.KRmodelo1.Any(e => e.Id == id);
        }
    }
}
