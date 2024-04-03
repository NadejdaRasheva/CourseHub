using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class MappingTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursesParticipants",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesParticipants", x => new { x.CourseId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_CoursesParticipants_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesParticipants_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CoursesParticipants_ParticipantId",
                table: "CoursesParticipants",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesParticipants");

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
        }
    }
}
