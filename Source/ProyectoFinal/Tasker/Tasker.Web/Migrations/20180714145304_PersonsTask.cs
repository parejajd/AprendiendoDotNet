using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasker.Web.Migrations
{
    public partial class PersonsTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTasks",
                columns: table => new
                {
                    MyTaskId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTasks", x => new { x.MyTaskId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonTasks_Tasks_MyTaskId",
                        column: x => x.MyTaskId,
                        principalTable: "Tasks",
                        principalColumn: "MyTaskId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonTasks_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTasks_PersonId",
                table: "PersonTasks",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTasks");
        }
    }
}
