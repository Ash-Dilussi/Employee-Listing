using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeListing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init04071 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Employees",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmpId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NIC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DOB = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Employees", x => x.AutoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Employees");
        }
    }
}
