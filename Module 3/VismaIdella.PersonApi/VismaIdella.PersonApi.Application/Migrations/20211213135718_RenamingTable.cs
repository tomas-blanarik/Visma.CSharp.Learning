using Microsoft.EntityFrameworkCore.Migrations;

namespace VismaIdella.PersonApi.Application.Migrations
{
    public partial class RenamingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_Lists_TodoListId",
                table: "ListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListItem",
                table: "ListItem");

            migrationBuilder.RenameTable(
                name: "ListItem",
                newName: "ListItems");

            migrationBuilder.RenameIndex(
                name: "IX_ListItem_TodoListId",
                table: "ListItems",
                newName: "IX_ListItems_TodoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_Lists_TodoListId",
                table: "ListItems",
                column: "TodoListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_Lists_TodoListId",
                table: "ListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListItems",
                table: "ListItems");

            migrationBuilder.RenameTable(
                name: "ListItems",
                newName: "ListItem");

            migrationBuilder.RenameIndex(
                name: "IX_ListItems_TodoListId",
                table: "ListItem",
                newName: "IX_ListItem_TodoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListItem",
                table: "ListItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_Lists_TodoListId",
                table: "ListItem",
                column: "TodoListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
