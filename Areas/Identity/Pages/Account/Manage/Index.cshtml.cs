#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobMatch.Data;
using JobMatch.Models;
using JobMatch;

namespace JobMatch.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public string Username { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        
        public class InputModel
        {
            public JobSeeker JobSeeker { get; set; }
            public Employer Employer { get; set; }
            public IFormFile Resume { get; set; }
            public string PhoneNumber { get; set; }
        }

        public async Task<bool> IsUserInRole(string roleName)
        {
            var user = await _userManager.GetUserAsync(User);
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var jobSeekers = _context.JobSeekers.Where(j => j.UserId == user.Id).ToList();
            var employers = _context.Employers.Where(j => j.UserId == user.Id).ToList();

            Username = userName;

            Input = new InputModel
            {
                JobSeeker = jobSeekers.Count > 0 ? jobSeekers[0] : new JobSeeker(),
                Employer = employers.Count > 0 ? employers[0] : new Employer(),
                PhoneNumber = phoneNumber,
            };
        }

        // OnGetAsync method to handle GET requests
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        // OnPostAsync method to handle POST requests
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var setResult = 0;

            // Update JobSeeker details
            if (Input.JobSeeker != null) {
                var jobSeeker = new JobSeeker { UserId = user.Id };
                var jobSeekers = _context.JobSeekers.Where(j => j.UserId == user.Id).ToList();
                if (jobSeekers.Count != 0) {
                    jobSeeker = jobSeekers[0];
                } else {
                    _context.JobSeekers.Add(jobSeeker);
                }
                jobSeeker.Name = Input.JobSeeker.Name;
                jobSeeker.Education = Input.JobSeeker.Education;
                jobSeeker.Email = user.UserName;
                jobSeeker.Phone = Input.JobSeeker.Phone;
                jobSeeker.Resume = Input.JobSeeker.Resume;
                setResult = await _context.SaveChangesAsync();
            }
            // Update Employer detail
            else if (Input.Employer != null) {
                var employer = new Employer { UserId = user.Id };
                var employers = _context.Employers.Where(j => j.UserId == user.Id).ToList();
                if (employers.Count != 0) {
                    employer = employers[0];
                } else {
                    // var employer = new JobSeeker { UserId = user.Id };
                    _context.Employers.Add(employer);
                }
                employer.Name = Input.Employer.Name;
                employer.Phone = Input.Employer.Phone;
                employer.Email = user.UserName;
                employer.Address = Input.Employer.Address;
                employer.Description = Input.Employer.Description;
                setResult = await _context.SaveChangesAsync();
            }

            // Handle the uploaded file
            var file = Input.Resume;
            if (file != null && file.Length > 0)
            {
                // Generate a unique file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                // Define the path to the directory where you want to save the files
                string resumePath = Path.Combine(_hostEnvironment.WebRootPath, "img", "SeekerResume");
                // Create the directory if it doesn't exist
                if (!Directory.Exists(resumePath))
                {
                    Directory.CreateDirectory(resumePath);
                }
                // Define the path to the file
                string filePath = Path.Combine(resumePath, fileName);
                // Save the file to the directory
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                // Store the path to the file in the JobSeeker model
                Input.JobSeeker.Resume = @"img\SeekerResume\" + fileName;
            }

            // Update the phone number
            if (Input.PhoneNumber != phoneNumber)
            {
                Input.PhoneNumber = user.PhoneNumber;
                setResult = await _context.SaveChangesAsync();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
