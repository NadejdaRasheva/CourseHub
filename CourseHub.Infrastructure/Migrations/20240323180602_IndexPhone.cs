using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class IndexPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e5f7d9a-034a-4b40-8162-70dd8daf2ca4", "AQAAAAEAACcQAAAAEOj+gg9rZ1qcp5nCvAspm+OE/YCflPdKBuGJxFbfB1Ml83cAELLWWdVL9TwtwwHrpA==", "2c0fa596-23c0-45bc-bf2d-1ac9d4d2919a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91a58b1e-61a4-4b18-9f35-11daff0f3c94", "AQAAAAEAACcQAAAAEKYjZLz3HgzkNpgciiS7++wPS/f4ZvA5MMrnhNi7zuJKczMdKNh6SCEEpn5+8uO8QA==", "f4aacc6f-817e-4357-8125-7bae679c6de9" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PhoneNumber",
                table: "Teachers",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_PhoneNumber",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef9473fe-b166-4f64-9108-7c655d5256a9", "AQAAAAEAACcQAAAAEA2ef2XaDBtDAkXH3rRxZudEAeSr1rH/thJbnmRM30sGOnTMOcgsOYiS4wAnFW3jDQ==", "ffa9878d-a3c8-4cb6-bd07-2d2172f1df8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f97cc5-39c8-4fa2-be0c-aa66b11f35a0", "AQAAAAEAACcQAAAAED6l3qxwP/l2AQt5VWH2TTVo7NLl9tKu1moaQICHwev7j/OcCQYVT5cBuVCUn7karQ==", "862f6a35-146a-4a62-9fce-bc59c92216af" });
        }
    }
}
