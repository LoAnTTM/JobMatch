using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


using JobMatch;
using JobMatch.Data;

namespace JobMatch.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RoleManager<IdentityRole> _roleManager;

        public JobApplicationController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _roleManager = roleManager;
        }

        // GET: JobApplication
        public async Task<IActionResult> Index()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id; // Get the user's ID

            // Initialize the query with all job applications
            IQueryable<JobApplication> query = _context.JobApplications.Include(j => j.Job)
                                                .Include(j => j.JobSeeker);

            // As role employer, can see all applications of jobs created by this employer.
            if (await _userManager.IsInRoleAsync(user, "Employer"))
            {
                query = query.Where(j => j.Job.Employer.UserId == userId);
            }
            // As role job seeker, can see all my applications.
            else if (await _userManager.IsInRoleAsync(user, "Job Seeker"))
            {
                query = query.Where(j => j.JobSeeker.UserId == userId);
            }
            // As role admin, can see all job applications.
            else if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                // No need to modify the query, as admin can see all job applications.
            }

            var jobApplications = await query.ToListAsync();
            return View(jobApplications);
        }

        // GET: JobApplication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.Job)
                .Include(j => j.JobSeeker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // GET: JobApplication/Create
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);
            var jobSeeker = _context.JobSeekers.FirstOrDefault(j => j.UserId == userId);
            ViewData["Name"] = jobSeeker.Name;
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Title");
            // ViewData["JobSeekerId"] = new SelectList(_context.JobSeekers, "Id", "UserId");
            return View();
        }

        // POST: JobApplication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobId,JobSeekerId,AppliedDate,Status,Resume")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var jobSeeker = _context.JobSeekers.Where(j => j.UserId == userId).FirstOrDefault();
                if (jobSeeker == null)
                {
                    return View(jobApplication);
                }
                jobApplication.JobSeekerId = jobSeeker.Id;
                IFormFile Resume = Request.Form.Files["Resume_file"];
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string resumePath = Path.Combine(wwwRootPath, @"pdf/Resume");
                if (Resume != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Resume.FileName);
                    using (var fileStream = new FileStream(Path.Combine(resumePath, fileName), FileMode.Create))
                    {
                        Resume.CopyTo(fileStream);
                    }
                    jobApplication.Resume = fileName;
                }
                jobApplication.Status = ApplicationStatus.Pending;
                jobApplication.AppliedDate = DateTime.Now;
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Title", jobApplication.JobId);
            ViewData["JobSeekerId"] = new SelectList(_context.JobSeekers, "Id", "Name", jobApplication.JobSeekerId);
            return View(jobApplication);
        }

        // GET: JobApplication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            //Load resume file if it exists
            ViewData["Resume"] = jobApplication.Resume;
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Title", jobApplication.JobId);
            ViewData["JobSeekerId"] = new SelectList(_context.JobSeekers, "Id", "Name", jobApplication.JobSeekerId);
            return View(jobApplication);
        }

        // POST: JobApplication/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,JobId,JobSeekerId,AppliedDate,Status,Resume")] JobApplication jobApplication)
        {
            jobApplication = await _context.JobApplications.FindAsync(id);
            if (id != jobApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Update resume file if a new file is uploaded
                    IFormFile Resume_file = Request.Form.Files["resume_file"];
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string resumePath = Path.Combine(wwwRootPath, @"pdf/Resume");
                    if (Resume_file != null)
                    {
                        if (!string.IsNullOrEmpty(jobApplication.Resume))
                        {
                            string oldResumePath = Path.Combine(wwwRootPath, "pdf/Resume", jobApplication.Resume);
                            // Console.WriteLine("Old resume path: " + oldResumePath);
                            FileInfo fileInfo = new FileInfo(oldResumePath);
                            if (fileInfo.Exists)
                            {
                                fileInfo.Delete();
                            }
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Resume_file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(resumePath, fileName), FileMode.Create))
                        {
                            Resume_file.CopyTo(fileStream);
                        }
                        jobApplication.Resume = fileName;
                    }else{
                        jobApplication.Resume = jobApplication.Resume;
                    }

                    jobApplication.Status = ApplicationStatus.Pending;
                    jobApplication.AppliedDate = DateTime.Now;
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.Id))
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
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Title", jobApplication.JobId);
            ViewData["JobSeekerId"] = new SelectList(_context.JobSeekers, "Id", "Name", jobApplication.JobSeekerId);
            return View(jobApplication);
        }

        // GET: JobApplication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.Job)
                .Include(j => j.JobSeeker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (!string.IsNullOrEmpty(jobApplication.Resume))
                {
                    string oldResumePath = Path.Combine(wwwRootPath, "pdf/Resume", jobApplication.Resume);
                    // Console.WriteLine("Old resume path: " + oldResumePath);
                    FileInfo fileInfo = new FileInfo(oldResumePath);
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                }
                _context.JobApplications.Remove(jobApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .FirstOrDefaultAsync(m => m.Id == id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(jobApplication.Resume))
            {
                return NotFound(); 
            }

            // Get the path to the resume file
            string resumeFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Resume", jobApplication.Resume);

            // Check if the file exists
            if (!System.IO.File.Exists(resumeFilePath))
            {
                return NotFound();
            }

            // Return the resume file for download
            return PhysicalFile(resumeFilePath, "application/octet-stream", enableRangeProcessing: true);
        }

        public IActionResult ViewResume(string resume)
        {
            // Retrieve the file path based on the resume file name
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/Resume", resume);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); 
            }
            // Return the resume file
            return PhysicalFile(filePath, "application/pdf");
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }

        // GET: JobApplication/Accept/5
        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            // Update the status to Accepted
            jobApplication.Status = ApplicationStatus.Accepted;
            
            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: JobApplication/Decline/5
        public async Task<IActionResult> Decline(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            // Update the status to Declined
            jobApplication.Status = ApplicationStatus.Denied;
            
            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
