using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobMatch.Migrations
{
    /// <inheritdoc />
    public partial class HasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "Id", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Jobs related to software development, including roles such as software engineer, web developer, and mobile app developer.", "Software Development", 1 },
                    { 2, "Jobs related to data science and analytics, involving tasks such as data analysis, machine learning, and statistical modeling.", "Data Science", 1 },
                    { 3, "Jobs related to marketing and advertising, encompassing roles like digital marketer, social media manager, and marketing strategist.", "Marketing", 1 },
                    { 4, "Jobs in the finance industry, including positions such as financial analyst, accountant, and investment banker.", "Finance", 1 },
                    { 5, "Jobs in the healthcare sector, covering roles such as nurse, doctor, pharmacist, and medical researcher.", "Healthcare", 1 },
                    { 6, "Jobs in the education field, including positions such as teacher, professor, academic advisor, and curriculum developer.", "Education", 1 },
                    { 7, "Jobs in the hospitality industry, involving roles such as hotel manager, chef, event planner, and travel agent.", "Hospitality", 1 },
                    { 8, "Jobs in various engineering disciplines, including mechanical engineering, civil engineering, electrical engineering, and aerospace engineering.", "Engineering", 1 },
                    { 9, "Jobs in human resources management, covering roles such as HR manager, recruiter, training coordinator, and benefits specialist.", "Human Resources", 1 },
                    { 10, "Jobs in design fields such as graphic design, UX/UI design, interior design, and fashion design.", "Design", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
