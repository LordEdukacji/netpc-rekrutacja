using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsApp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categorizations_categorizationId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_categorizationId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "categorizationId",
                table: "Contacts",
                newName: "CategorizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategorizationId",
                table: "Contacts",
                newName: "categorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_categorizationId",
                table: "Contacts",
                column: "categorizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categorizations_categorizationId",
                table: "Contacts",
                column: "categorizationId",
                principalTable: "Categorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
