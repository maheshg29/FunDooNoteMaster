using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositotryLayer.Migrations
{
    public partial class lableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LableTable",
                columns: table => new
                {
                    LableId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LableName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LableTable", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_LableTable_usertable_UserId",
                        column: x => x.UserId,
                        principalTable: "usertable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteLableTable",
                columns: table => new
                {
                    NoteLableId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LableId = table.Column<long>(nullable: false),
                    NoteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteLableTable", x => x.NoteLableId);
                    table.ForeignKey(
                        name: "FK_NoteLableTable_LableTable_LableId",
                        column: x => x.LableId,
                        principalTable: "LableTable",
                        principalColumn: "LableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteLableTable_NoteTable_NoteId",
                        column: x => x.NoteId,
                        principalTable: "NoteTable",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LableTable_UserId",
                table: "LableTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLableTable_LableId",
                table: "NoteLableTable",
                column: "LableId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLableTable_NoteId",
                table: "NoteLableTable",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteLableTable");

            migrationBuilder.DropTable(
                name: "LableTable");
        }
    }
}
