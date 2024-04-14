using System.ComponentModel.DataAnnotations;

namespace JobMatch
{
    public enum CategoryStatus
    {
        Pending,
        Active,
        Denied
    }
    public class JobCategory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryStatus Status { get; set; }
    }
}