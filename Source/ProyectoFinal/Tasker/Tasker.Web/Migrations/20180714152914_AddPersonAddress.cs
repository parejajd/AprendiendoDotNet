using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasker.Web.Migrations
{
    public partial class AddPersonAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Person");
        }
    }
}
