using Microsoft.EntityFrameworkCore.Migrations;

namespace Planiture_Website.Migrations
{
    public partial class updateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "UserTransaction");

            migrationBuilder.DropColumn(
                name: "Trans_CustomerID",
                table: "UserTransaction");

            migrationBuilder.DropColumn(
                name: "Trans_EmployeeID",
                table: "UserTransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "UserTransaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trans_CustomerID",
                table: "UserTransaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trans_EmployeeID",
                table: "UserTransaction",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
