using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobMatch;
using JobMatch.Data;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace JobMatch.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public JobSeekerController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<IActionResult> ResetPassword(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.ApplicationUsers.Where(u => u.Email == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", code },
                protocol: Request.Scheme);

            user.password_reset_token = HtmlEncoder.Default.Encode(callbackUrl);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
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
