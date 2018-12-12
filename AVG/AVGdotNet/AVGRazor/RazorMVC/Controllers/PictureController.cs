using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorMVC.Models;

namespace RazorMVC.Controllers
{
    public class PictureController : Controller
    {
        private readonly AVGContext _context;

        public PictureController(AVGContext context)
        {
            _context = context;
        }

        // GET: Picture
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pictures.ToListAsync());
        }

        // GET: Picture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures
                .SingleOrDefaultAsync(m => m.ID == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Picture/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,Description,Location,Path")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(picture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(picture);
        }

        // GET: Picture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures.SingleOrDefaultAsync(m => m.ID == id);
            if (picture == null)
            {
                return NotFound();
            }
            return View(picture);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,Description,Location,Path")] Picture picture)
        {
            if (id != picture.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(picture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureExists(picture.ID))
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
            return View(picture);
        }

        // GET: Picture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures
                .SingleOrDefaultAsync(m => m.ID == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var picture = await _context.Pictures.SingleOrDefaultAsync(m => m.ID == id);
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureExists(int id)
        {
            return _context.Pictures.Any(e => e.ID == id);
        }
    }
}
