using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_userrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.AppRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "AppRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.AppRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRoleeAppRoleId = table.Column<int>(type: "int", nullable: false),
                    AppRoleId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserrs", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppRoles_AppRoleAppRoleId",
                        column: x => x.AppRoleeAppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "AppRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppRoleAppRoleId",
                table: "AppUsers",
                column: "AppRoleeAppRoleId");
        }
    }
}
