using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudJWT.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Logins",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Logins",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Logins",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Clients",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Clients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Clients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Clients",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "CreationTime",
                table: "Logins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Logins");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Logins",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Logins",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Logins",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Clients",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Clients",
                newName: "age");
        }
    }
}
