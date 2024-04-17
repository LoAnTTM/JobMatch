using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobMatch
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        [Display(Name = "Company Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        
        public string? Description { get; set; }
        
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
