using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyMellow.DbContext.Migrations
{
    public partial class DifferentiateTaskFlowForAndIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFlowMap");

            migrationBuilder.CreateTable(
                name: "TaskFlowForTaskMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskId = table.Column<int>(nullable: false),
                    TaskFlowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlowForTaskMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFlowForTaskMap_TaskFlow_TaskFlowId",
                        column: x => x.TaskFlowId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFlowForTaskMap_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskInTaskFlowMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrderNumber = table.Column<short>(nullable: false),
                    TaskFlowId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInTaskFlowMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskInTaskFlowMap_TaskFlow_TaskFlowId",
                        column: x => x.TaskFlowId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskInTaskFlowMap_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowForTaskMap_TaskFlowId",
                table: "TaskFlowForTaskMap",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowForTaskMap_TaskId",
                table: "TaskFlowForTaskMap",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInTaskFlowMap_TaskFlowId",
                table: "TaskInTaskFlowMap",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInTaskFlowMap_TaskId",
                table: "TaskInTaskFlowMap",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFlowForTaskMap");

            migrationBuilder.DropTable(
                name: "TaskInTaskFlowMap");

            migrationBuilder.CreateTable(
                name: "TaskFlowMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrderNumber = table.Column<short>(nullable: false),
                    TaskFlowId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlowMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFlowMap_TaskFlow_TaskFlowId",
                        column: x => x.TaskFlowId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFlowMap_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowMap_TaskFlowId",
                table: "TaskFlowMap",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowMap_TaskId",
                table: "TaskFlowMap",
                column: "TaskId");
        }
    }
}
