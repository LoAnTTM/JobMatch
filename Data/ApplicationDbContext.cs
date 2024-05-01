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
            new JobCategory { Id = 1, Name = "Software Development", Description = "Jobs related to software development, including roles such as software engineer, web developer, and mobile app developer.", Status = CategoryStatus.Active },
            new JobCategory { Id = 2, Name = "Data Science", Description = "Jobs related to data science and analytics, involving tasks such as data analysis, machine learning, and statistical modeling.", Status = CategoryStatus.Active },
            new JobCategory { Id = 3, Name = "Marketing", Description = "Jobs related to marketing and advertising, encompassing roles like digital marketer, social media manager, and marketing strategist.", Status = CategoryStatus.Active },
            new JobCategory { Id = 4, Name = "Finance", Description = "Jobs in the finance industry, including positions such as financial analyst, accountant, and investment banker.", Status = CategoryStatus.Active },
            new JobCategory { Id = 5, Name = "Healthcare", Description = "Jobs in the healthcare sector, covering roles such as nurse, doctor, pharmacist, and medical researcher.", Status = CategoryStatus.Active },
            new JobCategory { Id = 6, Name = "Education", Description = "Jobs in the education field, including positions such as teacher, professor, academic advisor, and curriculum developer.", Status = CategoryStatus.Active },
            new JobCategory { Id = 7, Name = "Hospitality", Description = "Jobs in the hospitality industry, involving roles such as hotel manager, chef, event planner, and travel agent.", Status = CategoryStatus.Active },
            new JobCategory { Id = 8, Name = "Engineering", Description = "Jobs in various engineering disciplines, including mechanical engineering, civil engineering, electrical engineering, and aerospace engineering.", Status = CategoryStatus.Active },
            new JobCategory { Id = 9, Name = "Human Resources", Description = "Jobs in human resources management, covering roles such as HR manager, recruiter, training coordinator, and benefits specialist.", Status = CategoryStatus.Active },
            new JobCategory { Id = 10, Name = "Design", Description = "Jobs in design fields such as graphic design, UX/UI design, interior design, and fashion design.", Status = CategoryStatus.Active }  
        );
        modelBuilder.Entity<Employer>().HasData(
            new Employer { Id = 1, UserId = "b29b9de1-8b79-4a45-8a24-8d8e13345158", Name = "Tech Solutions Inc.", Email = "info@techsolutions.com", Phone = "123-456-7890", Address = "123 Tech Street, Techland", Description = "Tech Solutions Inc. is a leading provider of IT consulting services, specializing in software development, cloud computing, and cybersecurity solutions." },
            new Employer { Id = 2, UserId = "fe28485f-d975-4a30-82c9-3fdfa0395cec", Name = "Global Logistics Group", Email = "contact@globallogistics.com", Phone = "987-654-3210", Address = "456 Logistics Avenue, Cityville", Description = "Global Logistics Group is a multinational logistics company offering end-to-end supply chain solutions, including transportation, warehousing, and freight forwarding services." },
            new Employer { Id = 3, UserId = "27e828d1-d603-4695-ba26-a15ca6dd8d85", Name = "Bright Minds Academy", Email = "info@brightminds.edu", Phone = "111-222-3333", Address = "789 Education Street, Learning City", Description = "Bright Minds Academy is an innovative educational institution committed to providing high-quality learning experiences for students of all ages. Our curriculum emphasizes creativity, critical thinking, and personal growth." },
            new Employer { Id = 4, UserId = "a7c1cade-8875-4285-86a7-d3a160431965", Name = "HealthCare Innovations LLC", Email = "info@healthcareinnovations.com", Phone = "444-555-6666", Address = "101 Medical Drive, Healthtown", Description = "HealthCare Innovations LLC is a healthcare technology company focused on developing innovative solutions to improve patient care, enhance clinical workflows, and optimize healthcare delivery." },
            new Employer { Id = 5, UserId = "315883da-d6f5-44c7-8e63-99660017e836", Name = "Creative Designs Agency", Email = "contact@creativedesigns.com", Phone = "777-888-9999", Address = "222 Design Avenue, Creativityville", Description = "Creative Designs Agency is a full-service creative agency specializing in graphic design, branding, web development, and digital marketing services. We help businesses build strong visual identities and engaging online presences." },
            new Employer { Id = 6, UserId = "fc990428-db81-431a-87cb-de59e251722b", Name = "Green Energy Solutions Ltd.", Email = "info@greenenergy.com", Phone = "333-444-5555", Address = "333 Renewable Road, Eco City", Description = "Green Energy Solutions Ltd. is a renewable energy company dedicated to promoting sustainability and environmental responsibility. We offer a range of clean energy solutions, including solar power, wind energy, and energy-efficient technologies." },
            new Employer { Id = 7, UserId = "f6606a8b-0544-46a6-b94c-e4a3ab735206", Name = "Financial Strategies Group", Email = "contact@financialstrategies.com", Phone = "666-777-8888", Address = "777 Finance Street, Moneytown", Description = "Financial Strategies Group is a financial planning firm specializing in retirement planning, investment management, and wealth preservation strategies. Our team of experienced advisors helps clients achieve their financial goals and secure their financial future." },
            new Employer { Id = 8, UserId = "7c33510b-08e5-4510-921f-8463d4dd138d", Name = "Hospitality Haven Inc.", Email = "info@hospitalityhaven.com", Phone = "999-000-1111", Address = "888 Hospitality Boulevard, Welcoming City", Description = "Hospitality Haven Inc. is a hospitality management company operating a portfolio of hotels, resorts, and restaurants worldwide. We are committed to providing exceptional guest experiences and creating memorable moments for our guests." },
            new Employer { Id = 9, UserId = "1d4342c2-3e45-4cf4-89aa-2aa63f67990b", Name = "Innovative Engineering Solutions", Email = "info@innovativeengg.com", Phone = "222-333-4444", Address = "555 Engineering Avenue, Innovation City", Description = "Innovative Engineering Solutions is a leading engineering consultancy firm offering a wide range of engineering services, including structural design, civil engineering, and project management. We deliver innovative solutions to complex engineering challenges." },
            new Employer { Id = 10, UserId = "f35c9366-6d00-482f-8836-47185ba16ef1", Name = "PeopleFirst HR Consulting", Email = "contact@peoplefirsthr.com", Phone = "000-111-2222", Address = "999 HR Street, Talent City", Description = "PeopleFirst HR Consulting is a human resources consulting firm specializing in talent acquisition, employee engagement, and organizational development. We partner with businesses to attract, develop, and retain top talent." }
        );
        modelBuilder.Entity<JobSeeker>().HasData(
            new JobSeeker { Id = 1, UserId = "ce519b82-33ba-41ca-9fe4-db858e78dbfb", Name = "John Doe", Education = "High School", Email = "john.doe@example.com", Phone = "123-456-7890", Resume = null },
            new JobSeeker { Id = 2, UserId = "9ea11d53-f1a9-4b4e-aadc-04151abea960", Name = "Jane Smith", Education = "College", Email = "jane.smith@example.com", Phone = "987-654-3210", Resume = null },
            new JobSeeker { Id = 3, UserId = "1c43829d-02e8-49c4-b78a-42f38eb87a2e", Name = "Michael Johnson", Education = "University", Email = "michael.johnson@example.com", Phone = "111-222-3333", Resume = null },
            new JobSeeker { Id = 4, UserId = "12bca86d-e01f-4920-be31-36e9acf29729", Name = "Emily Brown", Education = "Master", Email = "emily.brown@example.com", Phone = "444-555-6666", Resume = null },
            new JobSeeker { Id = 5, UserId = "f33c0fd8-1cb8-4cc3-a39e-2140de9daed0", Name = "Daniel Wilson", Education = "PhD", Email = "daniel.wilson@example.com", Phone = "777-888-9999", Resume = null },
            new JobSeeker { Id = 6, UserId = "fc7bbd1d-f85a-4c6f-a839-9093a568c77c", Name = "Sarah Taylor", Education = "Other", Email = "sarah.taylor@example.com", Phone = "333-444-5555", Resume = null },
            new JobSeeker { Id = 7, UserId = "b4dce528-4190-44cb-b8bd-60d183c9fc22", Name = "Matthew Anderson", Education = "High School", Email = "matthew.anderson@example.com", Phone = "666-777-8888", Resume = null },
            new JobSeeker { Id = 8, UserId = "b6897cb1-1a04-4e10-bf51-63022181ce9b", Name = "Olivia Martinez", Education = "College", Email = "olivia.martinez@example.com", Phone = "999-000-1111", Resume = null },
            new JobSeeker { Id = 9, UserId = "23bbf3df-a7ec-4711-80b0-6594da94c8b3", Name = "James Wilson", Education = "University", Email = "james.wilson@example.com", Phone = "222-333-4444", Resume = null },
            new JobSeeker { Id = 10, UserId = "23e09f47-3939-4401-8a29-40605cf328e1", Name = "Sophia Johnson", Education = "Master", Email = "sophia.johnson@example.com", Phone = "000-111-2222", Resume = null }
        );
        // modelBuilder.Entity<Job>().HasData(
        //     new Job { Id = 1, Title = "Software Engineer", JobCategoryId = 1, EmployerId = 1, Location = "123 Tech Street, Techland", Salary = "$80,000 - $100,000", Description = "Tech Solutions Inc. is seeking a talented software engineer to join our development team. The ideal candidate will have experience in full-stack web development and proficiency in programming languages such as JavaScript, Python, and SQL.", Deadline = DateTime.Now.AddDays(15), Status = JobStatus.Active },
        //     new Job { Id = 2, Title = "Data Analyst", JobCategoryId = 2, EmployerId = 2, Location = "456 Logistics Avenue, Cityville", Salary = "$60,000 - $80,000", Description = "Global Logistics Group is hiring a data analyst to support our supply chain operations. The role involves analyzing data, generating reports, and providing insights to optimize logistics processes and improve operational efficiency.", Deadline = DateTime.Now.AddDays(15), Status = JobStatus.Active },
        //     new Job { Id = 3, Title = "Marketing Manager", JobCategoryId = 3, EmployerId = 3, Location = "789 Education Street, Learning City", Salary = "$70,000 - $90,000", Description = "Bright Minds Academy is looking for a dynamic marketing manager to oversee our marketing campaigns and promotional activities. The ideal candidate will have a strong background in digital marketing, branding, and social media management.", Deadline = DateTime.Now.AddDays(15), Status = JobStatus.Active },
        //     new Job { Id = 4, Title = "Financial Analyst", JobCategoryId = 4, EmployerId = 4, Location = "101 Medical Drive, Healthtown", Salary = "$75,000 - $95,000", Description = "HealthCare Innovations LLC is seeking a skilled financial analyst to support our finance team. Responsibilities include financial modeling, budgeting, forecasting, and performance analysis.", Deadline = DateTime.Now.AddDays(7), Status = JobStatus.Active },
        //     new Job { Id = 5, Title = "Graphic Designer", JobCategoryId = 10, EmployerId = 5, Location = "222 Design Avenue, Creativityville", Salary = "$50,000 - $70,000", Description = "Creative Designs Agency is hiring a talented graphic designer to create visual concepts and designs for print and digital media. The ideal candidate will have proficiency in design software such as Adobe Photoshop, Illustrator, and InDesign.", Deadline = DateTime.Now.AddDays(7), Status = JobStatus.Active },
        //     new Job { Id = 6, Title = "Renewable Energy Engineer", JobCategoryId = 8, EmployerId = 6, Location = "333 Renewable Road, Eco City", Salary = "$85,000 - $105,000", Description = "Green Energy Solutions Ltd. is seeking a renewable energy engineer to design and develop sustainable energy solutions. The role involves working on solar power projects, wind energy systems, and energy efficiency initiatives.", Deadline = DateTime.Now.AddDays(7), Status = JobStatus.Active },
        //     new Job { Id = 7, Title = "Financial Advisor", JobCategoryId = 4, EmployerId = 7, Location = "777 Finance Street, Moneytown", Salary = "$90,000 - $110,000", Description = "Financial Strategies Group is hiring a financial advisor to provide personalized financial planning and investment advice to clients. The ideal candidate will have strong analytical skills and a deep understanding of financial markets.", Deadline = DateTime.Now.AddDays(7), Status = JobStatus.Active },
        //     new Job { Id = 8, Title = "Hotel Manager", JobCategoryId = 7, EmployerId = 8, Location = "888 Hospitality Boulevard, Welcoming City", Salary = "$65,000 - $85,000", Description = "Hospitality Haven Inc. is seeking an experienced hotel manager to oversee all aspects of hotel operations, including guest services, staff management, and property maintenance. The ideal candidate will have strong leadership skills and a passion for hospitality.", Deadline = DateTime.Now.AddDays(30), Status = JobStatus.Active },
        //     new Job { Id = 9, Title = "Civil Engineer", JobCategoryId = 8, EmployerId = 9, Location = "555 Engineering Avenue, Innovation City", Salary = "$70,000 - $90,000", Description = "Innovative Engineering Solutions is hiring a civil engineer to design and supervise construction projects. The role involves preparing engineering designs, managing project budgets, and ensuring compliance with regulatory requirements.", Deadline = DateTime.Now.AddDays(30), Status = JobStatus.Active },
        //     new Job { Id = 10, Title = "HR Manager", JobCategoryId = 9, EmployerId = 10, Location = "999 HR Street, Talent City", Salary = "$80,000 - $100,000", Description = "PeopleFirst HR Consulting is seeking an experienced HR manager to lead our HR department. Responsibilities include recruitment, employee relations, performance management, and organizational development.", Deadline = DateTime.Now.AddDays(30), Status = JobStatus.Active }
        // );

        // modelBuilder.Entity<JobApplication>().HasData(
        //     new JobApplication { Id = 1, JobId = 1, JobSeekerId = 1, AppliedDate = DateTime.Now.AddDays(-10), Status = ApplicationStatus.Accepted, Resume = null },
        //     new JobApplication { Id = 2, JobId = 2, JobSeekerId = 2, AppliedDate = DateTime.Now.AddDays(-8), Status = ApplicationStatus.Accepted, Resume = null },
        //     new JobApplication { Id = 3, JobId = 3, JobSeekerId = 3, AppliedDate = DateTime.Now.AddDays(-6), Status = ApplicationStatus.Accepted, Resume = null },
        //     new JobApplication { Id = 4, JobId = 4, JobSeekerId = 4, AppliedDate = DateTime.Now.AddDays(-4), Status = ApplicationStatus.Pending, Resume = null },
        //     new JobApplication { Id = 5, JobId = 5, JobSeekerId = 5, AppliedDate = DateTime.Now.AddDays(-2), Status = ApplicationStatus.Pending, Resume = null },
        //     new JobApplication { Id = 6, JobId = 6, JobSeekerId = 6, AppliedDate = DateTime.Now.AddDays(-1), Status = ApplicationStatus.Pending, Resume = null },
        //     new JobApplication { Id = 7, JobId = 7, JobSeekerId = 7, AppliedDate = DateTime.Now.AddDays(-10), Status = ApplicationStatus.Denied, Resume = null },
        //     new JobApplication { Id = 8, JobId = 8, JobSeekerId = 8, AppliedDate = DateTime.Now.AddDays(-8), Status = ApplicationStatus.Denied, Resume = null },
        //     new JobApplication { Id = 9, JobId = 9, JobSeekerId = 9, AppliedDate = DateTime.Now.AddDays(-6), Status = ApplicationStatus.Denied, Resume = null },
        //     new JobApplication { Id = 10, JobId = 10, JobSeekerId = 10, AppliedDate = DateTime.Now.AddDays(-4), Status = ApplicationStatus.Pending, Resume = null }
        // );
    }
}
