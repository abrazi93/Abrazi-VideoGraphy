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
    public class VideoController : Controller
    {
        private readonly AVGContext _context;

        public VideoController(AVGContext context)
        {
            _context = context;
        }

        // GET: Video
        public async Task<IActionResult> Index(string searchString)
        {
            var videos = _context.Videos.Select(v => v);

            if(!String.IsNullOrEmpty(searchString))
            {
                videos = _context.Videos.Where(v => v.Title.Contains(searchString));
            }

            return View(await videos.ToListAsync());
        }

        // GET: Video/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Video/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,Description,Location,Path")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Video/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.SingleOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Video/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,Description,Location,Path")] Video video)
        {
            if (id != video.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.ID))
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
            return View(video);
        }

        // GET: Video/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var video = await _context.Videos.SingleOrDefaultAsync(m => m.ID == id);
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.ID == id);
        }
    }
}
