using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMatch
{
    public enum JobStatus
    {
       Active,
       Closed
    }
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        [Display(Name = "Job Category")]
        public int JobCategoryId { get; set; }
        [Display(Name = "Employer name")]
        public int EmployerId { get; set; }
        public string? Location { get; set; }
        public string? Salary { get; set; }
        public string? Description { get; set; }
        
        [Display(Name = "Application Deadline")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        public JobStatus Status { get; set; }
        [ForeignKey("JobCategoryId")]
        public virtual JobCategory? JobCategory { get; set; }
        [ForeignKey("EmployerId")]
        public virtual Employer? Employer { get; set; }
    }
}