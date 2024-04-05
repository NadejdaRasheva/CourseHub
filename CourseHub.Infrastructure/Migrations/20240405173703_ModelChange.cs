using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae44aba4-311f-4d6c-a2dc-b3d0521a1781", "AQAAAAEAACcQAAAAEFeq1tPT2qUpAmfgPff4uR7HgDsZUFOrY7jkmxN9monJi/sZ3/B58lLTCjpBi+zPgg==", "89dcae46-1b5a-4b11-a485-c1298d2f8789" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dac85e3-cb32-4c1a-a482-b598973c3b32", "AQAAAAEAACcQAAAAEBqZ0yP63s7I/U9AXKKkMqtsml036Kr8LLcyN4U6Y71EpcCSJjwzkookxOI/JFq8Cw==", "6eb6dd19-8372-4fb0-bcfa-3d3cdcc6044f" });
        }
    }
}
