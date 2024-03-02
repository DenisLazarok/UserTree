using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTree.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStackTrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StackTrace",
                table: "JournalEvents",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StackTrace",
                table: "JournalEvents");
        }
    }
}
