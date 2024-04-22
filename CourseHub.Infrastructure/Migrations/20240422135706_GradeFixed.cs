using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class GradeFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "896a67fb-82dc-4948-b650-0071860b28dc", "AQAAAAEAACcQAAAAEBT/q/23bBFTV0ybBuajz8dmqHeaDfnUzCqIVOJiJBiBt/l72INfob6F0YckmzD47w==", "b9a04787-173e-4546-a548-44dccb93be7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0190ddc5-efb2-426c-aef5-4633cc3dae6a", "AQAAAAEAACcQAAAAEHojXFwBIORfC8aDDnHTEjRs5zq57ijzzzstDnRdj8RI3UAH5EYCcQ0uJZh6J1+7cQ==", "8919f670-5a11-4021-836e-13ff6c65df31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2401c8ba-335c-4d93-a220-4d18fb683298", "AQAAAAEAACcQAAAAEIzTy4rHRmjOavjEVPbu02o53QVTTs6kjnsSxeWddMBUAoxVso911dSgzn1ljKPVaA==", "22dd3bfb-c593-462b-8920-698ef80a4fdb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "269f78df-faca-4473-a02f-1cf34ca8ad8d", "AQAAAAEAACcQAAAAEI3ZvDKvKiLPdS9NcK/RR6Lyt+SikLwYfXylCmL0Y4ONuAe5OgYNvJdJiLWb95wJyQ==", "dc66f386-516b-42b6-a890-c1d063d16006" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79a50d4c-846c-438a-ab36-15f643f05663", "AQAAAAEAACcQAAAAEGZz7S0PX6Ca0LExOcQFXQOAbG7laesdZB000Ure8/q3Cex3fxHh7tHqQF4iLi4Dzw==", "6a8733d8-b61c-4714-a466-8e05feb01157" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5870af5f-0884-4a72-ae26-e3488674de97", "AQAAAAEAACcQAAAAEK+JllppPsMUIBc8FkJ7deqGv4ct7N22q2m56OaJl/o0dvZGAWEWWOlp/JMaJCSR3A==", "989bfae3-b3cc-4048-8bc3-0a1499f51652" });
        }
    }
}
