using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "753657b6-827b-4447-bae5-59f69ab21c13", "Student", "Student", "AQAAAAEAACcQAAAAEAJfUiHxme8ivW33UfEClWYZiMSPc9VyTvsJ6r0JoBZcTlaYY7AXaivkHQRys7NWOg==", "11cf1826-c58e-4373-ac82-98ffee34b632" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "275b3c1d-9e82-4cbf-aa79-770e1f32d92d", "teacher@mail.com", "Teacher", "Teacher", "teacher@mail.com", "teacher@mail.com", "AQAAAAEAACcQAAAAEIQjyN6GDtVFxehVz5tCASNOruvrML3VO4nyVn+adDExDO2k2scFg71B5X32lvBkwg==", "86164adf-c3b3-436c-8deb-b9309b0a1515", "teacher@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "cb590866-b88e-4405-a9db-59de07db8b31", "admin@mail.com", false, "Great", "Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAELeU8eIdJWSAd2NPuNwo8Vs6M4w6EyjkHaZwtZzPZ4qvmOWxypqmHxwFJkanR4sGUA==", null, false, "a0421ba2-b86e-44bd-b5ec-3acdc2b33224", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359888888888", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e193e657-3446-41f7-a3ba-d90e71a78700", "", "", "AQAAAAEAACcQAAAAENHBpDZTe1TpEWDllUaKOL8NGzw62Fu1bTvXCEpdSLf/bxcIWdsy7ZbjiJlC4ekG2Q==", "90c6b4bc-eb1e-4fbe-b9ab-a417f01ec605" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "34f78cfc-2bb9-455c-8b88-35f9f209078c", "agent@mail.com", "", "", "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEPn6pWUpFdB31JJbrTbZSxtyaVsvjUuOpbdXTGMpCsI/Wvw7n1p0My3EflSgrCI9cg==", "ede651ae-99fe-4772-96a6-d9cff4cdf96e", "agent@mail.com" });
        }
    }
}
