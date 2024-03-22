using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "0fd08f57-7bc7-4f85-bdcb-5f1491e8c7eb", "student@mail.com", false, false, null, "student@mail.com", "student@mail.com", "AQAAAAEAACcQAAAAEFfG4agNAF7IZZJJsVx3ua/aG7xaGGmeIpEQ3hE7dtmwfxleK8jgL3qaP9n07SbBnQ==", null, false, "f08eaf63-f34c-4a77-91b0-07a45277abcd", false, "student@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "7f33bbdf-a89b-46a3-9bfd-3345bad0e164", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAECzv69usg6++vYuLXKl7Lwj9gIA+nf9+oBI/t1iduCfQfWiYxwlVQG/+/fmffBgu5w==", null, false, "b7a3947b-5656-41e3-8534-9c3fed281360", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Academic Subjects" },
                    { 2, "Creative Arts and Performance" },
                    { 3, "Practical Skills and Trades" },
                    { 4, "Personal Development" },
                    { 5, "Sports and Fitness" },
                    { 6, "Special Interests and Hobbies" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "0876543210", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "City", "Description", "EndDate", "Frequency", "Name", "Price", "StartDate", "TeacherId" },
                values: new object[] { 1, 1, "Sofia", "Math lessons for all classes", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Math", 350m, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "City", "Description", "EndDate", "Frequency", "Name", "Price", "StartDate", "TeacherId" },
                values: new object[] { 2, 2, "Plovdiv", "Guitar lessons for children", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Guitar", 500m, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "City", "Description", "EndDate", "Frequency", "Name", "Price", "StartDate", "TeacherId" },
                values: new object[] { 3, 3, "Stara Zagora", "Autos lectures for teenagers", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Engines", 700m, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
