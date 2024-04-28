using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobMatch
{
    public class ApplicationUser : IdentityUser
    {
        public string? password_reset_token { get; set; }
    }
}
