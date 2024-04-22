using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Infrastructure.Migrations
{
    public partial class ReviewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseId",
                table: "Reviews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "753657b6-827b-4447-bae5-59f69ab21c13", "AQAAAAEAACcQAAAAEAJfUiHxme8ivW33UfEClWYZiMSPc9VyTvsJ6r0JoBZcTlaYY7AXaivkHQRys7NWOg==", "11cf1826-c58e-4373-ac82-98ffee34b632" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb590866-b88e-4405-a9db-59de07db8b31", "AQAAAAEAACcQAAAAELeU8eIdJWSAd2NPuNwo8Vs6M4w6EyjkHaZwtZzPZ4qvmOWxypqmHxwFJkanR4sGUA==", "a0421ba2-b86e-44bd-b5ec-3acdc2b33224" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "275b3c1d-9e82-4cbf-aa79-770e1f32d92d", "AQAAAAEAACcQAAAAEIQjyN6GDtVFxehVz5tCASNOruvrML3VO4nyVn+adDExDO2k2scFg71B5X32lvBkwg==", "86164adf-c3b3-436c-8deb-b9309b0a1515" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");
        }
    }
}
