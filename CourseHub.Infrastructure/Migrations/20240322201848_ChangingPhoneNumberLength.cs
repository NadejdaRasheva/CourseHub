using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class ChangingPhoneNumberLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                comment: "Teacher's phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Teacher's phone number");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Teacher's phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldComment: "Teacher's phone number");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fd08f57-7bc7-4f85-bdcb-5f1491e8c7eb", "AQAAAAEAACcQAAAAEFfG4agNAF7IZZJJsVx3ua/aG7xaGGmeIpEQ3hE7dtmwfxleK8jgL3qaP9n07SbBnQ==", "f08eaf63-f34c-4a77-91b0-07a45277abcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f33bbdf-a89b-46a3-9bfd-3345bad0e164", "AQAAAAEAACcQAAAAECzv69usg6++vYuLXKl7Lwj9gIA+nf9+oBI/t1iduCfQfWiYxwlVQG/+/fmffBgu5w==", "b7a3947b-5656-41e3-8534-9c3fed281360" });
        }
    }
}
