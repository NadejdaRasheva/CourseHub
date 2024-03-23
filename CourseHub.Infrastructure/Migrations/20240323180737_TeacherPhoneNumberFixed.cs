using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class TeacherPhoneNumberFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "371bc4bc-1311-4c1f-a7b2-88f497ecaae1", "AQAAAAEAACcQAAAAEBkRh56kizn4hPbBkQv7uJDjmCd1fTtyHaIzZ3ayCKTTOyXVeoX7l3BPzIi79wpSFQ==", "373456d7-8b65-4d56-bbec-0f004b25b716" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc6e6757-caae-4abe-80bd-c0c9117b0904", "AQAAAAEAACcQAAAAEKBGbBkhhIdMgYSm1YQzx3a7ktEWRPdXd+lTgFJt+edS7FwtQeFotIPX+tWM2Qx1BA==", "65150365-f24a-4760-948d-27a1c022b487" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+359876543210");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "0876543210");
        }
    }
}
