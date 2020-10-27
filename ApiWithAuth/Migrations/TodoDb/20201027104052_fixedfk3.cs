using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWithAuth.Migrations.TodoDb
{
    public partial class fixedfk3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "TodoTaskId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "TodoTasks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TodoTaskId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Days_DayId",
                table: "TodoTasks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
