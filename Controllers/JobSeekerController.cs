using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobMatch;
using JobMatch.Data;

namespace JobMatch.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobSeekerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobSeeker
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobSeekers.ToListAsync());
        }

        // GET: JobSeeker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSeeker = await _context.JobSeekers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        // GET: JobSeeker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobSeeker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name,Education,Email,Phone,Resume")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobSeeker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobSeeker);
        }

        // GET: JobSeeker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSeeker = await _context.JobSeekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return NotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeeker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name,Education,Email,Phone,Resume")] JobSeeker jobSeeker)
        {
            if (id != jobSeeker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobSeeker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobSeekerExists(jobSeeker.Id))
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
            return View(jobSeeker);
        }

        // GET: JobSeeker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSeeker = await _context.JobSeekers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        // POST: JobSeeker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobSeeker = await _context.JobSeekers.FindAsync(id);
            if (jobSeeker != null)
            {
                _context.JobSeekers.Remove(jobSeeker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobSeekerExists(int id)
        {
            return _context.JobSeekers.Any(e => e.Id == id);
        }
    }
}
