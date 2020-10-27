using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWithAuth.Migrations.TodoDb
{
    public partial class fixedfk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "TodoTasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
