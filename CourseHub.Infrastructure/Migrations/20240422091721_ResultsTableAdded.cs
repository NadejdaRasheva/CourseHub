using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class ResultsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Results_CourseId",
                table: "Results",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f6e6390-fe42-4926-bd90-d757d463b51c", "AQAAAAEAACcQAAAAENaKPdIYEFttwvdOZFmWZYQoR8oPbbp/+wCs8brX6awSnySzOsxisQxKhyFdrD+9qA==", "a7b5a54d-4e10-4a36-b49c-0262103217cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24d825b0-428d-492d-af29-217537c3638a", "AQAAAAEAACcQAAAAEMAE+YsuNy/Xm2Mnau3Dy2WJ/AqahbbGFreRoeEtfs0ArBhY1VbHzdk+IjGNtQLeYg==", "391a8dc4-5135-49b6-8f60-17110767a60c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3a802cd-8bc9-4c3f-bfe1-c08d87389af8", "AQAAAAEAACcQAAAAEBsX82K0862UYCi89f7ieENZFm9gFCHuiyv0kyzuz+8plGgOWb9WC+l+mGFLpExFSA==", "a525adde-80a7-474a-913c-442def45486b" });
        }
    }
}
