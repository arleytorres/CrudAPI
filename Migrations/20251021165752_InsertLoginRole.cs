using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudJWT.Migrations
{
    /// <inheritdoc />
    public partial class InsertLoginRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Logins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Logins");
        }
    }
}
