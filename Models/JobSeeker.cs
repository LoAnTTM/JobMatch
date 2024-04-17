using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobMatch
{
    public class JobSeeker
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "User ID is required")]
        public string? UserId { get; set; }
        [Display(Name = "Full Name")]
        public string? Name { get; set; }
        
        public string? Education { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        
        public string? Resume { get; set; }
        
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
