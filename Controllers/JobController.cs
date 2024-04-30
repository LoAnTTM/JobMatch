using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


using JobMatch;
using JobMatch.Data;

namespace JobMatch.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public JobController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jobs.Include(j => j.Employer).Include(j => j.JobCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        //GET: Job/MyJobs
        public async Task<IActionResult> MyJobs()
        {
            //As this employer, get all jobs created by this employer
            var userId = _userManager.GetUserId(User); 
            var jobs = _context.Jobs
                .Include(j => j.Employer)
                .Include(j => j.JobCategory)
                .Where(j => j.Employer.UserId == userId);
            return View("Jobs", await jobs.ToListAsync());
        }

        // GET: Job/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Employer)
                .Include(j => j.JobCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Job/Create/
        public IActionResult Create()
        {
            // var userId = _userManager.GetUserAsync(User);
            var userId = _userManager.GetUserId(User);
            var employer = _context.Employers.FirstOrDefault(j => j.UserId == userId);
            // ViewData["EmployerId"] = new SelectList(employer, "Id", "Name");
            ViewData["EmployerName"] = employer.Name;
            ViewData["Location"] = employer.Address;
            // Get only active categories
            var activeCategories = _context.JobCategories
                .Where(c => c.Status == CategoryStatus.Active)
                .ToList();
            ViewData["JobCategoryId"] = new SelectList(activeCategories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,JobCategoryId,EmployerId,Location,Salary,Description,Deadline,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var employer = _context.Employers.Where(j => j.UserId == userId).FirstOrDefault();
                if (employer == null)
                {
                    return View(job);
                }
                job.EmployerId = employer.Id;
                job.Location = employer.Address;
                job.Status = JobStatus.Active;   

                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            // If ModelState is not valid, repopulate ViewData for the form
            ViewData["Name"] = _context.Employers.FirstOrDefault().Name;
            ViewData["Location"] = _context.Employers.FirstOrDefault().Address;
            ViewData["JobCategoryId"] = new SelectList(await _context.JobCategories
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync(), "Id", "Name", job.JobCategoryId);
            return View(job);
        }



        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Name", job.EmployerId);
            ViewData["JobCategoryId"] = new SelectList(await _context.JobCategories
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync(), "Id", "Name", job.JobCategoryId);
            return View(job);
        }

        // POST: Job/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,JobCategoryId,EmployerId,Location,Salary,Description,Deadline,Status")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
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
            ViewData["EmployerId"] = new SelectList(_context.Employers, "Id", "Name", job.EmployerId);
            ViewData["JobCategoryId"] = new SelectList(await _context.JobCategories
                .Where(c => c.Status == CategoryStatus.Active)
                .ToListAsync(), "Id", "Name", job.JobCategoryId);
            return View(job);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Employer)
                .Include(j => j.JobCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job); 
        }
        [Authorize(Roles = "Job Seeker")]
        public async Task<IActionResult> ApplyJob(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction("Create", "JobApplication");
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}



