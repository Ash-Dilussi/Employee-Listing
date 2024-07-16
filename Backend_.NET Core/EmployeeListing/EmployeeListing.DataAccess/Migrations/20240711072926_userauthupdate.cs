using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeListing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userauthupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "TBL_UserAuthentication");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "TBL_UserAuthentication",
                type: "RAW(2000)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TBL_UserAuthentication",
                type: "RAW(2000)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TBL_UserAuthentication");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TBL_UserAuthentication");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TBL_UserAuthentication",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
