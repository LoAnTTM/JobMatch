using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMatch
{
    public enum ApplicationStatus
    {
        Pending,
        Accepted,
        Denied
    }
    
    public class JobApplication 
    {
        [Key]
        public int Id { get; set; }
        
        public int JobId { get; set; }
        
        public int JobSeekerId { get; set; }
        
        [Display(Name = "Applied Date")]
        [DataType(DataType.Date)]
        public DateTime AppliedDate { get; set; }
        
        public ApplicationStatus Status { get; set; }

        public string? Resume { get; set; }
        
        [ForeignKey("JobId")]
        public virtual Job? Job { get; set; }
        
        [ForeignKey("JobSeekerId")]
        public virtual JobSeeker? JobSeeker { get; set; }
    }
}
