using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34f78cfc-2bb9-455c-8b88-35f9f209078c", "", "", "AQAAAAEAACcQAAAAEPn6pWUpFdB31JJbrTbZSxtyaVsvjUuOpbdXTGMpCsI/Wvw7n1p0My3EflSgrCI9cg==", "ede651ae-99fe-4772-96a6-d9cff4cdf96e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73e3ed2c-748a-492b-8b09-928bfaf77d9b", "AQAAAAEAACcQAAAAEKWamQuD90BX55JbJupGVbieTns5XGJYzbLS+rf8Sq0a3t7OaNmspI0CIUCxP/VgqA==", "0a5881a2-5b5b-4d93-8fc4-945d321a1c98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ff9fd81-b023-4415-93ab-ed1e040dc1dd", "AQAAAAEAACcQAAAAEPdabT5T/ClRqI8UyxNeu8oVA1r2DAXMZ0jti5T7G6RVhwDZhDLNP64V/xCRsDEXYg==", "60e7e36d-60b2-4e52-ab21-a7b8ba94c377" });
        }
    }
}
