using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobMatch.Migrations
{
    /// <inheritdoc />
    public partial class HasDataEMJOBS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "Address", "Description", "Email", "IdentityUserId", "Name", "Phone", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Tech Street, Techland", "Tech Solutions Inc. is a leading provider of IT consulting services, specializing in software development, cloud computing, and cybersecurity solutions.", "info@techsolutions.com", null, "Tech Solutions Inc.", "123-456-7890", "b29b9de1-8b79-4a45-8a24-8d8e13345158" },
                    { 2, "456 Logistics Avenue, Cityville", "Global Logistics Group is a multinational logistics company offering end-to-end supply chain solutions, including transportation, warehousing, and freight forwarding services.", "contact@globallogistics.com", null, "Global Logistics Group", "987-654-3210", "fe28485f-d975-4a30-82c9-3fdfa0395cec" },
                    { 3, "789 Education Street, Learning City", "Bright Minds Academy is an innovative educational institution committed to providing high-quality learning experiences for students of all ages. Our curriculum emphasizes creativity, critical thinking, and personal growth.", "info@brightminds.edu", null, "Bright Minds Academy", "111-222-3333", "27e828d1-d603-4695-ba26-a15ca6dd8d85" },
                    { 4, "101 Medical Drive, Healthtown", "HealthCare Innovations LLC is a healthcare technology company focused on developing innovative solutions to improve patient care, enhance clinical workflows, and optimize healthcare delivery.", "info@healthcareinnovations.com", null, "HealthCare Innovations LLC", "444-555-6666", "a7c1cade-8875-4285-86a7-d3a160431965" },
                    { 5, "222 Design Avenue, Creativityville", "Creative Designs Agency is a full-service creative agency specializing in graphic design, branding, web development, and digital marketing services. We help businesses build strong visual identities and engaging online presences.", "contact@creativedesigns.com", null, "Creative Designs Agency", "777-888-9999", "315883da-d6f5-44c7-8e63-99660017e836" },
                    { 6, "333 Renewable Road, Eco City", "Green Energy Solutions Ltd. is a renewable energy company dedicated to promoting sustainability and environmental responsibility. We offer a range of clean energy solutions, including solar power, wind energy, and energy-efficient technologies.", "info@greenenergy.com", null, "Green Energy Solutions Ltd.", "333-444-5555", "fc990428-db81-431a-87cb-de59e251722b" },
                    { 7, "777 Finance Street, Moneytown", "Financial Strategies Group is a financial planning firm specializing in retirement planning, investment management, and wealth preservation strategies. Our team of experienced advisors helps clients achieve their financial goals and secure their financial future.", "contact@financialstrategies.com", null, "Financial Strategies Group", "666-777-8888", "f6606a8b-0544-46a6-b94c-e4a3ab735206" },
                    { 8, "888 Hospitality Boulevard, Welcoming City", "Hospitality Haven Inc. is a hospitality management company operating a portfolio of hotels, resorts, and restaurants worldwide. We are committed to providing exceptional guest experiences and creating memorable moments for our guests.", "info@hospitalityhaven.com", null, "Hospitality Haven Inc.", "999-000-1111", "7c33510b-08e5-4510-921f-8463d4dd138d" },
                    { 9, "555 Engineering Avenue, Innovation City", "Innovative Engineering Solutions is a leading engineering consultancy firm offering a wide range of engineering services, including structural design, civil engineering, and project management. We deliver innovative solutions to complex engineering challenges.", "info@innovativeengg.com", null, "Innovative Engineering Solutions", "222-333-4444", "1d4342c2-3e45-4cf4-89aa-2aa63f67990b" },
                    { 10, "999 HR Street, Talent City", "PeopleFirst HR Consulting is a human resources consulting firm specializing in talent acquisition, employee engagement, and organizational development. We partner with businesses to attract, develop, and retain top talent.", "contact@peoplefirsthr.com", null, "PeopleFirst HR Consulting", "000-111-2222", "f35c9366-6d00-482f-8836-47185ba16ef1" }
                });

            migrationBuilder.InsertData(
                table: "JobSeekers",
                columns: new[] { "Id", "Education", "Email", "IdentityUserId", "Name", "Phone", "Resume", "UserId" },
                values: new object[,]
                {
                    { 1, "High School", "john.doe@example.com", null, "John Doe", "123-456-7890", null, "ce519b82-33ba-41ca-9fe4-db858e78dbfb" },
                    { 2, "College", "jane.smith@example.com", null, "Jane Smith", "987-654-3210", null, "9ea11d53-f1a9-4b4e-aadc-04151abea960" },
                    { 3, "University", "michael.johnson@example.com", null, "Michael Johnson", "111-222-3333", null, "1c43829d-02e8-49c4-b78a-42f38eb87a2e" },
                    { 4, "Master", "emily.brown@example.com", null, "Emily Brown", "444-555-6666", null, "12bca86d-e01f-4920-be31-36e9acf29729" },
                    { 5, "PhD", "daniel.wilson@example.com", null, "Daniel Wilson", "777-888-9999", null, "f33c0fd8-1cb8-4cc3-a39e-2140de9daed0" },
                    { 6, "Other", "sarah.taylor@example.com", null, "Sarah Taylor", "333-444-5555", null, "fc7bbd1d-f85a-4c6f-a839-9093a568c77c" },
                    { 7, "High School", "matthew.anderson@example.com", null, "Matthew Anderson", "666-777-8888", null, "b4dce528-4190-44cb-b8bd-60d183c9fc22" },
                    { 8, "College", "olivia.martinez@example.com", null, "Olivia Martinez", "999-000-1111", null, "b6897cb1-1a04-4e10-bf51-63022181ce9b" },
                    { 9, "University", "james.wilson@example.com", null, "James Wilson", "222-333-4444", null, "23bbf3df-a7ec-4711-80b0-6594da94c8b3" },
                    { 10, "Master", "sophia.johnson@example.com", null, "Sophia Johnson", "000-111-2222", null, "23e09f47-3939-4401-8a29-40605cf328e1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobSeekers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
