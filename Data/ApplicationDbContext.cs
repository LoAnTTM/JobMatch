using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JobMatch.Models;

namespace JobMatch.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<JobCategory>().HasData(
            new JobCategory { Id = 1, Name = "Software Development", Description = "Developing software applications", Status = CategoryStatus.Active },
            new JobCategory { Id = 2, Name = "Mobile Development", Description = "Developing mobile applications", Status = CategoryStatus.Active },
            new JobCategory { Id = 3, Name = "Web Development", Description = "Developing web applications", Status = CategoryStatus.Active },
            new JobCategory { Id = 4, Name = "Data Science", Description = "Developing data science applications", Status = CategoryStatus.Active },
            new JobCategory { Id = 5, Name = "Product Management", Description = "Managing products", Status = CategoryStatus.Active },
            new JobCategory { Id = 6, Name = "Product Support", Description = "Supporting products", Status = CategoryStatus.Active }  
        );
        // modelBuilder.Entity<Job>().HasData(
            
        // );
        // modelBuilder.Entity<Employer>().HasData(
            
        // );
        // modelBuilder.Entity<JobSeeker>().HasData(
            
        // );
        // modelBuilder.Entity<JobApplication>().HasData(
            
        // );
    }
}
